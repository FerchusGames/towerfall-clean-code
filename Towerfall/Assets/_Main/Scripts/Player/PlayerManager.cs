using System;
using Cysharp.Threading.Tasks;
using Towerfall.Controllers;
using Towerfall.Managers.Properties;
using UniRx;
using UnityEngine;
using Zenject;

namespace Towerfall.Managers
{
    public partial class PlayerManager : IPlayerControllerInput, IPlayerControllerEvent
    {
        [Inject] private IPlayerInput _playerInput;
        [Inject] private IPlayerProperties _playerProperties;

        private Subject<float> _jumpStartSubject = new Subject<float>();
        private Subject<float> _moveSubject = new Subject<float>();
        private Subject<Vector2> _dashStartSubject = new Subject<Vector2>();

        private Subject<Unit> _dashEndSubject = new Subject<Unit>();
        
        public IObservable<float> JumpStart => _jumpStartSubject.AsObservable();
        public IObservable<float> Move => _moveSubject.AsObservable();
        public IObservable<Vector2> DashStart => _dashStartSubject.AsObservable();
        public IObservable<Unit> DashEnd => _dashEndSubject.AsObservable();


        private void ExecuteJumpStartEvent()
        {
            _jumpStartSubject.OnNext(_playerProperties.JumpForceMagnitude);
        }

        private void ExecuteMoveEvent(float moveDirection)
        {
            _moveSubject.OnNext(moveDirection * _playerProperties.MoveAccelerationRate);
        }

        private void ExecuteDashStartEvent(Vector2 dashDirection)
        {
            Dash(dashDirection, _playerProperties.DashDuration).Forget();
        }
    }

    public partial class PlayerManager : IInitializable
    {
        public void Initialize() 
        {
            _playerInput.JumpStartAction.Subscribe(ExecuteJumpStartEvent);
            _playerInput.MoveAction.Subscribe(ExecuteMoveEvent);
            _playerInput.DashStartAction.Subscribe(ExecuteDashStartEvent);
        }
    }
    
    public partial class PlayerManager
    {
        private async UniTaskVoid Dash(Vector2 dashDirection, float dashDuration)
        {
            _dashStartSubject.OnNext(dashDirection * _playerProperties.DashForceMagnitude);

            await UniTask.Delay(TimeSpan.FromSeconds(dashDuration), ignoreTimeScale: false);
            
            _dashEndSubject.OnNext();
        }
    }
}

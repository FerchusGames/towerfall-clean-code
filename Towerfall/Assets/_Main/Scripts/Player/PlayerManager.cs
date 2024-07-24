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


        private void PassJumpStartEvent()
        {
            _jumpStartSubject.OnNext(_playerProperties.JumpForceMagnitude);
        }

        private void PassMoveEvent(float moveDirection)
        {
            moveDirection *= _playerProperties.MoveAccelerationRate;
            _moveSubject.OnNext(moveDirection);
        }

        private void PassDashStartEvent(Vector2 dashDirection)
        {
            Dash(dashDirection, _playerProperties.DashDuration).Forget();
        }
    }

    public partial class PlayerManager : IInitializable
    {
        public void Initialize() 
        {
            _playerInput.JumpStart.Subscribe(PassJumpStartEvent);
            _playerInput.Move.Subscribe(PassMoveEvent);
            _playerInput.DashStart.Subscribe(PassDashStartEvent);
        }
    }
    
    public partial class PlayerManager
    {
        private async UniTaskVoid Dash(Vector2 dashDirection, float dashDuration)
        {
            dashDirection *= _playerProperties.DashForceMagnitude;
            _dashStartSubject.OnNext(dashDirection);

            await UniTask.Delay(TimeSpan.FromSeconds(dashDuration), ignoreTimeScale: false);
            
            _dashEndSubject.OnNext();
        }
    }
}

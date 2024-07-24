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
        private Subject<float> _runSubject = new Subject<float>();
        private Subject<Vector2> _dashStartSubject = new Subject<Vector2>();

        private Subject<Unit> _dashEndSubject = new Subject<Unit>();
        
        public IObservable<float> JumpStart => _jumpStartSubject.AsObservable();
        public IObservable<float> Run => _runSubject.AsObservable();
        public IObservable<Vector2> DashStart => _dashStartSubject.AsObservable();
        public IObservable<Unit> DashEnd => _dashEndSubject.AsObservable();


        private void ExecuteJumpStartEvent()
        {
            _jumpStartSubject.OnNext(_playerProperties.JumpForceMagnitude);
        }

        private void ExecuteRunEvent(float runDirection)
        {
            _runSubject.OnNext(runDirection * _playerProperties.RunAccelerationRate);
        }

        private void ExecuteDashStartEvent(Vector2 dashDirection)
        {
            Dash(dashDirection).Forget();
        }
    }

    public partial class PlayerManager : IInitializable
    {
        public void Initialize() 
        {
            _playerInput.JumpStartAction.Subscribe(ExecuteJumpStartEvent);
            _playerInput.RunAction.Subscribe(ExecuteRunEvent);
            _playerInput.DashStartAction.Subscribe(ExecuteDashStartEvent);
        }
    }
    
    public partial class PlayerManager
    {
        private async UniTaskVoid Dash(Vector2 dashDirection)
        {
            _dashStartSubject.OnNext(dashDirection * _playerProperties.DashSpeed);

            await UniTask.Delay(TimeSpan.FromSeconds(_playerProperties.DashDuration), ignoreTimeScale: false);
            
            _dashEndSubject.OnNext();
        }
    }
}

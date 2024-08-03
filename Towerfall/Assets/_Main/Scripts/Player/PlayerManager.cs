using System;
using Cysharp.Threading.Tasks;
using Towerfall.Controllers;
using Towerfall.Managers.Properties;
using UniRx;
using UnityEngine;
using Zenject;

namespace Towerfall.Managers
{
    public partial class PlayerManager : IPlayerControllerInput
    {
        [Inject] private IPlayerInput _playerInput;

        private Subject<float> _jumpStartSubject = new Subject<float>();
        private Subject<float> _runSubject = new Subject<float>();
        private Subject<Vector2> _dashStartSubject = new Subject<Vector2>();
        
        public IObservable<float> JumpStart => _jumpStartSubject.AsObservable();
        public IObservable<float> Run => _runSubject.AsObservable();
        public IObservable<Vector2> DashStart => _dashStartSubject.AsObservable();
        
        public void SetPlayerControllerData(IPlayerControllerData playerControllerData)
        {
            _playerControllerData = playerControllerData;
        }
        
        private void ExecuteJumpStartEvent()
        {
            _jumpStartSubject.OnNext(_playerProperties.JumpForceMagnitude);
        }

        private void ExecuteRunEvent(float runDirection)
        {
            _runSubject.OnNext(GetRunAcceleration(runDirection));
        }

        private void ExecuteDashStartEvent(Vector2 dashDirection)
        {
            Dash(dashDirection).Forget();
        }
    }

    public partial class PlayerManager : IPlayerControllerEvent
    {
        [Inject] private IPlayerProperties _playerProperties;
        
        private Subject<Unit> _dashEndSubject = new Subject<Unit>();
        
        public IObservable<Unit> DashEnd => _dashEndSubject.AsObservable();
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

    public partial class PlayerManager : ITickable
    {
        public void Tick()
        {
            LastOnGroundTime -= Time.deltaTime;
        }
    }
    
    public partial class PlayerManager
    {
        private IPlayerControllerData _playerControllerData;

        private float LastOnGroundTime = 0;

        private bool IsJumping = false;
        private bool IsJumpFalling = false;
        
        private async UniTaskVoid Dash(Vector2 dashDirection)
        {
            _dashStartSubject.OnNext(dashDirection * _playerProperties.DashSpeed);

            await UniTask.Delay(TimeSpan.FromSeconds(_playerProperties.DashDuration), ignoreTimeScale: false);
            
            _dashEndSubject.OnNext();
        }

        private float GetRunAcceleration(float runDirection)
        {
            float targetSpeed = runDirection * _playerProperties.RunMaxSpeed;
            
            #region CALCULATING ACCELERATION RATE

            float accelerationRate;

            // Our acceleration rate will differ depending on if we are trying to accelerate or if we are trying to stop completely.
            // It will also change if we are in the air or if we are grounded.

            if (LastOnGroundTime > 0)
            {
                accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f) 
                    ? _playerProperties.RunAccelerationRate 
                    : _playerProperties.RunDecelerationRate;
            }

            else
            {
                accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f)
                    ? _playerProperties.RunAccelerationRate * _playerProperties.AirAccelerationMultiplier
                    : _playerProperties.RunDecelerationRate * _playerProperties.AirDecelerationMultiplier;
            }

            #endregion

            #region ADD BONUS JUMP APEX ACCELERATION

            if ((IsJumping || IsJumpFalling) && Mathf.Abs(_playerControllerData.RigidbodyVelocity.y) < _playerProperties.JumpHangTimeThreshold)
            {
                accelerationRate *= _playerProperties.JumpHangAccelerationMultiplier;
                targetSpeed *= _playerProperties.JumpHangMaxSpeedMultiplier;
            }

            #endregion

            float speedDifference = targetSpeed - _playerControllerData.RigidbodyVelocity.x;

            float acceleration = speedDifference * accelerationRate;

            return acceleration;
        }
    }
}

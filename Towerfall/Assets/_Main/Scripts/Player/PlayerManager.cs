using System;
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
        [Inject] private IPlayerProperties _playerProperties;

        private Subject<float> _jumpSubject = new Subject<float>();
        private Subject<Vector2> _moveSubject = new Subject<Vector2>();
        
        public IObservable<float> Jump => _jumpSubject.AsObservable();
        public IObservable<Vector2> Move => _moveSubject.AsObservable();
        
        private void PassJumpEvent()
        {
            _jumpSubject.OnNext(_playerProperties.JumpForceMagnitude);
        }

        private void PassMoveEvent(Vector2 moveDirection)
        {
            moveDirection.x *= _playerProperties.MoveAccelerationRate;
            _moveSubject.OnNext(moveDirection);
        }
    }

    public partial class PlayerManager : IInitializable
    {
        public void Initialize() 
        {
            _playerInput.Jump.Subscribe(PassJumpEvent);
            _playerInput.Move.Subscribe(PassMoveEvent);
        }
    }
}

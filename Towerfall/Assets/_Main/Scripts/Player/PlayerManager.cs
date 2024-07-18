using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Towerfall.Controllers;
using UniRx;
using UnityEngine;
using Zenject;

namespace Towerfall.Managers
{
    public partial class PlayerManager : IPlayerControllerInput
    {
        [Inject] private IPlayerInput _playerInput;
        
        public IObservable<Unit> Jump => PassJumpEvent();
        public IObservable<Vector2> Move => PassMoveEvent();

        private IObservable<Unit> PassJumpEvent()
        {
            // Confused on how to pass a different value
            return _playerInput.Jump;
        }

        private IObservable<Vector2> PassMoveEvent()
        {
            // Confused on how to pass a different value
            return _playerInput.Move;
        }
    }

    public partial class PlayerManager
    {
        private readonly float _jumpForceMagnitude;
        private readonly float _moveAccelerationRate;

        private Vector2 _currentMoveAccelerationRate;
        
        public PlayerManager(float jumpForceMagnitude, float moveAccelerationRate)
        {
            _jumpForceMagnitude = jumpForceMagnitude;
            _moveAccelerationRate = moveAccelerationRate;
            
            _playerInput.Move.Subscribe(move => _currentMoveAccelerationRate = move);
        }

        public Vector2 GetJumpForce()
        {
            return Vector2.up * _jumpForceMagnitude;
        }

        public Vector2 GetMoveAcceleration()
        {
            return Vector2.right * _currentMoveAccelerationRate; 
        }
    }
}

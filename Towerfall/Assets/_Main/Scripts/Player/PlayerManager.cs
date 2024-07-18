using System;
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
            return _playerInput.Jump;
        }

        private IObservable<Vector2> PassMoveEvent()
        {
            return _playerInput.Move;
        }
    }
}

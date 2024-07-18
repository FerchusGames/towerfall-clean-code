using System;
using Towerfall.Controllers;
using UniRx;
using Zenject;

namespace Towerfall.Managers
{
    public partial class PlayerManager : IPlayerControllerInput
    {
        [Inject] private IPlayerInput _playerInput;

        public IObservable<Unit> Jump => PassJumpEvent();

        private IObservable<Unit> PassJumpEvent()
        {
            return _playerInput.Jump;
        }
    }
}

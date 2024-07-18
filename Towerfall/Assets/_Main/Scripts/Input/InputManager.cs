using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Towerfall.Managers
{
    public partial class InputManager : ITickable
    {
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpSubject.OnNext();
            }
        }
    }

    public partial class InputManager : IPlayerInput
    {
        private readonly Subject<Unit> _jumpSubject = new Subject<Unit>();

        public IObservable<Unit> Jump => _jumpSubject.AsObservable();
    }
}

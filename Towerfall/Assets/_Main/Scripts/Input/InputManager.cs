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
            
            _moveSubject.OnNext(Input.GetAxisRaw("Horizontal"));
        }
    }

    public partial class InputManager : IPlayerInput
    {
        private readonly Subject<Unit> _jumpSubject = new Subject<Unit>();
        private readonly Subject<float> _moveSubject = new Subject<float>(); 

        public IObservable<Unit> Jump => _jumpSubject.AsObservable();
        public IObservable<float> Move => _moveSubject.AsObservable();
    }
}

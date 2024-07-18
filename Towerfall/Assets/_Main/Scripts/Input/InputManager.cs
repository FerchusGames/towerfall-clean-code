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
            
            _moveSubject.OnNext(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }

    public partial class InputManager : IPlayerInput
    {
        private readonly Subject<Unit> _jumpSubject = new Subject<Unit>();
        private readonly Subject<Vector2> _moveSubject = new Subject<Vector2>();

        public IObservable<Unit> Jump => _jumpSubject.AsObservable();
        public IObservable<Vector2> Move => _moveSubject.AsObservable();
    }
}

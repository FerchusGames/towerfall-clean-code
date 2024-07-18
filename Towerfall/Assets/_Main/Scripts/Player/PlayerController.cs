using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Towerfall.Controllers
{
    public interface IPlayerControllerInput
    {
        IObservable<Unit> Jump { get; }
        IObservable<Vector2> Move { get; }
    }
    
    public class PlayerController : MonoBehaviour
    {
        [Inject] private IPlayerControllerInput _playerControllerInput;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        private void Start()
        {
            _playerControllerInput.Jump.Subscribe(Jump).AddTo(this);
            _playerControllerInput.Move.Subscribe(Move).AddTo(this);
        }

        private void Jump()
        {
            // TODO: Get force directly from PlayerManager
            //_rigidbody2D.AddForce({Force}, ForceMode2D.Impulse);
        }

        private void Move(Vector2 value)
        {
            // TODO: Get acceleration directly from PlayerManager
            //_rigidbody2D.AddForce({Acceleration}, ForceMode2D.Force);
        }
    }
}

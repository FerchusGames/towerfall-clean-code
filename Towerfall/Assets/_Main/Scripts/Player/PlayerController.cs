using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Towerfall.Controllers
{
    public interface IPlayerControllerInput
    {
        IObservable<float> Jump { get; }
        IObservable<float> Move { get; }
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

        private void Jump(float jumpForce)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void Move(float moveAcceleration)
        {
            _rigidbody2D.AddForce(Vector2.right * moveAcceleration, ForceMode2D.Force);
        }
    }
}

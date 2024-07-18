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
        [SerializeField] private PlayerPropertiesSO _playerProperties;
        private void Start()
        {
            _playerControllerInput.Jump.Subscribe(Jump).AddTo(this);
            _playerControllerInput.Move.Subscribe(Move).AddTo(this);
        }

        private void Jump()
        {
            _rigidbody2D.AddForce(Vector2.up * _playerProperties.JumpForce, ForceMode2D.Impulse);
        }

        private void Move(Vector2 value)
        {
            _rigidbody2D.AddForce(Vector2.right * value.x * _playerProperties.MoveAcceleration, ForceMode2D.Force);
        }
    }
}

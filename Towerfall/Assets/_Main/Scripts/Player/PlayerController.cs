using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Towerfall.Controllers
{
    public interface IPlayerControllerInput
    {
        IObservable<float> JumpStart { get; }
        IObservable<float> Move { get; }
        IObservable<Vector2> DashStart { get; }
    }

    public interface IPlayerControllerEvent
    {
        IObservable<Unit> DashEnd { get; }
    }
    
    public class PlayerController : MonoBehaviour
    {
        [Inject] private IPlayerControllerInput _playerControllerInput;
        [Inject] private IPlayerControllerEvent _playerControllerEvent;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        private void Start()
        {
            _playerControllerInput.JumpStart.Subscribe(JumpStart).AddTo(this);
            _playerControllerInput.Move.Subscribe(Move).AddTo(this);
            _playerControllerInput.DashStart.Subscribe(DashStart).AddTo(this);

            _playerControllerEvent.DashEnd.Subscribe(DashEnd).AddTo(this);
        }

        private void JumpStart(float jumpForce)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void Move(float moveAcceleration)
        {
            _rigidbody2D.AddForce(Vector2.right * moveAcceleration, ForceMode2D.Force);
        }

        private void DashStart(Vector2 dashForce)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(dashForce, ForceMode2D.Impulse);
        }

        private void DashEnd()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}

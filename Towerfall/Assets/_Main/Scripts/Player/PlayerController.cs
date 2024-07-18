using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Towerfall.Controllers
{
    public interface IPlayerControllerInput
    {
        IObservable<Unit> Jump { get; }
    }
    
    public class PlayerController : MonoBehaviour
    {
        [Inject] private IPlayerControllerInput _playerControllerInput;

        private void Start()
        {
            _playerControllerInput.Jump.Subscribe(Jump).AddTo(this);
        }

        private void Jump()
        {
            Debug.Log("Salto");
        }
    }
}

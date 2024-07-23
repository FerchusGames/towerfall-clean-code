using UnityEngine;
using Zenject;

namespace Towerfall.Managers.Properties
{
    public interface IPlayerProperties
    {
        public float JumpForceMagnitude { get; }
        public float MoveAccelerationRate { get; } 
    }
    
    [CreateAssetMenu(menuName = "Scriptable Objects/PlayerProperties", fileName = "PlayerProperties")]
    public class PlayerProperties : ScriptableObject, IPlayerProperties
    {
        [field:SerializeField] public float JumpForceMagnitude { get; private set; }
        [field:SerializeField] public float MoveAccelerationRate { get; private set; }
    }
}

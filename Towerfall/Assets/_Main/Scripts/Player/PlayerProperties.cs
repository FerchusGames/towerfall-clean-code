using UnityEngine;

namespace Towerfall.Managers.Properties
{
    public interface IPlayerProperties
    {
        public float MoveAccelerationRate { get; }
        
        public float JumpForceMagnitude { get; }
        
        public float DashForceMagnitude { get; }
        public float DashDuration { get; }
    }
    
    [CreateAssetMenu(menuName = "Scriptable Objects/PlayerProperties", fileName = "PlayerProperties")]
    public class PlayerProperties : ScriptableObject, IPlayerProperties
    {
        [field:Header("Movement")]
        [field:SerializeField] public float MoveAccelerationRate { get; private set; }

        
        [field:Header("Jump")]
        [field:SerializeField] public float JumpForceMagnitude { get; private set; }
        
        [field:Header("Dash")]
        [field:SerializeField] public float DashForceMagnitude { get; private set; }
        [field:SerializeField] public float DashDuration { get; private set; }
    }
}

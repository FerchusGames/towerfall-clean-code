using UnityEngine;

namespace Towerfall.Managers.Properties
{
    public interface IPlayerProperties
    {
        public PlayerMovementProperties Movement { get; }
        public PlayerJumpProperties Jump { get; }
        public PlayerDashProperties Dash { get; }
        public PlayerCombatProperties Combat { get; }
        public PlayerGravityProperties Gravity { get; }
    }
    
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerProperties/PlayerProperties", fileName = "PlayerProperties")]
    public class PlayerProperties : ScriptableObject, IPlayerProperties
    {
        [field:SerializeField] public PlayerMovementProperties Movement { get; private set; }
        [field:SerializeField] public PlayerJumpProperties Jump { get; private set; }
        [field:SerializeField] public PlayerDashProperties Dash { get; private set; }
        [field:SerializeField] public PlayerCombatProperties Combat { get; private set; }
        [field:SerializeField] public PlayerGravityProperties Gravity { get; private set; }
    }
}

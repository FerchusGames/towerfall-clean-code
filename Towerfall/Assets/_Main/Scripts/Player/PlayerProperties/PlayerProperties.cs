using UnityEngine;

namespace Towerfall.Managers.Properties
{
    public interface IPlayerProperties
    {
        public IPlayerMovementProperties Movement { get; }
        public IPlayerJumpProperties Jump { get; }
        public IPlayerDashProperties Dash { get; }
        public IPlayerCombatProperties Combat { get; }
        public IPlayerGravityProperties Gravity { get; }
    }
    
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerProperties", fileName = "PlayerProperties")]
    public class PlayerProperties : ScriptableObject, IPlayerProperties
    {
        [field:SerializeField] public IPlayerMovementProperties Movement { get; private set; }
        [field:SerializeField] public IPlayerJumpProperties Jump { get; private set; }
        [field:SerializeField] public IPlayerDashProperties Dash { get; private set; }
        [field:SerializeField] public IPlayerCombatProperties Combat { get; private set; }
        [field:SerializeField] public IPlayerGravityProperties Gravity { get; private set; }
    }
}

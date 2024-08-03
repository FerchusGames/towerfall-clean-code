using UnityEngine;

namespace Towerfall.Managers.Properties
{
    public interface IPlayerCombatProperties
    {
        public float ArrowSpawnInterval { get; }
        public float AimThresholdTime { get; }
    }
    
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerProperties/Modules", fileName = "CombatProperties")]
    public class PlayerCombatProperties : ScriptableObject, IPlayerCombatProperties
    {
        [field:SerializeField] public float ArrowSpawnInterval { get; private set; }
        [field:SerializeField] public float AimThresholdTime { get; private set; }
    }
}

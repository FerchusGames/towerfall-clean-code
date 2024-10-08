using UnityEngine;

namespace Towerfall.Managers.Properties
{
    public interface IPlayerMovementProperties
    {
        public float RunMaxSpeed { get; }
        public float RunAccelerationRate { get; }
        public float RunDecelerationRate { get; }
        public float AirAccelerationMultiplier { get; }
        public float AirDecelerationMultiplier { get; }
    }

    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerProperties/Modules/MovementProperties", fileName = "MovementProperties")]
    public class PlayerMovementProperties : ScriptableObject, IPlayerMovementProperties
    {
        [field: SerializeField] public float RunMaxSpeed { get; private set; }
        [field: SerializeField] public float RunAccelerationRate { get; private set; }
        [field: SerializeField] public float RunDecelerationRate { get; private set; }
        [field: SerializeField] public float AirAccelerationMultiplier { get; private set; }
        [field: SerializeField] public float AirDecelerationMultiplier { get; private set; }
    }

}
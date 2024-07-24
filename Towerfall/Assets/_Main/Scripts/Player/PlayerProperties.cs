using UnityEngine;

namespace Towerfall.Managers.Properties
{
    public interface IPlayerProperties
    {
        // Acceleration
        public float RunMaxSpeed { get; }
        public float RunAccelerationRate { get; }
        public float RunDecelerationRate { get; }
        public float AirAccelerationMultiplier { get; }
        public float AirDecelerationMultiplier { get; }
        
        
        // Jumping
        public float JumpForceMagnitude { get; }
        public float CoyoteTime { get; }
        public float JumpInputBufferTime { get; }
        public float JumpHangTimeThreshold { get; }
        public float JumpHangAccelerationMultiplier { get; }
        public float JumpHangMaxSpeedMultiplier { get; }
        
        // Dashing
        public float DashSpeed { get; }
        public float DashDuration { get; }
        public float DashHangTime { get; }
        public float DashCooldown { get; }
        
        // Combat
        public float ArrowSpawnInterval { get; }
        public float AimThresholdTime { get; }
    }
    
    [CreateAssetMenu(menuName = "Scriptable Objects/PlayerProperties", fileName = "PlayerProperties")]
    public class PlayerProperties : ScriptableObject, IPlayerProperties
    {
        [field:Header("Acceleration")]
        [field:SerializeField] public float RunMaxSpeed { get; private set; }
        [field:SerializeField] public float RunAccelerationRate { get; private set; }
        [field:SerializeField] public float RunDecelerationRate { get; private set; }
        [field:SerializeField] public float AirAccelerationMultiplier { get; private set; }
        [field:SerializeField] public float AirDecelerationMultiplier { get; private set; }
        
        [field:Header("Jump")]
        [field:SerializeField] public float JumpForceMagnitude { get; private set; }
        [field:SerializeField] public float CoyoteTime { get; private set; }
        [field:SerializeField] public float JumpInputBufferTime { get; private set; }
        [field:SerializeField] public float JumpHangTimeThreshold { get; private set; }
        [field:SerializeField] public float JumpHangAccelerationMultiplier { get; private set; }
        [field:SerializeField] public float JumpHangMaxSpeedMultiplier { get; private set; }

        [field:Header("Dash")]
        [field:SerializeField] public float DashSpeed { get; private set; }
        [field:SerializeField] public float DashDuration { get; private set; }
        [field:SerializeField] public float DashHangTime { get; private set; }
        [field:SerializeField] public float DashCooldown { get; private set; }
        
        [field:Header("Combat")]
        [field:SerializeField] public float ArrowSpawnInterval { get; private set; }
        [field:SerializeField] public float AimThresholdTime { get; private set; }
    }
}

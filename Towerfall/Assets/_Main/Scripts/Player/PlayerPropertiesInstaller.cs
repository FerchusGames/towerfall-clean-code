using Towerfall.Managers;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Scriptable Objects/PlayerProperties", fileName = "PlayerProperties")]
public class PlayerPropertiesInstaller : ScriptableObjectInstaller<PlayerPropertiesInstaller>
{
    [field:SerializeField] public float JumpForceMagnitude { get; private set; }
    [field:SerializeField] public float MoveAccelerationRate { get; private set; }

    public override void InstallBindings()
    {
        Container.BindInstances(JumpForceMagnitude, MoveAccelerationRate);
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Properties", fileName = "Player Properties")]
public class PlayerPropertiesSO : ScriptableObject
{
    [field:SerializeField] public float JumpForce { get; private set; }
    [field:SerializeField] public float MoveAcceleration { get; private set; }
}

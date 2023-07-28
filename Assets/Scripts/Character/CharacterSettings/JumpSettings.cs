using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpSettings", menuName = "ScriptableObjects/Character/Jump")]
public class JumpSettings : ScriptableObject
{
    [SerializeField] private string groundTag;
    [SerializeField] private float power = 5;
    [SerializeField] private float speededFallPower = 3;

    public string GroundTag { get => groundTag; }
    public float JumpPower { get => power; }
    public float SpeededFallPower { get => speededFallPower; }
}

using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="MoveSettings",menuName ="ScriptableObjects/Character/Move")]
public class MoveSettings : ScriptableObject
{
    [SerializeField] private float leftLaneOffset = -2;
    [SerializeField] private float rightLaneOffset = 2;
    [SerializeField] private float changingLaneSpeed = 10;
    [SerializeField] private float startSpeed = 2;
    [SerializeField] private float acceleration = 0.1f;

    public float LeftLaneOffset { get => leftLaneOffset; }
    public float RightLaneOffset { get => rightLaneOffset;  }
    public float ChangingLaneSpeed { get => changingLaneSpeed;  }
    public float StartSpeed { get => startSpeed; }
    public float Acceleration { get => acceleration; }
}
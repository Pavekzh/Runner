using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationSettings", menuName = "ScriptableObjects/Character/Animations")]
public class AnimationSettings : ScriptableObject
{
    [SerializeField] private string runTrigger = "Run";
    [SerializeField] private string jumpTrigger = "Jump";
    [SerializeField] private string rollTrigger = "Roll";
    [SerializeField] private string dieTrigger = "Die";
    [SerializeField] private string reviveTrigger = "Revive";

    public string RunTrigger { get => runTrigger;  }
    public string JumpTrigger { get => jumpTrigger; }
    public string RollTrigger { get => rollTrigger;  }
    public string DieTrigger { get => dieTrigger; }
    public string ReviveTrigger { get => reviveTrigger;  }
}

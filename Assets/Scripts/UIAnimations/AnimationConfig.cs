using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "AnimationConfig",menuName ="ScriptableObjects/AnimationConfig")]
public class AnimationConfig : ScriptableObject
{
    [SerializeField] private Ease easeFunction;
    [SerializeField] private float duration;

    public Ease EaseFuncition { get => easeFunction; }
    public float Duration { get => duration; }
}

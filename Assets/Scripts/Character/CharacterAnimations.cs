using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string runTrigger = "Run";
    [SerializeField] private string jumpTrigger = "Jump";
    [SerializeField] private string rollTrigger = "Roll";
    [SerializeField] private string dieTrigger = "Die";
    [SerializeField] private string reviveTrigger = "Revive";

    public void Run()
    {
        animator.SetTrigger(runTrigger);
    }

    public void Jump()
    {
        animator.SetTrigger(jumpTrigger);
    }

    public void Roll()
    {
        animator.SetTrigger(rollTrigger);
    }

    public void Die()
    {
        animator.SetTrigger(dieTrigger);
    }

    public void Revive()
    {
        animator.SetTrigger(reviveTrigger);
    }
}
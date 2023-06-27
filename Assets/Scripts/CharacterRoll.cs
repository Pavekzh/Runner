using System;
using System.Collections;
using UnityEngine;

public class CharacterRoll:MonoBehaviour
{
    [SerializeField]private float rollTime;

    public Action OnRollEnd;

    private const float scaleMultiplier = 0.5f;

    private Coroutine RollCoroutine;

    public void Roll()
    {
        RollCoroutine = StartCoroutine(RollAnimation());
    }

    public void StopRoll()
    {
        if(RollCoroutine != null)
        {
            StopCoroutine(RollCoroutine);
            RevertAnimationChanges();
        }
    }

    private void RevertAnimationChanges()
    {
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y / scaleMultiplier, transform.localScale.z);
    }

    private IEnumerator RollAnimation()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * scaleMultiplier, transform.localScale.z);
        yield return new WaitForSeconds(rollTime);


        RevertAnimationChanges();        
        RollCoroutine = null;
        OnRollEnd?.Invoke();

    }
}

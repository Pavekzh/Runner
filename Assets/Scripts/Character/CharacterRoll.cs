using System;
using System.Collections;
using UnityEngine;

public class CharacterRoll:MonoBehaviour
{
    [SerializeField]private float rollTime;

    public Action OnRollEnd;

    private Coroutine RollCoroutine;

    public void Roll()
    {
        RollCoroutine = StartCoroutine(RollTimer());
    }

    public void StopRoll()
    {
        if(RollCoroutine != null)
        {
            StopCoroutine(RollCoroutine);
        }
    }


    private IEnumerator RollTimer()
    {
        yield return new WaitForSeconds(rollTime);

        RollCoroutine = null;
        OnRollEnd?.Invoke();

    }
}

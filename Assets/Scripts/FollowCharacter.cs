using System;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter:MonoBehaviour
{
    [SerializeField] private Character character;

    private void Start()
    {
        character.Move.OnMoved += CharacterMoved;
    }

    private void CharacterMoved(Vector3 delta)
    {
        transform.Translate(delta,Space.World);
    }
}

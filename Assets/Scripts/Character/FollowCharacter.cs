using System.Collections;
using UnityEngine;

public class FollowCharacter:MonoBehaviour
{
    [SerializeField] private Character character;

    private void Start()
    {
        character.Move.OnRun += Run;
        character.Move.OnChangingLane += ChangingLane;
    }

    private void ChangingLane(Vector3 delta)
    {
        transform.Translate(delta);
    }

    private void Run(Vector3 delta)
    {
        transform.Translate(delta,Space.World);
    }


}

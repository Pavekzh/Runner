using System;
using UnityEngine;

public class ScoreCounter:MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform player;
    [SerializeField] float scoreMultiplier = 1;

    public float RawDistance
    {
        get
        {
            return player.position.z - startPoint.position.z;
        }
    }

    public int Score
    {
        get
        {
            if (RawDistance < 0)
                return 0;

            return (int)(RawDistance * scoreMultiplier);
        }
    }
}


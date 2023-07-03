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
            float distance = player.position.z - startPoint.position.z;
            if (distance < 0)
                return 0;

            return distance;
        }
    }

    public int Score
    {
        get
        {
            return (int)(RawDistance * scoreMultiplier);
        }
    }
}


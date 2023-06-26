using System;
using UnityEngine;

public class RunDistanceCounter:MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform player;

    public float Distance
    {
        get
        {
            Vector3 playerPositionXZ = new Vector3(player.position.x, 0, player.position.z);
            Vector3 startPointPositionXZ = new Vector3(startPoint.position.x, 0, startPoint.position.z);

            return Vector3.Distance(playerPositionXZ, startPointPositionXZ);
        }
    }
}


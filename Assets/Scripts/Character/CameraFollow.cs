using UnityEngine;

public class CameraFollow:MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private bool ignoreY = false;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }


    private void Update()
    {
        Vector3 newPosition = new Vector3();
        newPosition.x = target.position.x + offset.x;
        newPosition.z = target.position.z + offset.z;

        if (ignoreY)
            newPosition.y = transform.position.y;
        else
            newPosition.y = target.position.y + offset.y;

        transform.position = newPosition;
    }
}

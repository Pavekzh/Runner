using UnityEngine;

public class CharacterJump:MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float Power = 5;

    public LayerMask GroundLayers { get => groundLayers; }

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * Power, ForceMode.VelocityChange);
    }
}


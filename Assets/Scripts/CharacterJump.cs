using UnityEngine;

public class CharacterJump:MonoBehaviour
{
    [SerializeField] private int groundLayer;
    [SerializeField] private float Power = 5;

    public int GroundLayer { get => groundLayer; }

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


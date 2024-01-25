using UnityEngine;

public class Movement : MonoBehaviour
{
    protected Rigidbody rb;
    public float movementSpeed = 1f;
    public float maxSpeed = 10f; 

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

}

using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InputAction thrust;

    Rigidbody rb;

    [SerializeField] float thrustStrength = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        thrust.Enable();
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        if (thrust.IsPressed())
        {
            // rb.AddRelativeForce(0, 1 * Time.fixedDeltaTime, 0);
            Debug.Log("thrust is pressed");
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime );
        }
    }
}

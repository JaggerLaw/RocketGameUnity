using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;

    Rigidbody rb;

    [SerializeField] float thrustStrength = 3f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        Thrust();
        Rotation();

       
    }

    private void Thrust()
    {
        if (thrust.IsPressed())
        {
            // rb.AddRelativeForce(0, 1 * Time.fixedDeltaTime, 0);
            Debug.Log("thrust is pressed");
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }

    private void Rotation()
    {

        float rotationValue = rotation.ReadValue<float>();
        Debug.Log("RotationValue after: " + rotationValue);

        if (rotationValue == 1)
        {
            rb.AddRelativeTorque(0, 0, -1);
        }
        else if (rotationValue == -1)
        {
            rb.AddRelativeTorque(0, 0, 1);

        }
    }
}

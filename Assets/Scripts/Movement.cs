using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    AudioSource audioSource;
    [SerializeField] AudioClip thrustSound;

    [SerializeField] ParticleSystem mainThruster;
    [SerializeField] ParticleSystem leftSideThruster;
    [SerializeField] ParticleSystem rightSideThruster;
    

    Rigidbody rb;

    [SerializeField] float thrustStrength = 3f;
    [SerializeField] float rotationStrength = 100f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        if (!audioSource.isPlaying)
        {
            //Audio source is thruster noise
            audioSource.PlayOneShot(thrustSound);
        }

        mainThruster.Play();

        // rb.AddRelativeForce(0, 1 * Time.fixedDeltaTime, 0);
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
    }
    void StopThrusting()
    {
        audioSource.Stop();
        mainThruster.Stop();
    }

    private void Rotation()
    {

        float rotationValue = rotation.ReadValue<float>();

        if (rotationValue == 1)
        {
            RotateRight();
        }
        else if (rotationValue == -1)
        {
            RotateLeft();
        }
        else if (rotationValue == 0)
        {
            StopRotation();
        }
    }

    void RotateRight()
    {
        leftSideThruster.Play();
        ApplyRotation(Vector3.back);
    }
    void RotateLeft()
    {
        rightSideThruster.Play();
        ApplyRotation(Vector3.forward);
    }
    void StopRotation()
    {
        leftSideThruster.Stop();
        rightSideThruster.Stop();
    }

    void ApplyRotation(Vector3 rot)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotationStrength * Time.fixedDeltaTime * rot);
        rb.freezeRotation = false;
    }
}

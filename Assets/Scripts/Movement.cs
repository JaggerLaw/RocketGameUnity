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
            if (!audioSource.isPlaying)
            {    
                //Audio source is thruster noise
                audioSource.PlayOneShot(thrustSound);
            }
            
            mainThruster.Play();

            // rb.AddRelativeForce(0, 1 * Time.fixedDeltaTime, 0);
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
            
        } else
        {
            audioSource.Stop();
            mainThruster.Stop();
        }
    }

    private void Rotation()
    {

        float rotationValue = rotation.ReadValue<float>();

        if (rotationValue == 1)
        {
            // rb.AddRelativeTorque(Vector3.back);
            leftSideThruster.Play();
            ApplyRotation(Vector3.back);
        }        
        else if (rotationValue == -1)
        {
            // rb.AddRelativeTorque(Vector3.forward);
            rightSideThruster.Play();
            ApplyRotation(Vector3.forward);
        } else if (rotationValue == 0)
        {
            leftSideThruster.Stop();
            rightSideThruster.Stop();
        }
    }

    private void ApplyRotation(Vector3 rot)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotationStrength * Time.fixedDeltaTime * rot);
        rb.freezeRotation = false;
    }
}

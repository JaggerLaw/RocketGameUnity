using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InputAction thrust;

    void OnEnable()
    {
        thrust.Enable();
    }

    void Update()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("Propel!");
        }
    }
}

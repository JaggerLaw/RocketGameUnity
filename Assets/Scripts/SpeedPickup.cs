using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    Movement movementScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementScript = GetComponent<Movement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedItem"))
        {
            Destroy(other.gameObject);
            movementScript.thrustStrength+= 30;
        }  
    }
}

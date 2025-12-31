using UnityEngine;
using UnityEngine.Audio;

public class CollisionHandler : MonoBehaviour
{

    //add this in later with multiple audio clips
    // AudioSource destroy;

    void Start()
    {
        // destroy = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
            Debug.Log("Woop Woop this a friendly");
            break; 
            
            case "Fuel":
            Debug.Log("Refuled back to 100%");
            break;

            case "Finish":
            Debug.Log("Congrats thats a win");
            break;
            
            default:
            Debug.Log("Destroyed AHSHDASJDHAJ!!!!");
            break; 
        }
    }

}

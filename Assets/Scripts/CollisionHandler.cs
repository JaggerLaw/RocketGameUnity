using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //add this in later with multiple audio clips
    // AudioSource destroy;
    // SceneManager sceneManager;
    void Start()
    {
        // sceneManager = GetComponent<SceneManager>();
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
            LoadNextLevel();
            break;
            
            default:
            Debug.Log("Destroyed AHSHDASJDHAJ!!!!");
            ReloadLevel();
            break; 
        }

        void ReloadLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }

        void LoadNextLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            
            int nextScene = currentScene;

            if(currentScene == SceneManager.sceneCountInBuildSettings - 1)
            {
                nextScene = 0;
                SceneManager.LoadScene(nextScene);
            } else
            {
                SceneManager.LoadScene(nextScene + 1);
            }
        }
    }

}

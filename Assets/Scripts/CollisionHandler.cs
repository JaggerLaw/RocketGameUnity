using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delayDeath = 1f;
    [SerializeField] float delayNextLevel = 2f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip winSound;
    AudioSource audioSource;

    bool isControllable = true;

    //add this in later with multiple audio clips
    // SceneManager sceneManager;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {

        if (!isControllable) { return; }

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
                StartFinishSequence();
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayDeath);
    }

    void StartFinishSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayNextLevel);
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

        if (currentScene == SceneManager.sceneCountInBuildSettings - 1)
        {
            nextScene = 0;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            SceneManager.LoadScene(nextScene + 1);
        }
    }
}

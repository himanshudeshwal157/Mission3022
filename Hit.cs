using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hit : MonoBehaviour
{
    [SerializeField] AudioClip GameOver;
    [SerializeField] AudioClip LevelPassed;
    [SerializeField] ParticleSystem GameOverParticles;
    [SerializeField] ParticleSystem LevelPassedParticles;
    [SerializeField] float xValue = 2f;
    
    AudioSource audiosource;

    bool isTransitioning = false;
    bool CollisionDisabled = false;
   void Start()
   {
    audiosource = GetComponent<AudioSource>();
   }

   void Update()
   {
     CheatDebugKey();
   }

   void CheatDebugKey()
   {
     if (Input.GetKeyDown(KeyCode.L))
     {
        ReloadNextLevel();
     }
     else if (Input.GetKeyDown(KeyCode.X))
     {
        CollisionDisabled =!CollisionDisabled;
     }
   }
    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning || CollisionDisabled){return;}
        switch (other.gameObject.tag)
        {
            case "Friend":
                Debug.Log(" This is start point");
                break;
            case "Finish":
                Debug.Log(" Finish point");
                DelayInFinish();

                break;
            default:
                Debug.Log("Crash");
                NoCrashMovement();
                break;

        }
        
    }

    void DelayInFinish()
    {
        isTransitioning = true;
        audiosource.Stop();

        LevelPassedParticles.Play();

        audiosource.PlayOneShot(LevelPassed);
        GetComponent<Movements>().enabled = false;
        Invoke("ReloadNextLevel", xValue);

    }
    void NoCrashMovement()
    {
        isTransitioning = true;
        audiosource.Stop();

        GameOverParticles.Play();

        audiosource.PlayOneShot(GameOver);
        GetComponent<Movements>().enabled = false;
        Invoke("ReloadLevel", xValue);
    }

    void ReloadLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     void ReloadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex +1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }
 
}

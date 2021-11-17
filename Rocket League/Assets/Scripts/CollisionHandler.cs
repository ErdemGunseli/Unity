﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float crashDelay = 3f;
    [SerializeField] float nextLevelDelay = 3.75f;
    Rigidbody rigidbody;
    BoxCollider boxCollider;
    AudioSource audioSource;
    [SerializeField] AudioClip crashNoise;
    [SerializeField] AudioClip nextLevelNoise;

    [SerializeField] AudioClip friendlyObjectCrashNoise;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    

   

    bool isTransitioning = false;
    bool collsionEnabled = true;


    void Start() 
    {
        
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

    }

    void Update() 
    {
        RespondToDebugKeys();    
    }
    
    void RespondToDebugKeys()
    {   
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collsionEnabled = !collsionEnabled; //Toggles collision.
        }

    }
        
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || !collsionEnabled){return;} //This prevents going any further into the method.
            switch (other.gameObject.tag)
            {
                case ("Friendly"):
                    Debug.Log("You have collided with a safe object.");
                    break;
            
                case ("Finish"):
                    SuccessSequence();
                    break;
    
                default:                         
                    CrashSequence();
                    break;
            }
        
    }
  void OnParticleCollision(GameObject other) 
    {
       if (!isTransitioning && collsionEnabled)
       {
        isTransitioning = true;
        CrashSequence();
       }

    }
    void LoadNextLevel()
    {
       
         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
         int nextSceneIndex = currentSceneIndex + 1;

         
         
         if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
         {
             nextSceneIndex = 0;
         }
        
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);  
    }

    void CrashSequence()
    {
        isTransitioning = true;
        
        audioSource.Stop();

    
        audioSource.PlayOneShot(crashNoise, 3f);
        // Add partile effects upon crashing.
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", crashDelay);

        crashParticles.Play();
    }

    void SuccessSequence() 
    {
        isTransitioning = true;
        
        audioSource.Stop();

        audioSource.PlayOneShot(nextLevelNoise, 0.7f);
      
        GetComponent<Movement>().enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rigidbody. velocity = Vector3. zero;
        rigidbody. angularVelocity = Vector3. zero;
        
        Invoke("LoadNextLevel", nextLevelDelay);
        successParticles.Play();
    }
    
}
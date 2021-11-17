using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float yForce = 5000f;
    [SerializeField] float rotationThrust = 50f;
    AudioSource audioSource;
    [SerializeField] AudioClip mainEngine; 


    Rigidbody rb;
    [SerializeField] ParticleSystem downThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;

    bool processingThrust;
    bool processingRotation;


   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
         audioSource = GetComponent<AudioSource>();
        processingThrust = false;
        processingRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
     ProcessThrust();
     ProcessRotation();
     AudioManager();
    }
     
    void ProcessThrust()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.Space)))
        {  
            
             rb.AddRelativeForce(Vector3.up * yForce * Time.deltaTime);
            processingThrust = true;

            if (!downThrustParticles.isPlaying)
            {
                downThrustParticles.Play();
            }
           
        }  
        else
        {
            downThrustParticles.Stop();
            processingThrust = false;
        }
    }

    

    void AudioManager()
    {
        if (processingThrust || processingRotation)
        {
            if (!audioSource.isPlaying)
            {
                    audioSource.PlayOneShot(mainEngine,0.5f);
            }
        }
        else
        {
            audioSource.Pause();

        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) && (!Input.GetKey(KeyCode.D))) //If we are pressing left and not pressing right.
        {
            processingRotation = true;
            RotateLeft();
        }
        else if (!Input.GetKey(KeyCode.D)) //If we are no longer pressing left, stop the particles.
        {
            leftThrustParticles.Stop();
            processingRotation = false;
        }


        if (Input.GetKey(KeyCode.D) && (!Input.GetKey(KeyCode.A))) //If we are pressing right and not pressing left.
        {
            processingRotation = true;
            RotateRight();
        }
         else if (!Input.GetKey(KeyCode.A)) //If we are no longer pressing right, stop the particles.
            {
                rightThrustParticles.Stop();
               processingRotation = false;
            }

        
    }

    void RotateLeft() //Turning Left
    {
            ApplyRotation(rotationThrust);
            
            if (!leftThrustParticles.isPlaying) //Play left thruster particles if not playing already.
            {
             leftThrustParticles.Play();
            }
               
        }

    void RotateRight() //Turning Right
    {
            
            ApplyRotation(-rotationThrust);
            if (!rightThrustParticles.isPlaying) //Play right thruster particles if not playing already.
            {
                rightThrustParticles.Play();
            }
    }

    void ApplyRotation(float rotationThisFrame)
        {
            rb.freezeRotation = true; //Freezing the rotation so that the rocket cannot be manually rotated.
            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
            rb.freezeRotation = false; //Unfreezing the rotation so that the rocket can be manually rotated.
        }

}

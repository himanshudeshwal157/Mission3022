using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    [SerializeField] ParticleSystem RightThrustParticle;
    [SerializeField] ParticleSystem LeftThrustParticle;
    [SerializeField] ParticleSystem MainEngineParticle;
    Rigidbody rb;
    AudioSource audiosource; 
    [SerializeField] AudioClip EngineThrust;
    [SerializeField] float UpThrust = 10f;
    [SerializeField] float MovingDirection = 10f;
   

   
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
      

    }

    // Update is called once per frame
    void Update()
    {
       ProcessUp();
       ProcessMove();

        
    }
    void ProcessUp()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*UpThrust*Time.deltaTime);
            if(!audiosource.isPlaying)
            {
                audiosource.PlayOneShot(EngineThrust);
            }
          
            MainEngineParticle.Play(); 
    
           
        }
        else
        {
            audiosource.Stop();
            MainEngineParticle.Stop();

        }
        
    }
    void ProcessMove()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward* MovingDirection*Time.deltaTime);
            RightThrustParticle.Play();
           
        }
           
        
            
      
        else
        {
            RightThrustParticle.Stop();

        }
        

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward *MovingDirection*Time.deltaTime);
            LeftThrustParticle.Play();
        
           
        }

          
        
            
        
        else
        {
            LeftThrustParticle.Stop();
        }
            
            rb.freezeRotation = false;
       

        
    }

}

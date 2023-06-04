using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocalling : MonoBehaviour
{
    private AudioSource scaryaudio; // variables for audiosource

    
    private GameObject manager; // bring the manager object to play the audio.
   
    
    void Start()
    {
        scaryaudio= GetComponent<AudioSource>(); //bring the component
        manager = GameObject.FindWithTag("Manager");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) // if player hits the trigger box, it play the audio.
        {
          Debug.Log("Played!");
           
          manager.GetComponent<audiomanager>().dangercall(); //send message to audiomanager object to play sound smoothly. Otherwise it will stop because of destroy() below. I was tried to give audiosource as parameter. But it doesn't work. SO I just call the method.
            
          Destroy(gameObject); //destroy the trigger box, because if it is not destroyed. player will keep hearing the music when they move back and forth.
            
        }
    }
}

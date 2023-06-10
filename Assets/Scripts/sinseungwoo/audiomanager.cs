using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [SerializeField]
    private AudioSource danger; //variables for play the sounds.

    [SerializeField]
    private AudioSource choir;

    [SerializeField]
    private AudioSource breeze;


    

    public void dangercall() //get call from danger audio trigger box. 
    {
        Debug.Log("Got the sound!");
        danger.Play(); //play the sound
    }

    public void choircall() //get call from choir audio trigger box. 
    {
        Debug.Log("Got the sound!");
        choir.Play(); //play the sound
    }

    public void breezecall() //get call from breeze audio trigger box. 
    {
        Debug.Log("Got the sound!");
        breeze.Play(); //play the sound
    }

    
}

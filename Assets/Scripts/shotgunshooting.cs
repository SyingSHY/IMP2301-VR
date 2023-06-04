using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunshooting : MonoBehaviour
{
    private AudioSource shootsound; //variables for sound

    private bool isshoot = false; //bool variables for shooting

   

    [SerializeField]
    private GameObject Prefab; //prefab for bullet

    [SerializeField]
    private Transform muzzle; //transform for shooting position.

    private float speed = 20f; //speed of bullet

    // Start is called before the first frame update
    void Start()
    {
        shootsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f")) shoot(); //script for testing without occulus


        if (isshoot)
        {
            
            Debug.Log("shooting");

            
            GameObject spawnedBullet = Instantiate(Prefab, muzzle.position, muzzle.rotation);

            spawnedBullet.GetComponent<Rigidbody>().AddForce(speed * muzzle.forward, ForceMode.Impulse); //add force to bullet for shooting

            shootsound.Play(); //soundplay

            Destroy(spawnedBullet, 2); //destroy the bullet after some time passed.

            isshoot = false;

            Destroy(gameObject, 3);
            

           
        }

    }

    public void shoot()
    {
        isshoot = true; //when method calling by controller's activate button. 
    }

    
        
    

}

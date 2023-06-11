using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightadjusting : MonoBehaviour
{
    [SerializeField]
    private GameObject light; //get light object.

    [SerializeField]
    private float dynotorchfloat = 6f; // adjusting light's intensity

    private float activefloat;
    private bool isactivate = false; //controll the adding and reducing of intensity. they should do the job separately.
    
    

    // Update is called once per frame
    void Update()
    {
        if(!isactivate) //when press activate, reducing is not happen.
        {
            dynotorchfloat -= Time.deltaTime; //reduce the light intensity.
            light.GetComponent<Light>().intensity = dynotorchfloat;

            if (dynotorchfloat <= 0) //if intensity go below zero. It stays on the zero.
            {
                dynotorchfloat = 0;
            }


        }

        if(Input.GetKeyDown("x")) //오큘러스를 쓸때는 activate enter에 바로 플래시 액티브 넣기!
        {
            flashactivate();
        }

       if(isactivate)
        {
           
            
                isactivate = true; //while adding the intensity. the reducing is not happen.
                light.GetComponent<Light>().intensity = dynotorchfloat;

                dynotorchfloat += Time.deltaTime;

                if (dynotorchfloat >= 6f) //when intensity is enough, stop adding and start reducing.
                {
                    isactivate = false;
      
                }
            
        }
    }


    public void flashactivate() //when player hit activate in occulus. start adding the light.
    {
       
        isactivate= true;
       
    }
}

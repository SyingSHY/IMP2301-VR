using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketResult_K : MonoBehaviour
{


    public GameObject RedDoor;
    public GameObject BlueDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (SocketInteraction.bulbcount >= 3) { }
        //if (SocketInteraction.bulbcount >= 6) {
        //    Destroy(socketResult);
        //}
    }

    private void FixedUpdate()
    {
         if (SocketInteraction.bulbcount >= 3) {
            Destroy(BlueDoor);
        }
        if (SocketInteraction.bulbcount >= 6) {
            Destroy(RedDoor);
}
    }
    
}

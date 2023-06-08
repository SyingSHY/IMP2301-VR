using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketInteraction_K : MonoBehaviour
{


    public GameObject lightbulb;
    [SerializeField]
    public static int bulbcount = 0;

    [SerializeField]
    private int clearnum = 6;

    //[SerializeField]
    //private Transform target;


    //[SerializeField]
    //private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        //SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = target.position + Vector3.up*offset.y
        //     + target.right * offset.x
        //     + target.forward * offset.z;
    }

    //when we put something into the socket;
    public void ItemInserted(SelectEnterEventArgs args) {
        Debug.Log(args.interactableObject.transform.gameObject + "was inserted");
        bulbcount -= 1;
        Debug.Log(bulbcount);
        //if (clearnum >= bulbcount) {
        //    SpawnObject();
        //}
    }

    //when we remove the object from the socket
    public void ItemRemoved(SelectExitEventArgs args) {
        Debug.Log(args.interactableObject.transform.gameObject + "was removed");
        bulbcount += 1;
    }

    //private void SpawnObject()
    //{
    //    if (clearnum > bulbcount)
    //    {
    //        Instantiate(lightbulb, transform.position, Quaternion.identity);
    //    }
    //}

   


}

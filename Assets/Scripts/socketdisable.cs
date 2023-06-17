using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class socketdisable : MonoBehaviour
{
    // Start is called before the first frame update
    public void ItemInserted(SelectEnterEventArgs args)
    {
        // Debug.Log(args.interactableObject.transform.gameObject + " was inserted");
       
        args.interactable.GetComponent<BoxCollider>().enabled= false;

       

    }


    // when we remove the object from the socket
    public void ItemRemoved(SelectExitEventArgs args)
    {
    }
}

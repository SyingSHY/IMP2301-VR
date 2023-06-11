using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIController : MonoBehaviour
{
    public GameObject itemcube;
    public GameObject bc;          // bulbcountUI
    public GameObject BringBulbs;  // BringBulbs Text

    public bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpened)
        {
            bc.GetComponent<TextMeshProUGUI>().text = itemcube.GetComponent<gamamanage>().bulbcount.ToString() + "/6";
            if (itemcube.GetComponent<gamamanage>().bulbcount >= 6) 
                BringBulbs.GetComponent<TextMeshProUGUI>().text = "Open the Door!";
        }
    }
}

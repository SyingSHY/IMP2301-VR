using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIController : MonoBehaviour
{
    public GameObject itemcube;
    public GameObject numBulbs;
    public GameObject BringBulbs;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        numBulbs.GetComponent<TextMeshProUGUI>().text = itemcube.GetComponent<gamamanage>().bulbcount.ToString()+ "/6";
        if (itemcube.GetComponent<gamamanage>().bulbcount >= 6) BringBulbs.GetComponent<TextMeshProUGUI>().text = "Get out of here!";
    }
}

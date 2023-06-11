using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LeverActionHandler : MonoBehaviour
{
    [SerializeField]
    private AudioSource open; // open sound

    public void MaxLimit()
    {
        // if lever reached Max and bulbcount>=6, then open door
        gamamanage gm = GameObject.Find("itemcube").GetComponent<gamamanage>(); // get gamamanage
        if (gm.bulbcount >= 6&& GameObject.Find("GameUI").GetComponent<GameUIController>().isOpened==false)
        {
            GameObject.Find("GameUI").GetComponent<GameUIController>().BringBulbs.GetComponent<TextMeshProUGUI>().text = "Get out of here!";
            GameObject.Find("GameUI").GetComponent<GameUIController>().isOpened = true;
            Destroy(gm.escapedoor); //exit is open;
            open.Play();
        }
    }
    public void MinLimit()
    {
        gamamanage gm = GameObject.Find("itemcube").GetComponent<gamamanage>(); // get gamamanage
        if (gm.bulbcount >= 6&& GameObject.Find("GameUI").GetComponent<GameUIController>().isOpened==false)
        {
            GameObject.Find("GameUI").GetComponent<GameUIController>().BringBulbs.GetComponent<TextMeshProUGUI>().text = "Get out of here!";
            GameObject.Find("GameUI").GetComponent<GameUIController>().isOpened = true;
            Destroy(gm.escapedoor); //exit is open;
            open.Play();
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;

public class LeverActionHandler : MonoBehaviour
{
    public static bool doorOpenedCleared = false;

    [SerializeField]
    private AudioSource open; // open sound
    [SerializeField] GameObject clearLight;

    public void MaxLimit()
    {
        // if lever reached Max and bulbcount>=6, then open door
        gamamanage gm = GameObject.Find("itemcube").GetComponent<gamamanage>(); // get gamamanage
        if (gm.bulbcount >= 6&& GameObject.Find("GameUI").GetComponent<GameUIController>().isOpened==false)
        {
            GameObject.Find("GameUI").GetComponent<GameUIController>().BringBulbs.GetComponent<TextMeshProUGUI>().text = "Get out of here!";
            GameObject.Find("GameUI").GetComponent<GameUIController>().isOpened = true;

            StartCoroutine("DoorOpen");
            doorOpenedCleared = true;
            clearLight.SetActive(true);
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

            StartCoroutine("DoorOpen");
            doorOpenedCleared = true;
            clearLight.SetActive(true);
            open.Play();
        }
    }

    IEnumerator DoorOpen()
    {
        gamamanage gm = GameObject.Find("itemcube").GetComponent<gamamanage>(); // get gamamanage
        GameObject door = gm.escapedoor;

        while (door.transform.localPosition.y < 1.5f)
        {
            door.transform.Translate(Vector3.up * 0.05f);

            yield return new WaitForSeconds(0.05f);
        }

        Destroy(gm.escapedoor); //exit is fully open;
    }
}

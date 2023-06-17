using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escape : MonoBehaviour
{

    [SerializeField] private GameClearFadeOut gameoverFade;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Cleared!");
            gameoverFade.SendMessage("StartFadeOutAnim");
            
        }
    }
}

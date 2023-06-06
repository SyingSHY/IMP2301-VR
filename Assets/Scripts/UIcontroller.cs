using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    // Variables for UI component
    [SerializeField]
    private GameObject MainUI;  // Main UI: 4 buttons

    [SerializeField]
    private GameObject Title;   // Title text

    [SerializeField]
    private GameObject Sliders; // Option Slider

    [SerializeField]
    private GameObject Credit; // Credit text

    [SerializeField]
    private GameObject Back;   // Button to return menu
    public void onPlay()      // Pressing Play button
    {
        SceneManager.LoadScene("Mapscene");
    }
    public void onOption()    // Pressing Option Button
    {
        MainUI.SetActive(false);
        Title.SetActive(false);
        Sliders.SetActive(true);
        Credit.SetActive(false);
        Back.SetActive(true);
    }
    public void onCredit()    // Pressing Credit
    {
        MainUI.SetActive(false);
        Title.SetActive(false);
        Sliders.SetActive(false);
        Credit.SetActive(true);
        Back.SetActive(true);
    }

    public void onMain()    // Pressing Back 
    {
        MainUI.SetActive(true);
        Title.SetActive(true);
        Sliders.SetActive(false);
        Credit.SetActive(false);
        Back.SetActive(false);
    }
    public void onExit()     // Pressing Exit
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

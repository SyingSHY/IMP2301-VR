using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject MainUI;

    [SerializeField]
    private GameObject Title;

    [SerializeField]
    private GameObject Sliders;

    [SerializeField]
    private GameObject Credit;

    [SerializeField]
    private GameObject Back;
    public void onPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void onOption()
    {
        MainUI.SetActive(false);
        Title.SetActive(false);
        Sliders.SetActive(true);
        Credit.SetActive(false);
        Back.SetActive(true);
    }
    public void onCredit()
    {
        MainUI.SetActive(false);
        Title.SetActive(false);
        Sliders.SetActive(false);
        Credit.SetActive(true);
        Back.SetActive(true);
    }

    public void onMain()
    {
        MainUI.SetActive(true);
        Title.SetActive(true);
        Sliders.SetActive(false);
        Credit.SetActive(false);
        Back.SetActive(false);
    }
    public void onExit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

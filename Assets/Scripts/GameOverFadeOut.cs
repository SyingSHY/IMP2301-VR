using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverFadeOut : MonoBehaviour
{
    [SerializeField] private float fadeTime = 2.0f;

    private Image fadeImg;
    private bool isFadePlaying;
    private float time = 0f;
    private float start;
    private float end;

    void Awake()
    {
        fadeImg = GetComponent<Image>();
    }

    public void StartFadeOutAnim()
    {
        if (isFadePlaying == true) // No Duplicated Play
        {
            return;
        }

        start = 0f;
        end = 1f;

        StartCoroutine("fadeoutplay");    // Run Coroutine
    }

    IEnumerator fadeoutplay()
    {
        isFadePlaying = true;
        UnityEngine.Color fadecolor = fadeImg.color;
        time = 0f;
        while (fadecolor.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);

            fadeImg.color = fadecolor;

            yield return null;
        }

        isFadePlaying = false;
        SceneManager.LoadScene(2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonolithBubble : MonoBehaviour
{
    public Image[] TutorialImages;

    public TMPro.TMP_Text waveText;
    public TMPro.TMP_Text HUDwaveText;

    void Start()
    {
        foreach (Image image in TutorialImages)
            image.gameObject.SetActive(false);
        waveText.gameObject.SetActive(false);
        HUDwaveText.gameObject.SetActive(false);
        StartCoroutine(DisplayTutorial());
    }

    public void ShowWaveText(string text)
    {
        waveText.SetText(text);
        HUDwaveText.SetText(text);
        StartCoroutine(DisplayWaveText());
    }

    IEnumerator DisplayWaveText()
    {
        waveText.gameObject.SetActive(true);
        HUDwaveText.gameObject.SetActive(true);
        
        waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, 0);
        HUDwaveText.color = new Color(HUDwaveText.color.r, HUDwaveText.color.g, HUDwaveText.color.b, 0);
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, i);
            HUDwaveText.color = new Color(HUDwaveText.color.r, HUDwaveText.color.g, HUDwaveText.color.b, i);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(3);
        for (float i = 1; i > 0; i -= Time.deltaTime)
        {
            waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, i);
            HUDwaveText.color = new Color(HUDwaveText.color.r, HUDwaveText.color.g, HUDwaveText.color.b, i);
            yield return new WaitForEndOfFrame();
        }
        waveText.gameObject.SetActive(false);
        HUDwaveText.gameObject.SetActive(false);
    }
    
    IEnumerator DisplayTutorial()
    {
        yield return new WaitForSeconds(2);
        foreach (Image image in TutorialImages)
        {
            image.color = new Color(1, 1, 1, 0);
            image.gameObject.SetActive(true);
        }
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            foreach (Image image in TutorialImages)
            {
                image.color = new Color(1, 1, 1, i);
            }
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(10);
        for (float i = 1; i > 0; i -= Time.deltaTime)
        {
            foreach (Image image in TutorialImages)
            {
                image.color = new Color(1, 1, 1, i);
            }
            yield return new WaitForEndOfFrame();
        }
        foreach (Image image in TutorialImages)
        {
            image.color = new Color(1, 1, 1, 0);
            image.gameObject.SetActive(true);
        }

        GameManager._instance.waveSystem.StartWaveCycle();
    }
}

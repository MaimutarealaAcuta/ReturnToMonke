using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonolithBubble : MonoBehaviour
{
    public Image SpeechBuble;
    public Image TutorialImage;
    
    void Start()
    {
        SpeechBuble.gameObject.SetActive(false);
        TutorialImage.gameObject.SetActive(false);
        StartCoroutine(DisplayTutorial());
    }

    IEnumerator DisplayTutorial()
    {
        yield return new WaitForSeconds(2);
        SpeechBuble.color = new Color(1, 1, 1, 0);
        TutorialImage.color = new Color(1, 1, 1, 0);
        SpeechBuble.gameObject.SetActive(true);
        TutorialImage.gameObject.SetActive(true);
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            SpeechBuble.color = new Color(1, 1, 1, i);
            TutorialImage.color = new Color(1, 1, 1, i);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(10);
        for (float i = 1; i > 0; i -= Time.deltaTime)
        {
            SpeechBuble.color = new Color(1, 1, 1, i);
            TutorialImage.color = new Color(1, 1, 1, i);
            yield return new WaitForEndOfFrame();
        }
        SpeechBuble.gameObject.SetActive(false);
        TutorialImage.gameObject.SetActive(false);
    }
}

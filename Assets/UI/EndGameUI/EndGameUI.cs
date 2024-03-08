using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    public enum EndGameType
    {
        Death,
        MonolithDeath
    };

    string[] endGameMessages =
    {
        "You have died.",                       // Death
        "The Monolith has been destroyed."      // MonolithDeath
    };
    

    public TMPro.TMP_Text endGameText;
    public TMPro.TMP_Text metricsText;

    public void ToggleEndGameUI(EndGameType endGameType)
    {
        endGameText.SetText(endGameMessages[(int)endGameType]);
        string metrics = GameManager._instance.metrics.getMetrics();
        metricsText.SetText(metrics);
        
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        // load the main menu scene
    }
    
}

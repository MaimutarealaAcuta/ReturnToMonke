using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    private bool isPaused = false;

    public void TogglePause()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            gameObject.SetActive(false);
            GameManager._instance.playerController.toggleMovement();
            Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
            gameObject.SetActive(true);
            GameManager._instance.playerController.toggleMovement();
            Cursor.visible = true;

        }
    }

    public void Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}

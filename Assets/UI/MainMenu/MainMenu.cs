using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private GameObject optionsMenu;

    [SerializeField]
    private GameObject mainMenuLogo;

    [SerializeField]
    private GameObject credits;

    private Resolution[] resolutions =
    {
        new Resolution() {width = 1920, height = 1080},
        new Resolution() {width = 1280, height = 720}
    };

    private void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameMap");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        mainMenuLogo.SetActive(false);
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        mainMenu.SetActive(true);
        mainMenuLogo.SetActive(true);
        credits.SetActive(false);
    }

    public void SetMasterVolume(float volume)
    {
        Debug.Log(volume);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}

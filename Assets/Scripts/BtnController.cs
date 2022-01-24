using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class BtnController : MonoBehaviour
{
    public void LoadGame()
    {
        // Ladataan Game Scene
        SceneManager.LoadScene(sceneName: "Game");
        // Asetetaan gameIsRunning muuttuja true:ksi
        PlayerController.gameIsRunning = true;

        // Piilotetaan kursori
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadOptions()
    {
        // Ladataan Options Scene
        SceneManager.LoadScene(sceneName: "Options");
    }

    public void LoadMainMenu()
    {
        // Ladataan Main Menu Scene
        SceneManager.LoadScene(sceneName: "Main Menu");
    }

    public void OpenGithub()
    {
        // Avataan Github nettiselaimeen jos Github nappia painetaan
        Application.OpenURL("https://github.com/AleksiPamilo/");
    }

    public void QuitGame()
    {
        // Suljetaan Sovellus
        Application.Quit();
    }
}

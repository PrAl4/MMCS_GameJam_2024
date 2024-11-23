using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenuButtonsBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject settingsMenu;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGameButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void SettingsJoinButton() 
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void SettingsExitButton() 
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void ExitButton() 
    {
        Application.Quit();
    }
}

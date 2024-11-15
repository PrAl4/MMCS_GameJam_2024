using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject settingsMenu;

    public void StartGameButton()
    {
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

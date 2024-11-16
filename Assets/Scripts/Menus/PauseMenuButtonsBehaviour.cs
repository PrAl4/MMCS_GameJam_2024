using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuButtonsBehaviour : MonoBehaviour
{
    enum MenuStates { Pause, Resume, Settings }

    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject settingsMenu;

    MenuStates pauseMenuActive = MenuStates.Resume;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pauseMenuActive == MenuStates.Resume) // Escape
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.E) && pauseMenuActive == MenuStates.Pause) // Escape
        {
            ResumeGame();
        }
    }


    void PauseGame() 
    {
        pauseMenu.SetActive(true);
        pauseMenuActive = MenuStates.Pause;
        Time.timeScale = 0.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void ResumeGame() 
    {
        pauseMenu.SetActive(false);
        pauseMenuActive = MenuStates.Resume;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ResumeGameButton() 
    {
        ResumeGame();
    }

    public void SettingsJoinButton() 
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
        pauseMenuActive = MenuStates.Settings;
    }

    public void SettingsExitButton() 
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        pauseMenuActive = MenuStates.Pause;
    }

    public void ExitButton() 
    {
        Application.Quit();
    }

}

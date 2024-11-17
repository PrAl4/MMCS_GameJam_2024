using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtonsBehaviour : MonoBehaviour
{
    enum MenuStates { Pause, Resume, Settings }

    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject settingsMenu;

    MenuStates pauseMenuActive = MenuStates.Resume;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuActive == MenuStates.Resume) // Escape
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuActive == MenuStates.Pause) // Escape
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

        soundManager.PlayButtonSound();
    }

    void ResumeGame() 
    {
        pauseMenu.SetActive(false);
        pauseMenuActive = MenuStates.Resume;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        soundManager.PlayButtonSound();
    }

    public void ResumeGameButton() 
    {
        ResumeGame();
        soundManager.PlayButtonSound();
    }

    public void SettingsJoinButton() 
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
        pauseMenuActive = MenuStates.Settings;
        soundManager.PlayButtonSound();
    }

    public void SettingsExitButton() 
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        pauseMenuActive = MenuStates.Pause;
        soundManager.PlayButtonSound();
    }

    public void ExitButton() 
    {
        soundManager.PlayButtonSound();
        SceneManager.LoadScene(0);
    }

}

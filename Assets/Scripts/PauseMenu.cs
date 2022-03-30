using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private GameInputActions _inputActions;

    public GameObject pauseMenuUI;
    void Start()
    {
        pauseMenuUI.SetActive(false);
        _inputActions = new GameInputActions();
    }
    void Update()
    {
        if (_inputActions.UI.Pause.WasPerformedThisFrame())
        {
            Debug.Log("Pause!");
            if (GameIsPaused)
            {
                Resume();
                Debug.Log("Resume!");
            }
            else
            {
                Pause();
                Debug.Log("Pause!");
            }

        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

        public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

        public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}

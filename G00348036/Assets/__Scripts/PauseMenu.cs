using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static PauseMenu Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } 
        else
        {
            Destroy(gameObject); // Don't ever allow two 
        }
    }
    
    #region == Private Variables == 
    private static bool isGamePaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private GameObject gameOverMenuUI;

    #endregion

    // Update is called once per frame
    void Update () {

        // Get esc key input from keyboard
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Resumes game if called
    public void ResumeGame()
    {
        // Turn off the menu UI
        pauseMenuUI.SetActive(false);

        // Start the game running again
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    // Pauses game if called
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void GoToHomeMenu()
    {

    }

    public void GameOverDisplay()
    {
        gameOverMenuUI.SetActive(true);
    }
}

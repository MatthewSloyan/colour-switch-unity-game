using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    
    #region == Private Variables == 
    private static bool isGamePaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private GameObject gameOverMenuUI;

    #endregion

    // Singleton design pattern to get instance of class in PlayerCollider.cs
    public static PauseMenu Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Don't ever allow two objects
        }
    }

    // Update is called once per frame
    void Update () {

        // Get esc key input from keyboard, to pause game from keyboard entry
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

    #region == Menu overlays (Pause/Gameover)
    // These methods will be refactored out of this class eventually

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

    // Display game over screen
    public void GameOverDisplay()
    {
        gameOverMenuUI.SetActive(true);
    }
    #endregion

    #region == Navigation methods == 

    // Resets game if called 
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    // Navigate the player back to the home menu
    public void GoToHomeMenu()
    {
        SceneManager.LoadScene("HomeMenu", LoadSceneMode.Single);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    // Load the intial game
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
    #endregion
}

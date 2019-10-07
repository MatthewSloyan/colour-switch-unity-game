using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    

    #region == Private Variables == 
    [SerializeField]
    private static bool isGamePaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;

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

    public void GoToHomeMenu()
    {

    }
}

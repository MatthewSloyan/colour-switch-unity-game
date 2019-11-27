﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    
    #region == Private Variables == 
    private static bool isGamePaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private GameObject gameOverMenuUI;
    
    [SerializeField]
    private Text currentScoreText;

    [SerializeField]
    private Text highScoreText;
    
    [SerializeField]
    private Toggle soundToggle;

    #endregion

    // Singleton design pattern to get instance of class in PlayerCollider.cs
    public static PauseMenu Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start ()
    {
        //Add listener for when the state of the Toggle changes, to take action
        soundToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(soundToggle);
        });

        // Check if score has been saved before.
        if (PlayerPrefs.HasKey("Sound"))
        {
            bool toggle = Convert.ToBoolean(PlayerPrefs.GetString("Sound"));
            Debug.Log("Test: " + toggle.ToString());
            if (!toggle)
            {
                soundToggle.isOn = false;
            }
        }
        else
        {
            PlayerPrefs.SetString("Sound", soundToggle.isOn.ToString());
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

        // Check if score has been saved before.
        if (PlayerPrefs.HasKey("Score"))
        {
            currentScoreText.text = ScoreController.Instance.PlayerScore.ToString();
            highScoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("Score", 0);
        }
    }


    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        Debug.Log("New Value : " + soundToggle.isOn);
        PlayerPrefs.SetString("Sound", soundToggle.isOn.ToString());
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

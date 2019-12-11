using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    
    #region == Private Variables == 
    private static bool isGamePaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private GameObject gameOverMenuUI;

    [SerializeField]
    private GameObject tutorialMenuUI;

    [SerializeField]
    private Text currentScoreText;

    [SerializeField]
    private Text highScoreText;
    
    [SerializeField]
    private Toggle soundToggle;

    #endregion

    // Singleton design pattern to get instance of class in PlayerCollider.cs
    public static MenuController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start ()
    {
        // Add listener for when the state of the Toggle changes, to take action
        // Code adapted from: https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.Toggle-onValueChanged.html
        soundToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(soundToggle);
        });

        // Check if sound option has been saved before.
        // E.g if not the first time playing the game, or sound has never been turned off.
        // If so then change toggle switch to false if sound is off.
        // If not then set playerPref to true, for again.
        if (PlayerPrefs.HasKey("Sound"))
        {
            bool toggle = Convert.ToBoolean(PlayerPrefs.GetString("Sound"));

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

    // Displays tutorial screen
    public void DisplayTutorial()
    {
        tutorialMenuUI.SetActive(true);
    }

    // Closes tutorial screen
    public void CloseTutorial()
    {
        tutorialMenuUI.SetActive(false);
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        PlayerPrefs.SetString("Sound", soundToggle.isOn.ToString());
    }
    #endregion

    #region == Navigation methods == 

    // Resets game if called 
    public void ResetGame()
    {
        // Clean up
        PlayerPrefs.DeleteKey("LevelSwitch");
        PlayerPrefs.DeleteKey("LevelNumber");

        // Reset movement and rotation speed of spinners/sliders on reset.
        DifficultyController dc = new DifficultyController();
        dc.ResetMovementSpeed();
        dc.ResetRotationSpeed();

        // Reload current scene abd un pause game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    // Navigate the player back to the home menu
    public void GoToHomeMenu()
    {
        // Reset movement and rotation speed of spinners/sliders on reset.
        new DifficultyController().ResetRotationSpeed();

        SceneManager.LoadScene("HomeMenu", LoadSceneMode.Single);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    // Load the intial game
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }

    // Quit the game.
    // Code adapted from: https://docs.unity3d.com/ScriptReference/Application.Quit.html
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}

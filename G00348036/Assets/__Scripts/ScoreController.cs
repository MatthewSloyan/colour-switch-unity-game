using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    #region == Private Variables ==

    [SerializeField]
    private Text scoreText;

    private int playerScore = 0;
    public int PlayerScore { get { return playerScore; } }
    #endregion

    // Singleton design pattern to get instance of class in PlayerCollider.cs
    public static ScoreController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // subscribe to an star collected event and add the score
    private void OnEnable()
    {
        // subscribe
        PlayerCollider.StarCollectedEvent += HandleStarCollectedEvent;
    }

    private void OnDisable()
    {
        // unsubscribe
        PlayerCollider.StarCollectedEvent -= HandleStarCollectedEvent;
    }
    
    // Add to score when event is fired.
    private void HandleStarCollectedEvent(PlayerCollider pc)
    {
        // add to the score
        playerScore += pc.ScoreValue;

        // Set the onscreen score.
        scoreText.text = playerScore.ToString();
        
        // Check if score has been saved before, else initalize score
        if (PlayerPrefs.HasKey("Score"))
        {
            if (playerScore >= PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("Score", playerScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Score", 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // == fields ==
    private int playerScore = 0;

    // subscribe to an enemy killed event and add the score for
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

    private void HandleStarCollectedEvent(PlayerCollider pc)
    {
        // add the enemy score from the enemy that was killed
        playerScore += pc.ScoreValue;
        Debug.Log("Score: " + playerScore);
    }
}

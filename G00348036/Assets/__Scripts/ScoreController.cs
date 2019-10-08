using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // When the ball collides with a score star this method is triggered.
    private void OnTriggerEnter2D(Collider2D collision)
    {
       Destroy(gameObject);
    }
}

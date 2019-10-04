using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region == Public Variables ==
    #endregion

    #region == Private Variables == 
    [SerializeField]
    private float jumpSpeed = 10.0f;

    [SerializeField]
    private Rigidbody2D rb; // Rigid body component

    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Get input from the keyboard or left mouse click to make the ball jump up
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){
            // Set the velocity of the Rigid body to the current velocity times the jump speed.
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }
}

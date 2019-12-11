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
    private float fallThreshold = -5.0f;

    [SerializeField]
    private Rigidbody2D rb; // Rigid body component

    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Get space bar, up arrow and left mouse click input
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Play tap sound once, using AudioController instance.
            AudioController.Instance.playTapClip();

            // https://answers.unity.com/questions/1301204/how-to-change-rigidbody2d-body-type-or-change-whet.html
            // Sourced and adapted from the link above to change the body type of the player
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            // Set the velocity of the Rigid body to the current velocity times the jump speed.
            rb.velocity = Vector2.up * jumpSpeed;
        }

        // Display game over if the player falls off screen.
        if (transform.position.y < fallThreshold)
        {
            MenuController.Instance.GameOverDisplay();
        }
    }
}

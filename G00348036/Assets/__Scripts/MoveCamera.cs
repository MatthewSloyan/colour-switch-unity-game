using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    #region == Private Variables == 
    [SerializeField]
    private Transform playerObject; // Get the player

    #endregion

    // Update is called once per frame
    void Update () {
        // If the player goes above a half way the camera will move with the player
        if (playerObject.position.y > transform.position.y)
        {
            // Set the camera to the new player position.
            transform.position = new Vector3(transform.position.x, playerObject.position.y, transform.position.z);
        }
	}
}

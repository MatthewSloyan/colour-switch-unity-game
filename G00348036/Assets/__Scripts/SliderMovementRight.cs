using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovementRight : MonoBehaviour {

    // Checks if slider is out of bounds, if so reset position and start moving right again.
    void Update ()
    {
        // Take away distance from current position to move right.
        // Get movement speed from DifficultyController script so as difficulty increases the sliders move faster.
        transform.position += new Vector3(DifficultyController.MovementSpeed, 0, 0);

        // 8.45 = point where slider is out of bounds, and needs to be reset.
        if (transform.position.x > 8.45f)
        {
            transform.position = new Vector3(2.8f, transform.position.y, 0);
        }
    }
}

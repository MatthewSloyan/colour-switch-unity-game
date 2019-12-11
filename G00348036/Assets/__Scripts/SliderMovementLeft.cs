using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovementLeft : MonoBehaviour {
   
    // Checks if slider is out of bounds, if so reset position and start moving left again.
    void Update()
    {
        // Take away distance from current position ot move left.
        // Get movement speed from DifficultyController script so as difficulty increases the sliders move faster.
        transform.position -= new Vector3(DifficultyController.MovementSpeed, 0, 0);

        // 8.45 = point where slider is out of bounds, and needs to be reset.
        if (transform.position.x < 2.8f)
        {
            transform.position = new Vector3(8.45f, transform.position.y, 0);
        }
    }
}

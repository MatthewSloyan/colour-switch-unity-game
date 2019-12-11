using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerRotator : MonoBehaviour {
   
    void Start ()
    {
        // Get a random number between 1-2, if 1 then make the rotation speed negative,
        // so the spinner spins in the oposite direction at random.
        int randomDirection = Random.Range(0, 2);
        if (randomDirection == 1)
        {
            // Get roatation speed from DifficultyController script so as difficulty increases the spinners move faster.
            DifficultyController.RotationSpeed *= -1;
        }
    }

    // Rotate spinner by the determined speed above.
    void Update () {
        transform.Rotate(0f, 0f, DifficultyController.RotationSpeed * Time.deltaTime);
	}
}

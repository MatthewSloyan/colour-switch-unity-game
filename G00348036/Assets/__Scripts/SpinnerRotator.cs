using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerRotator : MonoBehaviour {

    #region == Private Variables == 

    // Movement speed which will be updated slowly to increase difficulty
    private static float rotationSpeed = 85f;
    public static float RotationSpeed
    {
        get { return rotationSpeed; }
        set { rotationSpeed = value; }
    }

    #endregion

    void Start ()
    {
        // Get a random number between 1-2, if 1 then make the rotation speed negative,
        // so the spinner spins in the oposite direction at random.
        int randomDirection = Random.Range(0, 2);
        if (randomDirection == 1)
        {
            rotationSpeed *= -1;
        }
    }

    // Rotate spinner by the determined speed above.
    void Update () {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
	}
}

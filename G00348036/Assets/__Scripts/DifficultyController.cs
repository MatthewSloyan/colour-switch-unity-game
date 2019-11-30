using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour {

    #region == Private Variables == 
    private static float initialRotationSpeed = 85f;
    private static float initialMovementSpeed = 0.015f;

    // Rotation speed of spinner which will be updated slowly to increase difficulty
    private static float rotationSpeed = initialRotationSpeed;
    public static float RotationSpeed
    {
        get { return rotationSpeed; }
        set { rotationSpeed = value; }
    }

    // Movement speed of slider which will be updated slowly to increase difficulty
    private static float movementSpeed = initialMovementSpeed;
    public static float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }

    #endregion

    // Reset the speed variables for game reset.
    public void ResetRotationSpeed()
    {
        rotationSpeed = initialRotationSpeed;
    }

    public void ResetMovementSpeed()
    {
        movementSpeed = initialMovementSpeed;
    }
}

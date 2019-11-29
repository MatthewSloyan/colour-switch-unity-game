using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovementLeft : MonoBehaviour {

    #region == Private Variables == 

    // Movement speed which will be updated slowly to increase difficulty
    private static float movementSpeed = 0.015f;
    public static float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }

    private float outOfBounds = 2.8f;
    #endregion

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3(movementSpeed, 0, 0);
        transform.position -= temp;

        if (transform.position.x < outOfBounds)
        {
            transform.position = new Vector3(8.45f, transform.position.y, 0);
        }
    }
}

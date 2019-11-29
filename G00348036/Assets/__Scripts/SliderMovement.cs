using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour {

    #region == Private Variables == 

    // Movement speed which will be updated slowly to increase difficulty
    private static float movementSpeed = 0.015f;
    public static float MovementSpeed
    {
        set { movementSpeed = value; }
    }

    private float outOfBounds = 8.45f;
    #endregion

    // Update is called once per frame
    void Update () {
        Vector3 temp = new Vector3(movementSpeed, 0, 0);
        transform.position += temp;

        if (transform.position.x > outOfBounds)
        {
            transform.position = new Vector3(2.8f, transform.position.y, 0);
            //transform.Translate(2.8f, transform.position.y, speed * Time.deltaTime);
            //Debug.Log("Test");
            //Vector2 newSliderPos = slider.transform.position;
            //newSliderPos.x = -5.6f;

            //Instantiate(slider, newSliderPos, Quaternion.identity);

            //Destroy(slider);
        }
    }
}

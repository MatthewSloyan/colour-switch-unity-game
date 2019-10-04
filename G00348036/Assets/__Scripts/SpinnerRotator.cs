using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerRotator : MonoBehaviour {
   
    #region == Private Variables == 
    [SerializeField]
    private float rotationSpeed = 100f;

    #endregion

    // Rotate spinner by the determined speed above.
    void Update () {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
	}
}

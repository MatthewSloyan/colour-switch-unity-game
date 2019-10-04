using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerRotator : MonoBehaviour {
   
    #region == Private Variables == 
    [SerializeField]
    private float rotationSpeed = 100f;

    #endregion

    // Update is called once per frame
    void Update () {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
	}
}

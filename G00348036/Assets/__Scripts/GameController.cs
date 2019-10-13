using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject spinner;

    [SerializeField]
    private GameObject colourSwapper;

    // Use this for initialization
    void Start()
    {
        //createColourSwapper();
        //createSpinner();
        ColourManager.Instance.setPlayerColour();
    }

    private void createSpinner()
    {

    }

    private void createColourSwapper()
    {
        colourSwapper.tag = "MainCamera";
        Instantiate(colourSwapper, new Vector2(transform.position.x, transform.position.y + 5), Quaternion.identity);
    }
}

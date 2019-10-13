using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject spinner;

    [SerializeField]
    private GameObject colourSwapper;

    [SerializeField]
    private GameObject scoreStar;

    [SerializeField]
    private Transform prevSpinner;

    // Use this for initialization
    void Start()
    {
        createGameObjects();
        ColourManager.Instance.setPlayerColour();
    }

    private void createGameObjects()
    {
        Vector2 newSpinnerPos = prevSpinner.position;
        newSpinnerPos.y += 5f;

        Vector2 newStarPos = prevSpinner.position;
        newStarPos.y += 5f;

        Vector2 newcolourSwapperPos = newSpinnerPos;
        newcolourSwapperPos.y += 2.5f;

        GameObject newSpinner = Instantiate(spinner, newSpinnerPos, Quaternion.identity);
        Instantiate(scoreStar, newStarPos, Quaternion.identity);
        Instantiate(colourSwapper, newcolourSwapperPos, Quaternion.identity);
        prevSpinner = newSpinner.transform;
    }

    //private void createColourSwapper()
    //{
    //    colourSwapper.tag = "MainCamera";
    //    Instantiate(colourSwapper, new Vector2(transform.position.x, transform.position.y + 5), Quaternion.identity);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region == Private Variables == 

    [SerializeField]
    private GameObject spinner;

    [SerializeField]
    private GameObject colourSwapper;

    [SerializeField]
    private GameObject scoreStar;

    [SerializeField]
    private Transform prevSpinner;

    #endregion

    // Singleton design pattern to get instance of class in PlayerCollider.cs
    public static GameController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        createGameObjects();
        ColourManager.Instance.setPlayerColour();
    }

    // Create all three core game ojects (Spinners, Colour Swappers and Star Scores
    public void createGameObjects()
    {
        // == SPINNER == 
        // Create a position for the new Spinner using the previous location
        Vector2 newSpinnerPos = prevSpinner.position;
        newSpinnerPos.y += 5f;

        // Instantiate spinner and set the previous position to the new position for the next call.
        GameObject newSpinner = Instantiate(spinner, newSpinnerPos, Quaternion.identity);
        prevSpinner = newSpinner.transform;

        // == STAR SCORE == 
        // Create a position for the new Star Score object using the previous spinner location (center)
        Vector2 newStarPos = prevSpinner.position;
        newStarPos.y += 5f;

        Instantiate(scoreStar, newStarPos, Quaternion.identity);

        // == COLOUR SWAPPER == 
        // Create a position for the new Colour Swapper using the new spinner location
        Vector2 newcolourSwapperPos = newSpinnerPos;
        newcolourSwapperPos.y += 2.5f;

        GameObject newColourSwapper = Instantiate(colourSwapper, newcolourSwapperPos, Quaternion.identity);
        SpriteRenderer rend = newColourSwapper.GetComponent<SpriteRenderer>();
        rend.color = Color.black;
        //newColourSwapper.tag = "RedTag";
    }
}

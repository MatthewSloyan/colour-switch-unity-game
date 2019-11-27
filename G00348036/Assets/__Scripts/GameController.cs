using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region == Private Variables == 

    [SerializeField]
    private GameObject spinner;

    [SerializeField]
    private GameObject slider;

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
        createGameObjects(0);

        // Set initial player colour
        ColourManager.Instance.setPlayerColour();
    }

    // Create all three core game ojects (Spinners, Colour Swappers and Star Scores
    public void createGameObjects(int levelSwitch)
    {
        if (levelSwitch == 0)
        {
            // == SPINNER == 
            // Create a position for the new Spinner using the previous location
            Vector2 newSpinnerPos = prevSpinner.position;
            newSpinnerPos.y += 5f;

            // Instantiate spinner and set the previous position to the new position for the next call.
            GameObject newSpinner = Instantiate(spinner, newSpinnerPos, Quaternion.identity);

            // == STAR SCORE == 
            // Create a position for the new Star Score object using the previous spinner location (center)
            Vector2 newStarPos = prevSpinner.position;
            newStarPos.y += 5f;

            Instantiate(scoreStar, newStarPos, Quaternion.identity);

            // == COLOUR SWAPPER == 
            // Create a position for the new Colour Swapper using the new spinner location
            Vector2 newcolourSwapperPos = newSpinnerPos;
            newcolourSwapperPos.y += 2.5f;

            Instantiate(colourSwapper, newcolourSwapperPos, Quaternion.identity);

            // Finally set the old position of the spinner to the new position for following calls.
            // So that they spawn correctly in order.
            prevSpinner = newSpinner.transform;
        }
        else
        {
            // == SLIDER == 
            // Create a position for the new Spinner using the previous location
            Vector2 newSliderPos = prevSpinner.position;
            newSliderPos.x = 2.81f;
            newSliderPos.y += 3f;

            // Instantiate spinner and set the previous position to the new position for the next call.
            GameObject newSlider = Instantiate(slider, newSliderPos, Quaternion.identity);
        }
    }
}

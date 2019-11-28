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
    private Transform prevPosition;

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
        //createGameObjects(0);
        createInitial();

        // Set initial player colour
        ColourManager.Instance.setPlayerColour();
    }

    // Create all three core game ojects (Spinners, Colour Swappers and Star Scores
    public void createInitial()
    {
        Vector2 spinnerPos;
        GameObject newSpinner;

        // == SPINNER == 
        // Create a position for the new Spinner using the previous location
        spinnerPos = new Vector2(0, 1.2f);

        // Instantiate spinner 
        newSpinner = Instantiate(spinner, spinnerPos, Quaternion.identity);
        
        // == STAR SCORE == 
        Instantiate(scoreStar, spinnerPos, Quaternion.identity);

        // Finally set the old position of the spinner to the new position for following calls.
        // So that they spawn correctly in order.
        prevPosition = newSpinner.transform;

        // == SPINNER == 
        // Create a position for the new Spinner using the previous location
        spinnerPos = prevPosition.position;
        spinnerPos.y += 5.2f;

        // Instantiate spinner and set the previous position to the new position for the next call.
        newSpinner = Instantiate(spinner, spinnerPos, Quaternion.identity);

        // == STAR SCORE == 
        Instantiate(scoreStar, spinnerPos, Quaternion.identity);

        // == COLOUR SWAPPER == 
        // Create a position for the new Colour Swapper using the new spinner location
        spinnerPos.y += 2.5f;

        Instantiate(colourSwapper, spinnerPos, Quaternion.identity);

        // Finally set the old position of the spinner to the new position for following calls.
        // So that they spawn correctly in order.
        prevPosition = newSpinner.transform;
    }

    // Create all three core game ojects (Spinners, Colour Swappers and Star Scores
    public void createGameObjects(int levelSwitch)
    {
        if (levelSwitch == 0)
        {
            // == SPINNER == 
            // Create a position for the new Spinner using the previous location
            Vector2 newSpinnerPos = prevPosition.position;
            newSpinnerPos.y += 5f;

            // Instantiate spinner and set the previous position to the new position for the next call.
            GameObject newSpinner = Instantiate(spinner, newSpinnerPos, Quaternion.identity);

            // == STAR SCORE == 
            // Create a position for the new Star Score object using the previous spinner location (center)
            Vector2 newStarPos = prevPosition.position;
            newStarPos.y += 5f;

            Instantiate(scoreStar, newStarPos, Quaternion.identity);

            // == COLOUR SWAPPER == 
            // Create a position for the new Colour Swapper using the new spinner location
            Vector2 newcolourSwapperPos = newSpinnerPos;
            newcolourSwapperPos.y += 2.5f;

            Instantiate(colourSwapper, newcolourSwapperPos, Quaternion.identity);

            // Finally set the old position of the spinner to the new position for following calls.
            // So that they spawn correctly in order.
            prevPosition = newSpinner.transform;
        }
        else
        {
            // == SLIDER == 
            // Create a position for the new Spinner using the previous location
            Vector2 newSliderPos = prevPosition.position;
            newSliderPos.x = 2.81f;
            newSliderPos.y += 3f;

            // Instantiate spinner and set the previous position to the new position for the next call.
            GameObject newSlider = Instantiate(slider, newSliderPos, Quaternion.identity);
        }
    }
}

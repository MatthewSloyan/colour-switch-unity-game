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
    
    private Transform prevPosition;

    private GameObject parent;

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
        parent = GameObject.Find("GameObjectContainer");

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

        // Instantiate spinner and set as child to parent
        // Code adapted from: https://docs.unity3d.com/ScriptReference/Transform.SetParent.html
        newSpinner = Instantiate(spinner, spinnerPos, Quaternion.identity);
        //newSpinner.transform.parent = parent.transform;
        newSpinner.transform.SetParent(parent.transform, false);

        // == STAR SCORE == 
        Instantiate(scoreStar, spinnerPos, Quaternion.identity).transform.SetParent(parent.transform, false);

        //// Finally set the old position of the spinner to the new position for following calls.
        //// So that they spawn correctly in order.
        //prevPosition = newSpinner.transform;

        //// == SPINNER == 
        //// Create a position for the new Spinner using the previous location
        //spinnerPos = prevPosition.position;
        //spinnerPos.y += 5f;

        //// Instantiate spinner and set the previous position to the new position for the next call.
        //newSpinner = Instantiate(spinner, spinnerPos, Quaternion.identity);

        //// == STAR SCORE == 
        //Instantiate(scoreStar, spinnerPos, Quaternion.identity);

        // == COLOUR SWAPPER == 
        // Create a position for the new Colour Swapper using the new spinner location
        spinnerPos.y += 2.5f;

        Instantiate(colourSwapper, spinnerPos, Quaternion.identity).transform.SetParent(parent.transform, false);

        // Finally set the old position of the spinner to the new position for following calls.
        // So that they spawn correctly in order.
        prevPosition = newSpinner.transform;

        PlayerPrefs.SetInt("LevelSwitch", 1);
    }

    // Create all three core game ojects (Spinners, Colour Swappers and Star Scores
    public void createGameObjects()
    {
        int levelSwitch = PlayerPrefs.GetInt("LevelSwitch");
        Debug.Log("Level Num: " + levelSwitch);

        if (levelSwitch == 0)
        {
            Vector2 spinnerPos;
            GameObject newSpinner;

            // == SPINNER == 
            // Create a position for the new Spinner using the previous location
            spinnerPos = prevPosition.position;
            spinnerPos.y += 3f;

            // Instantiate spinner and set the previous position to the new position for the next call.
            newSpinner = Instantiate(spinner, spinnerPos, Quaternion.identity);
            newSpinner.transform.SetParent(parent.transform, false);

            // == STAR SCORE == 
            Instantiate(scoreStar, spinnerPos, Quaternion.identity).transform.SetParent(parent.transform, false);

            //// Finally set the old position of the spinner to the new position for following calls.
            //// So that they spawn correctly in order.
            //prevPosition = newSpinner.transform;

            //// == SPINNER == 
            //// Create a position for the new Spinner using the previous location
            //spinnerPos = prevPosition.position;
            //spinnerPos.y += 5f;

            //// Instantiate spinner and set the previous position to the new position for the next call.
            //newSpinner = Instantiate(spinner, spinnerPos, Quaternion.identity);

            //// == STAR SCORE == 
            //Instantiate(scoreStar, spinnerPos, Quaternion.identity);

            // == COLOUR SWAPPER == 
            // Create a position for the new Colour Swapper using the new spinner location
            spinnerPos.y += 2.5f;

            Instantiate(colourSwapper, spinnerPos, Quaternion.identity).transform.SetParent(parent.transform, false);

            // Finally set the old position of the spinner to the new position for following calls.
            // So that they spawn correctly in order.
            prevPosition = newSpinner.transform;

            PlayerPrefs.SetInt("LevelSwitch", 1);
        }
        else
        {
            Vector2 sliderPos = new Vector2(0, 0);

            for (int i = 0; i < 2; i++)
            {
                // == SLIDER == 
                // Create a position for the new Spinner using the previous location
                sliderPos = prevPosition.position;
                sliderPos.x = 2.81f;
                sliderPos.y += 4f;

                // Instantiate spinner and set the previous position to the new position for the next call.
                GameObject newSlider = Instantiate(slider, sliderPos, Quaternion.identity);
                newSlider.transform.SetParent(parent.transform, false);

                if (i < 1)
                {
                    // == STAR SCORE == 
                    sliderPos.x = 0;
                    sliderPos.y += 2;
                    Instantiate(scoreStar, sliderPos, Quaternion.identity).transform.SetParent(parent.transform, false);
                    //newColourSwap.transform.SetParent(parent.transform, false);
                }

                prevPosition = newSlider.transform;
            }

            // == COLOUR SWAPPER == 
            // Create a position for the new Colour Swapper using the new spinner location
            sliderPos.x = 0;
            sliderPos.y += 2f;

            GameObject newColourSwap = Instantiate(colourSwapper, sliderPos, Quaternion.identity);
            newColourSwap.transform.SetParent(parent.transform, false);

            prevPosition = newColourSwap.transform;

            PlayerPrefs.SetInt("LevelSwitch", 0);
        }
    }
}

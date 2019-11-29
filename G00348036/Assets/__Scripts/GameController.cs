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

    // Previous gameObject postion
    private Transform prevPosition;

    // parent game object container
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
        // Set up parent game object container
        parent = GameObject.Find("GameObjectContainer");
        
        // Set level switch to 0 to load spinners, and create inital game objects
        PlayerPrefs.SetInt("LevelSwitch", 0);
        createGameObjects();

        // Set initial player colour
        ColourManager.Instance.setPlayerColour();
    }

    // Create all core game ojects (Spinners, sliders, Colour Swappers and Star Scores)
    public void createGameObjects()
    {
        // Get the type of level to load, 0 = spinners, 1 = sliders
        int levelSwitch = PlayerPrefs.GetInt("LevelSwitch");

        if (levelSwitch == 0)
        {
            Vector2 spinnerPos = new Vector2(0, 0);
            GameObject newSpinner = null;

            // == SPINNER == 
            for (int i = 0; i < 2; i++)
            {
                // If very first spinner then set manually.
                if (prevPosition == null)
                {
                    spinnerPos = new Vector2(0, 1.2f);
                }
                else
                {
                    // Set the position for new Spinner using the previous location.
                    // Add three to positon it correctly above last gameObject.
                    spinnerPos = prevPosition.position;
                    spinnerPos.y += 5f;
                }

                // Instantiate new spinner using position and add to parent container.
                newSpinner = Instantiate(spinner, spinnerPos, Quaternion.identity);
                newSpinner.transform.SetParent(parent.transform, false);

                // == STAR SCORE == 
                // Instantiate new star using same position and add to parent container. As stars are in the center of spinners
                Instantiate(scoreStar, spinnerPos, Quaternion.identity).transform.SetParent(parent.transform, false);

                // Set prevPosition to the current slider, for next slider or next level.
                prevPosition = newSpinner.transform;
            }
            
            // == COLOUR SWAPPER ==
            // Create a position for the new Colour Swapper using the same postion plus 2.75
            spinnerPos.y += 2.75f;

            Instantiate(colourSwapper, spinnerPos, Quaternion.identity).transform.SetParent(parent.transform, false);

            // Finally set the old position of the spinner to the new position for following calls.
            // So that they spawn correctly in order.
            prevPosition = newSpinner.transform;

            PlayerPrefs.SetInt("LevelSwitch", 1);
        }
        else
        {
            Vector2 sliderPos = new Vector2(0, 0);
            GameObject newSlider = null;

            // == SLIDER == 
            // Create three sliders equaly spaced from each other
            for (int i = 0; i < 3; i++)
            {
                // Get the previous gameObject postion and set x so it starts off screen.
                sliderPos = prevPosition.position;
                sliderPos.x = 2.81f;

                // If first slider, set sligthly higher so it's not too close to the colour swapper.
                if (i == 0)
                    sliderPos.y += 4.5f;
                else
                    sliderPos.y += 3f;

                // Instantiate new slider using prev position and add to parent container.
                newSlider = Instantiate(slider, sliderPos, Quaternion.identity);
                newSlider.transform.SetParent(parent.transform, false);

                // == STAR SCORE == 
                // Add a star score to the parent in the center only for the first two sliders.
                if (i < 2)
                {
                    // Set back to 0 so star is centered.
                    sliderPos.x = 0;
                    sliderPos.y += 1.5f;
                    Instantiate(scoreStar, sliderPos, Quaternion.identity).transform.SetParent(parent.transform, false);
                }

                // Set prevPosition to the current slider, for next slider or next level.
                prevPosition = newSlider.transform;
            }

            // == COLOUR SWAPPER == 
            // Set back to 0 so star is centered, and move up.
            sliderPos.x = 0;
            sliderPos.y += 2f;

            Instantiate(colourSwapper, sliderPos, Quaternion.identity).transform.SetParent(parent.transform, false);

            // Finally set the old position to the new position for following calls.
            // So that they spawn correctly in order.
            prevPosition = newSlider.transform;

            // Set level switch so it will load spinners on next call.
            PlayerPrefs.SetInt("LevelSwitch", 0);
        }
    }
}

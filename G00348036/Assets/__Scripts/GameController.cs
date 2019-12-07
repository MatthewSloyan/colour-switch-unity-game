using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region == Private Variables == 

    [SerializeField]
    private GameObject spinner;

    [SerializeField]
    private GameObject sliderRight;

    [SerializeField]
    private GameObject sliderLeft;

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
        PlayerPrefs.SetInt("LevelNumber", 2);
        createGameObjects();

        // Set initial player colour
        ColourManager.Instance.setPlayerColour();
    }

    // Create all core game ojects (Spinners, sliders, Colour Swappers and Star Scores)
    public void createGameObjects()
    {
        // Get the type of level to load, 0 = spinners, 1 = sliders
        int levelSwitch = PlayerPrefs.GetInt("LevelSwitch");
        //Debug.Log("Level Switch" + levelSwitch);

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
                    spinnerPos.x = 0;
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

            // == LEVEL NUMBER ==
            createLevelNumberText(spinnerPos.y, 0);

            // == COLOUR SWAPPER ==
            // Create a position for the new Colour Swapper using the same postion plus 2.75
            spinnerPos.y += 2.75f;

            Instantiate(colourSwapper, spinnerPos, Quaternion.identity).transform.SetParent(parent.transform, false);

            // Finally set the old position of the spinner to the new position for following calls.
            // So that they spawn correctly in order.
            prevPosition = newSpinner.transform;

            // Set level switch so it will load spinners on next call.
            PlayerPrefs.SetInt("LevelSwitch", 1);

            // == DIFFICULTY == 
            // Increase slider speed for next level to increase difficulty slightly.
            DifficultyController.MovementSpeed += 0.008f;
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

                if (i == 1)
                    sliderPos.x = 8.45f;
                else
                    sliderPos.x = 2.81f;

                // If first slider, set sligthly higher so it's not too close to the colour swapper.
                if (i == 0)
                    sliderPos.y += 4.5f;
                else
                    sliderPos.y += 3f;

                if (i == 1)
                    newSlider = Instantiate(sliderLeft, sliderPos, Quaternion.identity);
                else
                    newSlider = Instantiate(sliderRight, sliderPos, Quaternion.identity);
                
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

            // == LEVEL NUMBER ==
            createLevelNumberText(sliderPos.y, 1);

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

            // == DIFFICULTY == 
            // Increase spinner speed for next level to increase difficulty slightly, depending if rotation is clockwise or anticlockwise.
            if (DifficultyController.RotationSpeed < 0)
                DifficultyController.RotationSpeed -= 23f;
            else
                DifficultyController.RotationSpeed += 23f;
        }
    }

    // Create a TextMeshPro beside colour swapper to display the current level the player is on.
    private void createLevelNumberText(float yPos, int levelOption)
    {
        GameObject levelNumber;
        TextMeshPro textMeshComponent;
        Vector2 textPos;

        // Get the current level the player is on
        int currLevelNum = PlayerPrefs.GetInt("LevelNumber");

        // Set update the levelNumber by 1 for next level.
        PlayerPrefs.SetInt("LevelNumber", currLevelNum + 1);

        // Add new gameobject, DestroyGameObject script and TextMeshPro component.
        levelNumber = new GameObject("LevelNumber");
        levelNumber.AddComponent<DestroyGameObjects>();
        levelNumber.AddComponent(typeof(TextMeshPro));

        // Get the component from the gameObject to set it's variables, E.g text, size and font style.
        // Code adapted from: https://forum.unity.com/threads/scripting-the-creation-of-text-meshes.6487/
        textMeshComponent = levelNumber.GetComponent(typeof(TextMeshPro)) as TextMeshPro;
        textMeshComponent.text = "Level " + currLevelNum;
        textMeshComponent.fontSize = 4;
        // Code adapted from: https://docs.unity3d.com/ScriptReference/TextMesh-fontStyle.html
        textMeshComponent.fontStyle = FontStyles.Bold;

        // Set the position to align to the left of the colour swapper.
        if (levelOption == 0)
            textPos = new Vector2(7.8f, yPos + 0.5f);
        else
            textPos = new Vector2(7.8f, yPos - 0.2f);

        // Instantiate new GameObject and add to parent container.
        Instantiate(levelNumber, textPos, Quaternion.identity).transform.SetParent(parent.transform, false);
    }


    void OnApplicationQuit()
    {
        // Clean up
        PlayerPrefs.DeleteKey("LevelSwitch");
        PlayerPrefs.DeleteKey("LevelNumber");
    }
}

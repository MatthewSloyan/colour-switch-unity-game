using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour {

    #region == Private Variables == 
    [SerializeField]
    private Color[] colours; // Array of colours

   // Color[] colors = { new Color(0, 1, 0, 1), new Color(1, 0, 0, 1), new Color(1, 1, 1, 1), new Color(0, 0, 1, 1), new Color(1, 1, 0, 1), new Color(0, 0, 0, 1) };

    [SerializeField]
    private SpriteRenderer sr;

    private string[] colourOptions = new string[4] { "GreenTag", "YellowTag", "BlueTag", "RedTag" }; // Array of colour tags to set


    //create an object of SingleObject
    private static ColourManager instance = new ColourManager();

    //make the constructor private so that this class cannot be
    //instantiated
    private ColourManager() {
    }

    //Get the only object available
    public static ColourManager getInstance()
    {
        return instance;
    }

    #endregion
    
    // Use this for initialization
    void Start () {
        setRandomColour();
    }

    public void setRandomColour()
    {
        // Get a random index between 1 and 4
        int randomColour = UnityEngine.Random.Range(0, colours.Length);

        // Set the colour to one of the determined colours in Unity
        sr.color = colours[randomColour];

        // Set the tag of the SpriteRenderer to a colour in the string array.
        // This will be retrieved in the PlayerCollider script.
        sr.tag = colourOptions[randomColour];
    }

    public void setColour()
    {
        int index = Array.IndexOf(colourOptions, sr.tag);
        
        sr.color = colours[index];

        sr.tag = colourOptions[index];
    }
}

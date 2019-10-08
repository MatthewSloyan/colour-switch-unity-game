using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour {

    #region == Private Variables == 
    //[SerializeField]
    //private Color[] colours; // Array of colours

    [SerializeField]
    private Color[] colours = { new Color(44, 182, 115, 255), new Color(250, 238, 49, 255), new Color(41, 141, 225, 255), new Color(222, 82, 107, 255) };

    [SerializeField]
    private SpriteRenderer sr;

    private string[] colourOptions = new string[4] { "GreenTag", "YellowTag", "BlueTag", "RedTag" }; // Array of colour tags to set

    // Singleton design pattern to get instance of class in PlayerCollider.cs
    public static ColourManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Don't ever allow two objects
        }
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

    public void setColour(string colourChangerTag)
    {
        int index = Array.IndexOf(colourOptions, colourChangerTag);
        
        sr.color = colours[index];

        sr.tag = colourOptions[index];
    }
}

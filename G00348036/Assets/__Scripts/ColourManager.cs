using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour {
    
    #region == Private Variables == 
    [SerializeField]
    private Color[] colours; // Array of colours

    [SerializeField]
    private SpriteRenderer sr;

    private string[] colourOptions = new string[4] { "GreenTag", "YellowTag", "BlueTag", "RedTag" }; // Array of colour tags to set

    #endregion
    
    // Use this for initialization
    void Start () {

        // Get a random index between 1 and 4
        int randomColour = Random.Range(0, colours.Length);

        // Set the colour to one of the determined colours in Unity
        sr.color = colours[randomColour];

        // Set the tag of the SpriteRenderer to a colour in the string array.
        // This will be retrieved in the PlayerCollider script.
        sr.tag = colourOptions[randomColour];
    }

    // Update is called once per frame
    void Update () {
		
	}
}

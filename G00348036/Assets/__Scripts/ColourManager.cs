using UnityEngine;

public class ColourManager : MonoBehaviour
{
    #region == Private Variables == 

    // Four colours used to change the current player colour.
    private Color[] colours = { new Color32(44, 182, 115, 255), new Color32(250, 238, 49, 255), new Color32(41, 141, 225, 255), new Color32(222, 82, 107, 255) };

    // Array used to set the tag for the player to collide with obstacles.
    private string[] colourOptions = new string[4] { "GreenTag", "YellowTag", "BlueTag", "RedTag" };

    [SerializeField]
    private SpriteRenderer sr;

    #endregion

    // Singleton design pattern to get instance of class in PlayerCollider.cs
    public static ColourManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
   
    public void setPlayerColour()
    {
        // Get a random index between 1 and 4
        int randomColour = Random.Range(0, colours.Length);

        // Check if the new random colour is the current player colour, if so call again until it's different (Recursion).
        // This is used when swapping colours so the player always gets a new random colour.
        if (colours[randomColour] == sr.color)
        {
            setPlayerColour();
        }
        else
        {
            // Set the colour to one of the determined colours in Unity
            sr.color = colours[randomColour];

            // Set the tag of the SpriteRenderer to a colour in the string array.
            // This will be retrieved in the PlayerCollider script.
            sr.tag = colourOptions[randomColour];
        }

    }
}

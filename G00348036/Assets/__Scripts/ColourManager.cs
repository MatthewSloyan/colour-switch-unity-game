using UnityEngine;

public class ColourManager : MonoBehaviour
{

    #region == Private Variables == 
    //[SerializeField]
    //private Color[] colours; // Array of colours

    private Color[] colours = { new Color32(44, 182, 115, 255), new Color32(250, 238, 49, 255), new Color32(41, 141, 225, 255), new Color32(222, 82, 107, 255) };

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
    }

    #endregion

    // Use this for initialization
    void Start()
    {
       
    }

    public void setPlayerColour()
    {
        // Get a random index between 1 and 4
        int randomColour = UnityEngine.Random.Range(0, colours.Length);

        // Set the colour to one of the determined colours in Unity
        sr.color = colours[randomColour];

        // Set the tag of the SpriteRenderer to a colour in the string array.
        // This will be retrieved in the PlayerCollider script.
        sr.tag = colourOptions[randomColour];
        Debug.Log("Change Colour! " + sr.tag);
    }

    public void setRandomColour()
    {

    }

    public void setColour(string colourChangerTag)
    {
        int index = System.Array.IndexOf(colourOptions, colourChangerTag);

        sr.color = colours[index];

        sr.tag = colourOptions[index];
    }
}

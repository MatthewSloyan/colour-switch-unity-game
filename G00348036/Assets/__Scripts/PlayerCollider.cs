using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    #region == Private Variables == 
    [SerializeField]
    private SpriteRenderer sr;
    
    private int scoreValue = 1;
    public int ScoreValue { get { return scoreValue; } }

    #endregion

    #region == Public Variables == 

    // From the labs I implemented the score counter using events.
    // notify the system when a star is collected.
    public delegate void StarCollected(PlayerCollider pc);

    public static StarCollected StarCollectedEvent;

    #endregion


    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        sr = player.GetComponent<SpriteRenderer>();
    }

    // When the ball collides with a piece of the spinner this method is triggered.
    private void OnTriggerEnter2D (Collider2D collision)
    {
        // If a colour swapper, then randomly select a new unique player colour.
        if (collision.gameObject.tag == "ChangeColour")
        {
            ColourManager.Instance.setPlayerColour();
            
            Destroy(collision.gameObject);

            // Only create a new set of gameobjects when the player gets close so they're not unnecessarily created.
            // Will need check for level
            GameController.Instance.createGameObjects();
            return;
        }

        // If the gameobject is a star then collect and update score.
        if (collision.gameObject.tag == "Star")
        {
            // Play collect star sound once.
            AudioController.Instance.playCollectStarClip();

            // Notify the system of a change E.g update score
            PublishStarCollectedEvent();

            // Destroy star object
            Destroy(collision.gameObject);
            return;
        }

        // If the current player tag (spriteRender tag) is equal to the spinner piece tag then end the game.
        // Otherwise allow the player through
        if (collision.tag != sr.tag)
        {
            // Play player death sound once.
            AudioController.Instance.playPlayerDiesClip();

            // Pause game
            Time.timeScale = 0f;

            // Display the gameover menu from the Menu script
            MenuController.Instance.GameOverDisplay();
            return;
        }
    }

    // event for the system
    private void PublishStarCollectedEvent()
    {
        if (StarCollectedEvent != null)
        {
            StarCollectedEvent(this);
        }
    }
}

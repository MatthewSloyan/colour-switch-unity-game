using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    #region == Private Variables == 
    [SerializeField]
    private SpriteRenderer sr;
    
    private Color[] colours = { new Color32(44, 182, 115, 255), new Color32(250, 238, 49, 255), new Color32(41, 141, 225, 255), new Color32(222, 82, 107, 255) };

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
            return;
        }

        // If the gameobject is a star then collect and update score.
        if (collision.gameObject.tag == "Star")
        {
            // Play collect star sound once.
            AudioController.Instance.playCollectStarClip();

            Destroy(collision.gameObject);

            // Only create a new set of gameobjects when the player gets close so they're not unnecessarily created.
            GameController.Instance.createGameObjects();

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
            PauseMenu.Instance.GameOverDisplay();
            return;
        }
    }
}

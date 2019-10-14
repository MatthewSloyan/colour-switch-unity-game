using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    #region == Private Variables == 
    [SerializeField]
    private SpriteRenderer sr;
    
    private Color[] colours = { new Color32(44, 182, 115, 255), new Color32(250, 238, 49, 255), new Color32(41, 141, 225, 255), new Color32(222, 82, 107, 255) };

    #endregion

    // When the ball collides with a piece of the spinner this method is triggered.
    private void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("Game tag " + collision.gameObject.tag);

        if (collision.gameObject.tag == "ChangeColour")
        {
            // Get a random index between 1 and 4
            int randomColour = Random.Range(0, colours.Length);

            SpriteRenderer playerSr = collision.gameObject.GetComponent<SpriteRenderer>();
            ColourManager.Instance.setColour(colours[randomColour]);
            
            Destroy(collision.gameObject);
            return;
        }

        // If the gameobject is a star then collect and update score.
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);

            GameController.Instance.createGameObjects();

            return;
        }

        // If the current player tag (spriteRender tag) is equal to the spinner piece tag then end the game.
        // Otherwise allow the player through
        if (collision.tag != sr.tag)
        {
            Debug.Log("End Game!");

            PauseMenu.Instance.GameOverDisplay();
            return;
        }
    }
}

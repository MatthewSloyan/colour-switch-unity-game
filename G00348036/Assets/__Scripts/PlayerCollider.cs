using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    #region == Private Variables == 
    [SerializeField]
    private SpriteRenderer sr;

    private string[] colourOptions = new string[4] { "GreenTag", "YellowTag", "BlueTag", "RedTag" }; // Array of colour tags to set

    #endregion

    // When the ball collides with a piece of the spinner this method is triggered.
    private void OnTriggerEnter2D (Collider2D collision)
    {
        // If the current player tag (spriteRender tag) is equal to the spinner piece tag then end the game.
        // Otherwise allow the player through
        if (collision.tag != sr.tag)
        {
            Debug.Log("End Game!");

            PauseMenu.Instance.GameOverDisplay();
        }

        if (collision.gameObject.tag == "ChangeColour")
        {
            ColourManager.Instance.setColour(collision.tag);
            Debug.Log("Change Colour! " + collision.tag);
            Destroy(collision.gameObject);
            return;
        }
    }
}

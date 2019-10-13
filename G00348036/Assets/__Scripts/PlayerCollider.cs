using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    #region == Private Variables == 
    [SerializeField]
    private SpriteRenderer sr;

    #endregion

    // When the ball collides with a piece of the spinner this method is triggered.
    private void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("Game tag " + collision.gameObject.tag);

        if (collision.gameObject.tag == "ChangeColour")
        {
            ColourManager.Instance.setColour("RedTag");
            //Debug.Log("Change Colour! " + collision.tag);
            Destroy(collision.gameObject);
            return;
        }

        // If the gameobject is a star then collect and update score.
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
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

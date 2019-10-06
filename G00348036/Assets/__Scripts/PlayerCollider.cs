using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    #region == Private Variables == 
    [SerializeField]
    private SpriteRenderer sr;

    #endregion

    // When the ball collides with a piece of the spinner this method is triggered.
    private void OnTriggerEnter2D (Collider2D collision)
    {
        ColourManager c = ColourManager.getInstance();

        //Debug.Log(collision.tag);

        if (collision.name == "ColourChanger")
        {
            //c.setColour();
            Debug.Log("Change Colour!");
            Destroy(collision.gameObject);
            return;
        }

        // If the current player tag (spriteRender tag) is equal to the spinner piece tag then end the game.
        // Otherwise allow the player through
        if (collision.tag != sr.tag)
        {
            Debug.Log("End Game!");
        }
    }
}

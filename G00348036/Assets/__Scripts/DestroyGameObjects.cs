using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjects : MonoBehaviour {

    // Clean up and destroy gameObjects that go off screen so that it doesn't slow downt the game the longer you play.
    // From testing without this it would get quite laggy after level 10.
    // Code adapted from: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnBecameInvisible.html

    // Wouldn't work at first but from research I found you have to add a render to the prefab.
    // https://forum.unity.com/threads/onbecameinvisible-not-working-on-my-object-whats-wrong-in-here.181009/
    void OnBecameInvisible()
    {
        // Wait 1 second, as gameObjects are removed too quickly (E.g player can sometimes see them disappear).
        StartCoroutine(Wait());

        // After 1 second has elapsed destroy gameObject.
        Destroy(gameObject);
    }

    // Code adapted from: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
    IEnumerator Wait()
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDissapear : MonoBehaviour
{
    private bool spacePressed = false;

    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
            StartCoroutine(DeactivateAfterDelay(0.5f));
        }
    }

    IEnumerator DeactivateAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Check if the space key is still pressed after the delay
        if (spacePressed)
        {
            // Deactivate the game object
            gameObject.SetActive(false);
        }
    }
}
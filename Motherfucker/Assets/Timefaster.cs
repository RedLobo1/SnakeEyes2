using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timefaster : MonoBehaviour
{
    private float originalTimeScale;

    void Start()
    {
        // Store the original time scale
        originalTimeScale = Time.timeScale;
    }

    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Double the time scale
            Time.timeScale *= 4f;
        }

        // Check if the space key is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Set time scale back to its original value
            Time.timeScale = originalTimeScale;
        }
    }
}
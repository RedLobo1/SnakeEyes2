using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float scaleFactor = 0.5f; // Adjust this value to change the magnitude of the scale change
    public float speed = 1f; // Adjust this value to change the speed of the scale change

    private float originalScale;

    void Start()
    {
        // Store the original scale of the object
        originalScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new scale using a sine wave
        float scale = originalScale + Mathf.Sin(Time.time * speed) * scaleFactor;

        // Apply the new scale to all axes
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
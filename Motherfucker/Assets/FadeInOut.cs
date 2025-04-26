using System.Collections;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private float startSize = 1.0f; // Default start size
    [SerializeField] private float endSize = 2.0f;   // Default end size
    [SerializeField] private float animationTime = 2.0f; // Duration of the animation in seconds
    [SerializeField] private float startDelay = 2.0f; // Duration of the animation in seconds
    [SerializeField] private GameObject toggleObject; // GameObject to toggle visibility

    //private bool _isPlaying; // Tracks if an animation is currently playing

    void Start()
    {

        transform.localScale = Vector3.one * startSize;
        toggleObject.SetActive(true);
        StartCoroutine(DelayedStartFade()); // Fade-out
    }

    void Update()
    {
        // Trigger fade-in on pressing 'C' and fade-out on pressing 'V'
        //if (Input.GetKeyDown(KeyCode.C) && !_isPlaying)
        //{
        //    StartCoroutine(ScaleObject(startSize, endSize, true)); // Fade-in
        //}
        //else if (Input.GetKeyDown(KeyCode.V) && !_isPlaying)
        //{
        //    StartCoroutine(ScaleObject(endSize, startSize, false)); // Fade-out
        //}
    }

    public void TriggerFadeIn()
    {
        StartCoroutine(ScaleObject(startSize, endSize, true)); // Fade-in
    }

    private IEnumerator DelayedStartFade()
    {
        yield return new WaitForSeconds(startDelay);

        StartCoroutine(ScaleObject(endSize, startSize, false)); // Fade-out
    }

    private IEnumerator ScaleObject(float fromSize, float toSize, bool fadeIn)
    {
        //_isPlaying = true;
        float elapsedTime = 0f;

        // Hide the toggleObject if fading out
        if (!fadeIn && toggleObject != null)
        {
            toggleObject.SetActive(false);
        }

        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / animationTime);
            float easedProgress = Mathf.Sin(progress * Mathf.PI * 0.5f);

            // Interpolate between sizes
            transform.localScale = Vector3.one * Mathf.Lerp(fromSize, toSize, easedProgress);
            yield return null;
        }

        transform.localScale = Vector3.one * toSize;

        // Show the toggleObject after fade-in
        if (fadeIn && toggleObject != null)
        {
            toggleObject.SetActive(true);
        }

        //_isPlaying = false;
    }
}

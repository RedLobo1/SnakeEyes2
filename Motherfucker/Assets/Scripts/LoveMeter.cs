using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class LoveMeter : MonoBehaviour
{
    public static LoveMeter Instance;

    [SerializeField] private Slider meterSlider;
    [SerializeField] private float increaseValue = 10f;
    [SerializeField] private float decreaseValue = 5f;

    [SerializeField] private FadeInOut _fade;

    [SerializeField] private Image image1;
    [SerializeField] private Image image2;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private float alphaChangeDuration = 2f;
    [SerializeField] private float lerpDuration = 1f;
    [SerializeField] private float fadeInDuration = 1f;

    [SerializeField] private float sliderDecreaseDuration = 2f;
    [SerializeField] private Color sliderDecreaseColor = Color.white;
    [SerializeField] private Animator animator;
    private Color originalSliderColor;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        meterSlider.value = meterSlider.maxValue / 2f;
        originalSliderColor = meterSlider.fillRect.GetComponent<Image>().color;
        SetImageAlpha(0f); // Images and Text start invisible
        text.gameObject.SetActive(false);
    }

    public void IncreaseMeter()
    {
        //Debug.Log("-----------------------------------------------------------------------------------------------");
        //meterSlider.value += increaseValue;
        StartCoroutine(IncreaseSliderValue());
        text.gameObject.SetActive(true);
        CheckForMood();
        CheckForWinOrLose();

        StartCoroutine(ChangeAlphaAndLerp());
        animator.Play("SnakeEyes");
    }

    public void DecreaseMeter()
    {
        StartCoroutine(DecreaseSliderValue());
        text.gameObject.SetActive(true);
        CheckForMood();
        CheckForWinOrLose();

        StartCoroutine(ChangeAlphaAndLerp());
        animator.Play("FaceChange");
    }

    private void CheckForMood()
    {
        float percentage = meterSlider.value / meterSlider.maxValue;

        switch (percentage)
        {
            case float p when (p <= 1f / 3f):
                Debug.Log("Mood: Angry");
                break;

            case float p when (p >= 2f / 3f):
                Debug.Log("Mood: Happy");
                break;

            default:
                Debug.Log("Mood: Neutral");
                break;
        }
    }

    private void CheckForWinOrLose()
    {
        if (meterSlider.value <= 0f)
        {
            Debug.Log("Lose");
            StartCoroutine(FadeIn());
        }
        else if (meterSlider.value >= meterSlider.maxValue)
        {
            Debug.Log("Win!");
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator ChangeAlphaAndLerp()
    {
        // Set alpha to 255
        SetImageAlpha(255f);

        // Wait for 'alphaChangeDuration' seconds before starting the lerp
        yield return new WaitForSeconds(alphaChangeDuration);

        // Start lerping the alpha values back to 0
        float startTime = Time.time;
        while (Time.time - startTime < lerpDuration)
        {
            float t = (Time.time - startTime) / lerpDuration;
            float lerpedAlpha = Mathf.Lerp(255f, 0f, t);

            SetImageAlpha(lerpedAlpha);

            yield return null;
        }

        // Final alpha after lerp completes
        SetImageAlpha(0f);
        text.gameObject.SetActive(false); // Optional: hide text after fade out
    }

    private void SetImageAlpha(float alpha)
    {
        float normalizedAlpha = alpha / 255f;

        // Update images
        image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, normalizedAlpha);
        image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, normalizedAlpha);

        // Update text color
        text.color = new Color(text.color.r, text.color.g, text.color.b, normalizedAlpha);
    }

    private IEnumerator FadeIn()
    {
        float startAlpha = 0f;
        float targetAlpha = 255f;
        float startTime = Time.time;

        while (Time.time - startTime < fadeInDuration)
        {
            float t = (Time.time - startTime) / fadeInDuration;
            float lerpedAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);

            SetImageAlpha(lerpedAlpha);

            yield return null;
        }

        SetImageAlpha(targetAlpha);
    }

    private IEnumerator DecreaseSliderValue()
    {
        float startValue = meterSlider.value;
        float targetValue = Mathf.Max(0f, meterSlider.value - decreaseValue);
        float startTime = Time.time;

        meterSlider.fillRect.GetComponent<Image>().color = sliderDecreaseColor;

        while (Time.time - startTime < sliderDecreaseDuration)
        {
            float t = (Time.time - startTime) / sliderDecreaseDuration;
            meterSlider.value = Mathf.Lerp(startValue, targetValue, t);

            yield return null;
        }

        meterSlider.value = targetValue;
        meterSlider.fillRect.GetComponent<Image>().color = originalSliderColor;
    }

    private IEnumerator IncreaseSliderValue()
    {
        float startValue = meterSlider.value;
        float targetValue = Mathf.Max(0f, meterSlider.value + increaseValue);
        float startTime = Time.time;

        meterSlider.fillRect.GetComponent<Image>().color = sliderDecreaseColor;

        while (Time.time - startTime < sliderDecreaseDuration*3)
        {
            float t = (Time.time - startTime) / (sliderDecreaseDuration*3);
            meterSlider.value = Mathf.Lerp(startValue, targetValue, t);

            yield return null;
        }

        meterSlider.value = targetValue;
        meterSlider.fillRect.GetComponent<Image>().color = originalSliderColor;
    }
}

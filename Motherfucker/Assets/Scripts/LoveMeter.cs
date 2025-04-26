using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveMeter : MonoBehaviour
{
    public static LoveMeter Instance;

    [SerializeField] private Slider meterSlider;
    [SerializeField] private float increaseValue = 10f;
    [SerializeField] private float decreaseValue = 5f;

    [SerializeField] private FadeInOut _fade;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        meterSlider.value = meterSlider.maxValue / 2f;
    }

    public void IncreaseMeter()
    {
        meterSlider.value += increaseValue;
        CheckForMood();
        CheckForWinOrLose();
    }

    public void DecreaseMeter()
    {
        meterSlider.value -= decreaseValue;
        CheckForMood();
        CheckForWinOrLose();
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
            _fade.TriggerFadeIn();
        }
        else if (meterSlider.value >= meterSlider.maxValue)
        {
            Debug.Log("Win!");
            _fade.TriggerFadeIn();
        }
    }
}

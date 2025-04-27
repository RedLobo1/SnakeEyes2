using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitAndFadeLoad : MonoBehaviour
{
    [SerializeField] private FadeInOut _fade;
    [SerializeField] private float waitBeforeFade = 2f; // how many seconds to wait before starting fade
    [SerializeField] private string sceneNameToLoad;

    private void Start()
    {
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        // Wait before starting fade
        yield return new WaitForSeconds(waitBeforeFade);

        // Start fade
        if (_fade != null)
        {
            _fade.TriggerFadeIn();
        }

        // Optionally wait for fade to finish
        yield return new WaitForSeconds(1f); // adjust depending on your fade duration

        // Load the scene
        SceneManager.LoadScene(sceneNameToLoad);
    }
}

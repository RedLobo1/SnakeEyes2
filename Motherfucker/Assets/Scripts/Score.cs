using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public DiceRoll Dice;
    public DiceRoll Dice2;
    public static bool isSnakeEyes;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreText2;

    [SerializeField] TextMeshProUGUI snakeText;

    [SerializeField] Spawner[] spawners;

    public MMFeedbacks WinFeedback;

    bool isSpawned = false;
    //private void Awake()
    //{
    //    dice = FindObjectOfType<DiceRoll>();
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            // Reload the active scene
            SceneManager.LoadScene(0);
        }

        if (Dice != null)
        {
            if (Dice.diceFaceNum != 0 && Dice.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                scoreText.gameObject.SetActive(true);
                scoreText.text = Dice.diceFaceNum.ToString();
            }
            else
            {
                scoreText.gameObject.SetActive(false);
            }
        }

        if (Dice2 != null)
        {
            if (Dice2.diceFaceNum != 0 && Dice2.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                scoreText2.gameObject.SetActive(true);
                scoreText2.text = Dice2.diceFaceNum.ToString();
            }
            else
            {
                scoreText2.gameObject.SetActive(false);
            }
        }

        if (Dice2.diceFaceNum == 1 && Dice.diceFaceNum == 1 && Dice.GetComponent<Rigidbody>().velocity == Vector3.zero
            && Dice2.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            ActivateSnakeEyes();

            if (isSpawned)
            {
                return;
            
            }

            WinFeedback?.PlayFeedbacks();
            isSpawned = true;

            foreach (Spawner sp in spawners)
            {
                sp.SpawSnakes();
            }
        }
        else
        {
            isSpawned = false;
            DeactivateSnakeEyes();
        }
    }

    public void DeactivateSnakeEyes()
    {
        snakeText.gameObject.SetActive(false);
        isSnakeEyes = false;
    }

    public void ActivateSnakeEyes()
    {
        snakeText.gameObject.SetActive(true);
        isSnakeEyes = true; 


    }
}

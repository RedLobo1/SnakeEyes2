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

    bool _isOldThrow = true;

    bool _isStarted = false;
    //private void Awake()
    //{
    //    dice = FindObjectOfType<DiceRoll>();
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isStarted = true;
        }

        if (!_isStarted) return;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            // Reload the active scene
            SceneManager.LoadScene(0);
        }

        if (Dice.GetComponent<Rigidbody>().velocity != Vector3.zero
            && Dice2.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            _isOldThrow = false;


        }

        if (Dice != null)
        {
            if (Dice.diceFaceNum != 0 && Dice.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                scoreText.gameObject.SetActive(true);
                scoreText.text = Dice.diceFaceNum.ToString();

                if (scoreText2.gameObject.activeSelf)
                {
                    if (_isOldThrow) return;

                    _isOldThrow = true;
                    LoveMeter.Instance.DecreaseMeter();
                }
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

                if (scoreText.gameObject.activeSelf)
                {
                    if (!_isOldThrow)
                    {
                        _isOldThrow = true;
                        LoveMeter.Instance.DecreaseMeter();
                    }

                    
                }
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

            LoveMeter.Instance.IncreaseMeter();

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

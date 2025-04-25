using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDetector : MonoBehaviour
{
    public DiceRoll Dice;

    //public bool IsGotOne;

    //public DiceRoll Dice2;
    //private void Awake()
    //{
    //    Dice = FindObjectOfType<DiceRoll>();
    //}

    private void OnTriggerStay(Collider other)
    {
        if (Dice != null)
        {
            if (Dice.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                Dice.diceFaceNum = int.Parse(other.name);

                //if (int.Parse(other.name) == 1)
                //{
                //    IsGotOne = true;
                //}
                //else
                //{
                //    IsGotOne = false;
                //}
            }
        }

        //if (Dice2 != null)
        //{
        //    if (Dice2.GetComponent<Rigidbody>().velocity == Vector3.zero)
        //    {
        //        Dice2.diceFaceNum = int.Parse(other.name);
        //    }
        //}
    }
}

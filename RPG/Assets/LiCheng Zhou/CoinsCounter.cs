using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    public Text score;
    private int scoreValue = 0;
    public GameObject coin;
    private void OnTriggerEnter(Collider collision)
    {
        //if(collision.gameObject.tag=="Coins")
        //{
        //    collision.gameObject.SetActive(false);
        //    scoreValue += 1;
        //    SetScore();
        //}
    }

    public void SetScore()
    {
        scoreValue += 1;
        score.text = "Coins:" + scoreValue;
    }
}

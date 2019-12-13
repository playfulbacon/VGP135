using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;
    private float timer;
    bool isGameOver = false;

    public void GameOver()
    {
        isGameOver = true;
    }

    private void Start()
    {
        timer = mainTimer;
    }

    private void Update()
    {
        if(FindObjectOfType<Ball>().IsGameOver())
        {
            uiText.text = timer.ToString("F");
        }
        else if (timer >= 0.01f)
        {
            uiText.text = timer.ToString("F");
            timer -= Time.deltaTime;
        }
        else if (!isGameOver)
        {
            isGameOver = true;
            uiText.text = "0.00";
            FindObjectOfType<Ball>().GameOver();
        }      
    }
}

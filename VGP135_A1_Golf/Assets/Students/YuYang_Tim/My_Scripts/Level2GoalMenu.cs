using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2GoalMenu : MonoBehaviour
{
    public string levelSelectSceneName;
    public GameObject goalMenuHolder;
    public GameObject goalMenuHolder2;


    void Start()
    {
        SetGoalMenu(false);
        SetGoalMenu2(false);
    }

    public void SetGoalMenu(bool value)
    {
        goalMenuHolder.SetActive(value);
    }

    public void SetGoalMenu2(bool value)
    {
        goalMenuHolder2.SetActive(value);
    }

    public void PlayAgainButtonDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelectButtonDown()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }
}


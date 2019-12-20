using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalMenuYuYang : MonoBehaviour
{
    public string levelSelectSceneName;
    public GameObject goalMenuHolder;

    void Start()
    {
        SetGoalMenu(false);
    }

    public void SetGoalMenu(bool value)
    {
        goalMenuHolder.SetActive(value);
    }

    public void PlayAgainButtonDown()
    {
        Debug.Log("3");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelectButtonDown()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }
}

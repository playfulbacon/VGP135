using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalMenu : MonoBehaviour
{
    public static GoalMenu instance;
    public bool gameOver = false;

    public string levelSelectSceneName;
    public GameObject goalMenuHolder;

    void Start()
    {
        SetGoalMenu(false);

        instance = GetComponent<GoalMenu>();
        StartCoroutine("LoseTime");
        Time.timeScale = 1.0f;
    }

    public void SetGoalMenu(bool value)
    {
        goalMenuHolder.SetActive(value);
    }

    public void PlayAgainButtonDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelectButtonDown()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            Ball.instance.MoveCounter--;
        }
    }

}

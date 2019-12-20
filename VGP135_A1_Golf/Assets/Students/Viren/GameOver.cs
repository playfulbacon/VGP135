using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    public string levelSelectSceneName;
    public GameObject gameOverHolder;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        SetGameOverMenu(false);

        instance = GetComponent<GameOver>();
        StartCoroutine("LoseTime");
        Time.timeScale = 1.0f;
    }

    public void SetGameOverMenu(bool value)
    {
        gameOverHolder.SetActive(value);
    }

    public void LevelSelectButtonDown()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }

    public void RestartLevelButtonDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Ball.instance.MoveCounter--;
        }
    }
}

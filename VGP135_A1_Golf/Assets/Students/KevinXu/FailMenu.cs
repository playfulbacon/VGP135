using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailMenu : MonoBehaviour
{
    public string levelSceneName;
    public GameObject FailMenuHolder;

    void Start()
    {
        SetFailMenu(false);
    }

    public void SetFailMenu(bool value)
    {
        FailMenuHolder.SetActive(value);
    }

    public void PlayAgainButtonDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelectButtonDown()
    {
        SceneManager.LoadScene(levelSceneName);
    }

}

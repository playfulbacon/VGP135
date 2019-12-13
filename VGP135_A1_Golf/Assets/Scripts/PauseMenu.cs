using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string levelSelectSceneName;
    public GameObject pauseMenuHolder;
    public GameObject pauseButtonHolder;
    bool pause;

    private void Awake()
    {
        SetPauseMenu(false);
    }

    public void OnPause()
    {
        SetPauseMenu(true);
        Time.timeScale = 0.0f;
    }

    public void OnContinue()
    {
        SetPauseMenu(false);
        Time.timeScale = 1.0f;
    }

    public void SetPauseMenu(bool value)
    {
        pauseMenuHolder.SetActive(value);
        pauseButtonHolder.SetActive(!value);
    }

    public void ReplayBtnMenu() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void OnLevelSelect()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }
}

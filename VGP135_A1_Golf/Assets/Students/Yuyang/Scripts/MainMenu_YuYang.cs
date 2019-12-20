using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuYuYnag : MonoBehaviour
{
    public string startScene;

    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }
}

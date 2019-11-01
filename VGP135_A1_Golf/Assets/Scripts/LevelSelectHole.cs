using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectHole : Goal
{
    public TextMesh text;
    public string sceneName;

    void Start()
    {
        text.text = sceneName;
    }

    public override void OnHit()
    {
        SceneManager.LoadScene(sceneName);
    }

    public override void OnDrop()
    {
        SceneManager.LoadScene(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectHoleYuYang : GoalYuYang
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
}

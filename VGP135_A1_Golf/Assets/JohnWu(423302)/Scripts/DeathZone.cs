using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public string startScene;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        FindObjectOfType<GoalMenu>().SetGoalMenu(true);
    }
}


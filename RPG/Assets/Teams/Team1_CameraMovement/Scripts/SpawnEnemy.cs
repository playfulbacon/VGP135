using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int TotalSpawn = 100;
    public GameObject Enemy;
    private List<GameObject> mListEnemies;
    
    void Start()
    {
        mListEnemies = new List<GameObject>(TotalSpawn);
        for (int i = 0; i < TotalSpawn; ++i)
        {
            mListEnemies.Add(Enemy);
        }
        SpwanEnemies(TotalSpawn);
    }

    private void SpwanEnemies(int total)
    {
        Vector3 spawnPoints;
        for (int i = 0; i < TotalSpawn; ++i)
        {
        }
    }
}
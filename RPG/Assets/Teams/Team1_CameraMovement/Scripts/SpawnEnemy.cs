using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int TotalSpawn = 100;
    public GameObject terrain;
    public Vector3 spawnRange;
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
        Vector3 spawnPosition;
        for (int i = 0; i < TotalSpawn; ++i)
        {
            spawnPosition = new Vector3(Random.Range(-spawnRange.x / 2 + obstacleWidth, spawnRange.x / 2 - obstacleWidth),
                                              terrain.transform.position.y + (obstacleHeight / 2),
                                              Random.Range(-spawnRange.z / 2 + obstacleWidth, spawnRange.z / 2 - obstacleWidth));


            Instantiate(Enemy, spawnPosition, Quaternion.identity);;
        }
    }
}
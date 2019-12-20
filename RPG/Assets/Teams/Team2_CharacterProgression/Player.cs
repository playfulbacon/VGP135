using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Test vars
    bool canAttack = false;

    Stats stats;

    public GameObject autoAttackObject;

    int currentExperience = 0;
    int nextLevelExperienceRequired = 10;

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        print("take damage");
    }

    public float GetAttackSpeed()
    {
        return stats.AttackSpeed;
    }
    public void LevelUpStats()
    {

        // Allow user to level up as well

    }
    public void GiveExperience(int xpAmount)
    {
        currentExperience += xpAmount;
        if (currentExperience >= nextLevelExperienceRequired)
        {
            LevelUpStats();
        }
    }
    public void AutoAttack(Enemy enemyTarget)
    {
        Debug.Log("auto attack");
        // Instantiate an arrow object with a forward vector facing the enemyTarget position. Then gives the target var of the arrow the enemy GameObject enemyTarget
        Vector3 direction = enemyTarget.transform.position - transform.position;
        direction.Normalize();
        GameObject go = Instantiate(autoAttackObject, transform.position + (direction * 1.0f), Quaternion.identity);
        go.transform.forward = direction;
        go.GetComponent<Arrow>().Target = enemyTarget.gameObject;
    }
    public void TeleportAttack()
    {
        Debug.LogWarning("Teleport attack");
        
        for(int i = 0; i < 36; ++i)
        {
            //Vector3 dir = Quaternion.AngleAxis(i * 36.0f, Vector3.up).eulerAngles; /** transform.position*/;
            float radius = 5.0f;
            Vector3 targetPosition = new Vector3(Mathf.Sin(i * 10.0f) * radius, transform.position.y, Mathf.Cos(i * 36.0f) * radius) + transform.position;

            Vector3 dir = targetPosition - transform.position;
            dir.y = transform.position.y;

            Vector3 spawnPosition = transform.position + dir.normalized * 5.0f;
            spawnPosition.y += 1f;
            GameObject go = Instantiate(autoAttackObject, spawnPosition, Quaternion.identity);
            dir.y = 0.0f;
            go.transform.forward = dir.normalized;
            Debug.LogWarning("spawned thingy");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    // Test vars
    public GameObject enemy;
    bool canAttack = false;

    Stats stats;

    public GameObject autoAttackObject;

    int currentExperience = 0;
    int nextLevelExperienceRequired = 10;

    public int dexterityOnLevelUp = 2;
    public int strengthOnLevelUp = 1;


    // Public attack function (given an enemy)
    // Public XP gain function

    public void Start()
    {
        stats = this.GetComponent<Stats>();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     // For testing purposes
        {
            canAttack = true;
        }

        if(canAttack)
        {
            AutoAttack(enemy);
            canAttack = false;
        }
    }

    public void LevelUpStats()
    {
        stats.ModifyBaseStrength(strengthOnLevelUp);
        stats.ModifyBaseDexterity(dexterityOnLevelUp);

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
    public void AutoAttack(GameObject enemyTarget)
    {
        // Instantiate an arrow object with a forward vector facing the enemyTarget position. Then gives the target var of the arrow the enemy GameObject enemyTarget
        Instantiate(autoAttackObject, transform.position, Quaternion.LookRotation((enemyTarget.transform.position - transform.position), Vector3.up)).GetComponent<Arrow>().target = enemyTarget;
    }
}
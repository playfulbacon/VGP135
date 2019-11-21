using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    int currentExperience = 0;
    int nextLevelExperienceRequired = 10;

    public int dexterityOnLevelUp = 2;
    public int strengthOnLevelUp = 1;


    // Public attack function (given an enemy)
    // Public XP gain function

    public void Start()
    {
        stats = this.GetComponent<Stats>;
    }

    public void LevelUpStats()
    {
        ModifyBaseStrength(strengthOnLevelUp);
        ModifyBaseDexterity(dexterityOnLevelUp);

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

    }
}
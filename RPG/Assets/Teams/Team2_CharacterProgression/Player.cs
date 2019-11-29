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

    public int dexterityOnLevelUp = 2;
    public int strengthOnLevelUp = 1;

    private void Awake()
    {
        stats = this.GetComponent<Stats>();
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
    public void AutoAttack(Enemy enemyTarget)
    {
        // Instantiate an arrow object with a forward vector facing the enemyTarget position. Then gives the target var of the arrow the enemy GameObject enemyTarget
        GameObject go = Instantiate(autoAttackObject, transform.position, Quaternion.LookRotation((enemyTarget.transform.position - transform.position), Vector3.up));
        go.GetComponent<Arrow>().Target = enemyTarget.gameObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Basic Stats
    int baseStrength;
    int baseIntelligence;
    int baseConstitution;
    int baseWisdom;
    int baseDexterity;

    // Public attack function (given an enemy)
    // Public XP gain function

    void Start()
    {
        // Based on class, modify stats
    }

    // Returns the base Strength score before modifiers
    public int GetBaseStrength()
    {
        return baseStrength;
    }
    // Returns the base Intelligence score before modifiers
    public int GetBaseIntelligence()
    {
        return baseIntelligence;
    }
    // Returns the base Constitution score before modifiers
    public int GetBaseConstitution()
    {
        return baseConstitution;
    }
    // Returns the base Wisdom before score modifiers
    public int GetBaseWisdom()
    {
        return baseWisdom;
    }
    // Returns the base stat before score modifiers
    public int GetBaseDexterity()
    {
        return baseDexterity;
    }
    public float GetAttackSpeed()
    {
        // Returns the time it waits before making another attack
        return (float)(1 / baseDexterity);
    }
}
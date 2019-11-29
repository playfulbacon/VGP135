﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //protected Player plaer;
    protected int mCurrentHP;
    protected int mMaxHP = 100;
    protected int mAttack;
    protected int mEXP;
    protected float mAttackCooldown;
    protected float mAttackTracker = 0.0f;

    public abstract void Attack(Player player);
    public abstract void Move();

    protected List<Item> mLootTable = new List<Item>();

    protected abstract void CreateLootTable();

    protected List<Item> LootCalculation()
    {
        List<Item> loots = new List<Item>();
        for (int i = 0; i < mLootTable.Count; i++)
        {
            int randomNumber = Random.Range(0, 100);
            if (randomNumber < mLootTable[i].GetDropChance())
                loots.Add(mLootTable[i]);
        }
        return loots;
    }

    protected void Start()
    {
        mCurrentHP = mMaxHP;
        //player = FindObjectOfType<Player>();
    }

    protected void FixedUpdate()
    {
        mAttackTracker += Time.deltaTime;
    }

    protected void Update()
    {
        DeathCheck();
    }

    //public int GetEXP() { return mEXP; }
    private void DeathCheck()
    {
        if(mCurrentHP <= 0)
        {
            //player.GainEXP(mEXP);
            Inventory inven = FindObjectOfType<Inventory>();
            if (inven != null)
            inven.AddItemsToInventory(LootCalculation());
            Destroy(gameObject);
            Debug.Log("Enemy died");
        }
    }

    public int GetAttackValue() { return mAttack; }
    public int GetCurrentHP() { return mCurrentHP; }
    public void TakeDamage(int playerDamage)
    {
        mCurrentHP -= playerDamage;
        DeathCheck();
    }
}

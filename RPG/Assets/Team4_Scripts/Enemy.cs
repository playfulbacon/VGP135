using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //protected Player plaer;
    protected int mCurrentHP;
    protected int mMaxHP;
    protected int mAttack;
    protected int mEXP;
    protected float mAttackCooldown;
    protected float mAttackTracker = 0.0f;

    public abstract void Attack();
    public abstract void Move();

    private void Start()
    {
        mCurrentHP = mMaxHP;
        //player = FindObjectOfType<Player>();
    }
    public int GetAttackValue() { return mAttack; }
    public int GetCurrentHP() { return mCurrentHP; }
    public void TakeDamage(int playerDamage)
    {
        mCurrentHP -= playerDamage;
        DeathCheck();
    }
    //public int GetEXP() { return mEXP; }
    private void DeathCheck()
    {
        if(mCurrentHP <= 0)
        {
            //Player player = FindObjectsOfType<Player>();
            //player.GainEXP(mEXP);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    Vector3 mRandomDirection;

    float mRandomDirectionCooldown = 1.0f;
    float mRandomDirectionTracker;

    protected override void CreateLootTable()
    {
        HealthPotion potion = new HealthPotion();
        mLootTable.Add(potion);

        Debug.Log("Slime's loot table:");
        foreach (var item in mLootTable)
        {
            Debug.Log(item.GetType().Name);
        }
    }

    private void Start()
    {
        base.Start();
        SetRandomDirection();
        mAttackCooldown = 2.0f;
        CreateLootTable();
    }

    void SetRandomDirection()
    {
        mRandomDirection = new Vector3(Random.Range(-5, 5), transform.position.y, Random.Range(-5, 5));
    }

    private void FixedUpdate()
    {
        Move();
        mAttackTracker += Time.deltaTime;
        mCurrentHP--;
    }

    private void Update()
    {
        base.Update();
    }


    public override void Attack()
    {
        //player.TakeDamage(mAttack);

    }

    public override void Move()
    {
        if(mRandomDirectionTracker > mRandomDirectionCooldown)
        {
            SetRandomDirection();
            mRandomDirectionTracker = 0.0f;
        }
        else
        {
            transform.position += mRandomDirection * Time.deltaTime;
        }
        if (mRandomDirectionTracker < 10f)
            mRandomDirectionTracker += Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        //Player player = collison.GetComponent<Player>();
        if ((mAttackTracker > mAttackCooldown) /* && (player != null)*/)
        {
            //Attack();
            mAttackTracker = 0.0f;
        }
    }
}

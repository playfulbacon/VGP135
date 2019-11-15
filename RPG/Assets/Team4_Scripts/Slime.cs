using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    Vector3 mRandomDirection;

    float mRandomDirectionCooldown = 1.0f;
    float mRandomDirectionTracker;
    private void Start()
    {
        SetRandomDirection();
        mAttackCooldown = 2.0f;
    }

    void SetRandomDirection()
    {
        mRandomDirection = new Vector3(Random.Range(-5, 5), transform.position.y, Random.Range(-5, 5));
    }

    private void FixedUpdate()
    {
        Move();
        mAttackTracker += Time.deltaTime;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackManager : MonoBehaviour
{
    //Player player;
    Enemy[] enemies;
    Enemy closestTarget;
    float closestDistance = float.MaxValue;
    float attackCooldown = 0.0f;
    public void GetClosestTarget()
    {
        enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            //if (Vector3.Distance(player.transform.position, enemy.transform.position) < closestDistance)
            //{
            //    closestTarget = enemy;
            //    closestDistance = Vector3.Distance(player.transform.position, enemy.transform.position);
            //}
        }
    }

    void PlayerAttack()
    {
        if (closestTarget != null /*&& !player.GetComponent<Move>().IsPlayerMoving(); && attackCooldown > player.GetAttackSpeed()*/)
        {
            //player.Attack(closestTarget);
            attackCooldown = 0.0f;
        }
        if (attackCooldown < 10f)
            attackCooldown += Time.deltaTime;
    }

    private void Start()
    {
        //player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        PlayerAttack();
    }
}

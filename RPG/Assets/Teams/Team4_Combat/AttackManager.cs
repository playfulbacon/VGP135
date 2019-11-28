﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackManager : MonoBehaviour
{
    Player player;
    Enemy[] enemies;
    Enemy closestTarget;
    float closestDistance = float.MaxValue;
    float attackCooldown = 0.0f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {

    }

    public void GetClosestTarget()
    {
        enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(player.transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestTarget = enemy;
                closestDistance = distance;
            }
        }
    }

    void PlayerAttack()
    {
        if (closestTarget != null && !player.GetComponent<PlayerMovement>().IsMoving && attackCooldown > player.GetAttackSpeed())
        {
            player.AutoAttack(closestTarget);
            //GetComponent<PlayerAnimationController>().SetAttackAnimation();
            //GetComponent<PlayerMovement>().RotateTowards(closestTarget.transform);
            attackCooldown = 0.0f;
        }
        if (attackCooldown < 10f)
            attackCooldown += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        GetClosestTarget();
        PlayerAttack();
    }
}

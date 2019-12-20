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
        closestDistance = float.MaxValue;
        closestTarget = null;
        foreach (Enemy enemy in enemies)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, (enemy.transform.position - transform.position), out hit);
            if (hit.collider && !hit.collider.CompareTag("Enemy"))
            {
                continue;
            }
            float distance = Vector3.Distance(player.transform.position, enemy.transform.position);
            if (distance < closestDistance && (closestTarget != null))
            {
                closestTarget = enemy;
                distance = closestDistance;
            }
        }
    }

    void PlayerAttack()
    {
        if (closestTarget != null && !player.GetComponent<PlayerMovement>().IsMoving && attackCooldown > player.GetAttackSpeed())
        {
            //player.AutoAttack(closestTarget);
            GetComponent<AttackDelayModule>().AttackWithDelay(closestTarget);
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

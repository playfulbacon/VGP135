using System.Collections;
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
        if (player != null)
            Debug.Log("found player AWAKE");
    }

    private void Start()
    {
        if (player != null)
            Debug.Log("found player START");
    }

    public void ResetClosestDistance()
    {
        closestDistance = float.MaxValue;
    }

    public void GetClosestTarget()
    {
        enemies = FindObjectsOfType<Enemy>();
        closestDistance = float.MaxValue;
        closestTarget = null;
        foreach (Enemy enemy in enemies)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position,(enemy.transform.position - transform.position), out hit);
            if (hit.collider && !hit.collider.CompareTag("Enemy"))
            {
                continue;
            }
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestTarget = enemy;
                closestDistance = distance;
            }
        }
    }

    void PlayerAttack()
    {
        player = GetComponent<Player>();

        if (closestTarget != null && player && !player.GetComponent<PlayerMovement>().IsMoving && attackCooldown > player.GetAttackSpeed())
        {
            //player.AutoAttack(closestTarget);
            GetComponent<AttackDelayModule>().AttackWithDelay(closestTarget);
            attackCooldown = 0.0f;
        }
        if (attackCooldown < 10f)
            attackCooldown += Time.deltaTime;
    }

    private void Update()
    {
        GetClosestTarget();
    }
    private void FixedUpdate()
    { 
        PlayerAttack();
    }
}

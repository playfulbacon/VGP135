using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject target;
    public GameObject Target { set { target = value; } }
    public float moveSpeed = 10.0f;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }
    }
}
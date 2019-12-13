using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionRange = 3.0f;
    public float explosionTimer = 3.0f;
    public Color start = Color.yellow;
    public Color end = Color.red;
    private Renderer render;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(CastExplosion());
            rb.isKinematic = true;
        }
    }

    public IEnumerator CastExplosion()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / explosionTimer;
            render.material.color = Color.Lerp(start,end,t);
            yield return null;
        }
        var exp = Physics.SphereCastAll(transform.position, explosionRange, transform.forward);
        render.enabled = false;
        yield return null;
        foreach(var hit in exp)
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
        yield return null;
        gameObject.SetActive(false);
    }
}

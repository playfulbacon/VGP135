using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    public float resetTime = 0.5f;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger!");
        if (other.GetComponentInParent<Ball_Amy>() != null)
        {
            other.gameObject.SetActive(false);
            StartCoroutine("Fall");
           
        }
    }

    IEnumerator Fall()
    {
        float time = resetTime;
        while (time > 0.0f)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return null;
    }
}

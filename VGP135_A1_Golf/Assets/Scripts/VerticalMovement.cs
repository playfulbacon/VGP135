using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float startDelay;
    public float timer;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        timer = startDelay;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= (Time.deltaTime * 1);

        if( timer < 0.0f)
        {
            Vector3 yMove = new Vector3(0, speed * Time.deltaTime, 0);
            gameObject.transform.position -= yMove;

        }
    }
}

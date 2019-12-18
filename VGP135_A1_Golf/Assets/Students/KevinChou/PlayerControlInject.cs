using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlInject : MonoBehaviour
{
    public float jumpForce = 10.0f;
    Touch mTouch;
    public GameObject player;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Ball");
        }
        else if(player != null)
        {
            if(rb == null)
            {
                rb = player.GetComponent<Rigidbody>();
            }
            if(Input.touchCount == 2 && rb != null)
            {
                rb.AddForce(new Vector3(0, jumpForce, 0));
            }
        }
    }
}

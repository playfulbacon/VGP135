using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMovement : MonoBehaviour
{
    SpringJoint springJoint;
    Rigidbody myRigidbody;
    bool startTimer;
    [Tooltip("How long does it need to wait for applying velocity")]
    public float delayTime;
    public float forceToApply;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        springJoint = GetComponent<SpringJoint>();
        myRigidbody = GetComponent<Rigidbody>();
        timer = delayTime;
        startTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
            timer -= (Time.deltaTime * 1.0f);
        if (myRigidbody)
        {
            if (myRigidbody.velocity.x < 0.2f && myRigidbody.velocity.x > -0.2f && !startTimer)
                startTimer = true;

            if(timer < 0.0f)
            {
                Debug.Log("Apply foce");
                myRigidbody.velocity -= new Vector3(forceToApply, 0.0f);
                startTimer = false;
                timer = delayTime;
            }
        }

        //Debug.Log("Spring Current force " + springJoint.currentForce);
        Debug.Log("Obj velocity =  " + myRigidbody.velocity);
    }
}

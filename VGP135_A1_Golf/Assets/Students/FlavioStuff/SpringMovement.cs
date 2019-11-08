using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMovement : MonoBehaviour
{
    SpringJoint springJoint;
    new Rigidbody rigidbody;
    bool startTimer;
    [Tooltip("How long does it need to wait for applying velocity")]
    public float delayTime;
    public float forceToApply;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        springJoint = GetComponent<SpringJoint>();
        rigidbody = GetComponent<Rigidbody>();
        timer = delayTime;
        startTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
            timer -= (Time.deltaTime * 1.0f);
        if (rigidbody)
        {
            if (rigidbody.velocity.x < 0.2f && rigidbody.velocity.x > -0.2f && !startTimer)
                startTimer = true;

            if(timer < 0.0f)
            {
                Debug.Log("Apply foce");
                rigidbody.velocity -= new Vector3(forceToApply, 0.0f);
                startTimer = false;
                timer = delayTime;
            }
        }

        //Debug.Log("Spring Current force " + springJoint.currentForce);
        Debug.Log("Obj velocity =  " + rigidbody.velocity);
    }
}

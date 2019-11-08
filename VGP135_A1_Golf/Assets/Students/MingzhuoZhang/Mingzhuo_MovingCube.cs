using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mingzhuo_MovingCube : MonoBehaviour
{
    public float mStartHeight;
    public float mMovingRange;
    public float mMovingSpeed;

    private Vector3 mStartPos;
    private Vector3 mFianlPos;
    private Vector3 mMovingSpeedVec;
    void Awake()
    {
        mStartPos = new Vector3(transform.position.x, mStartHeight, transform.position.z);
        mFianlPos = new Vector3(transform.position.x, mStartHeight + mMovingRange, transform.position.z);
        mMovingSpeedVec = new Vector3(0.0f, mMovingSpeed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += mMovingSpeedVec * Time.deltaTime;

        float currentHeight = (transform.position - mStartPos).y;
        if ( currentHeight > mMovingRange )
        {
            transform.position = mFianlPos;
            mMovingSpeedVec.y *= -1;
        }
        else if(currentHeight < 0.0f)
        {
            transform.position = mStartPos;
            mMovingSpeedVec.y *= -1;
        }
    }
}

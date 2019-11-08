using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mingzhuo_Rotatable : MonoBehaviour
{
    public Quaternion mDestinationRotation;
    public Mingzhuo_TriggerObject[] Z_0_RotationTriggers;
    public Mingzhuo_TriggerObject[] Z_90_RotationTriggers;
    public Mingzhuo_TriggerObject[] Z_180_RotationTriggers;
    public Mingzhuo_TriggerObject[] Z_270_RotationTriggers;

    void Awake()
    {
        mDestinationRotation = new Quaternion();
    }

    void Update()
    {
        foreach (var triggerObj in Z_0_RotationTriggers)
        {
            if (triggerObj.mIsOn)
            {
                mDestinationRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
        }

        foreach (var triggerObj in Z_90_RotationTriggers)
        {
            if (triggerObj.mIsOn)
            {
                mDestinationRotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
            }
        }

        foreach (var triggerObj in Z_180_RotationTriggers)
        {
            if (triggerObj.mIsOn)
            {
                mDestinationRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            }
        }

        foreach (var triggerObj in Z_270_RotationTriggers)
        {
            if (triggerObj.mIsOn)
            {
                mDestinationRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            }
        }
 
        transform.localRotation = Quaternion.Slerp(transform.localRotation, mDestinationRotation, 10.0f * Time.deltaTime);
    }
}

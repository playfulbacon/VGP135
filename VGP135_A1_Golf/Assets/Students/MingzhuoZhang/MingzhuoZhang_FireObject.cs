using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MingzhuoZhang_FireObject : MonoBehaviour
{
    public ParticleSystem mEmitter;
    public bool mIsOnfire = false;

    void Start()
    {
        if (mIsOnfire)
            mEmitter.Play();
        else
            mEmitter.Stop();
    }

    public void OnCollisionEnter(Collision other)
    {
        var otherFire = other.gameObject.GetComponent<MingzhuoZhang_FireObject>();
        if (otherFire == null)
            return;

        if (mIsOnfire && !otherFire.mIsOnfire)
        {
            otherFire.mIsOnfire = true;
            otherFire.mEmitter.Play();
        }

    }

}

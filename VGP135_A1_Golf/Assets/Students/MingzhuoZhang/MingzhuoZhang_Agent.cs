using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[RequireComponent(typeof(NavMeshAgent))]
public class MingzhuoZhang_Agent : MonoBehaviour
{
    private NavMeshAgent mAgent;
    private MingzhuoZhang_FireObject mPlayer;
    public float mPanicRange;
    void Start()
    {
        mAgent = GetComponent<NavMeshAgent>();
        mPlayer = GameObject.Find("Ball").GetComponent<MingzhuoZhang_FireObject>();
        Assert.IsNotNull(mPlayer, "[MingzhuoZhang_Agent] can not find Ball's fireobject component");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, mPlayer.transform.position) < mPanicRange && mPlayer.mIsOnfire)
        {
            mAgent.destination = transform.position + Vector3.Normalize(transform.position - mPlayer.transform.position) * mPanicRange;
        }
    }
}

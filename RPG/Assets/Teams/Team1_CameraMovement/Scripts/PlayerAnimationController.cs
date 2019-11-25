using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator mAnimator;

    private void Awake()
    {
        mAnimator = GetComponentInChildren<Animator>();
        Assert.IsNotNull(mAnimator, "[PlayerAnimationController]--- mAnimator is null");
    }
    // Update is called once per frame
    void Update()
    {
        //mAnimator.transform
    }
}

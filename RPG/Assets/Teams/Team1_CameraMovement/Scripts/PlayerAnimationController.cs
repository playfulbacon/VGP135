using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEditor.Animations;

public class PlayerAnimationController : MonoBehaviour
{
    private Player mPlayer;
    private Animator mAnimator;
    private PlayerMovement mPlayerMovment;
    private float mDefaultAttakSpeed;

    private void Awake()
    {
        mPlayer = GetComponent<Player>();
        Assert.IsNotNull(mPlayer, "[PlayerAnimationController]--- mPlayer is null");

        mAnimator = GetComponentInChildren<Animator>();
        Assert.IsNotNull(mAnimator, "[PlayerAnimationController]--- mAnimatorController is null");
        mAnimator.runtimeAnimatorController = FindObjectOfType<ModelManager>().GetAnimator(GetComponentInChildren<ClassGetter>().PlayerClass);

        var mAnimatorController = mAnimator.runtimeAnimatorController as AnimatorController;
        Assert.IsNotNull(mAnimatorController, "[PlayerAnimationController]--- mAnimatorController is null");
        mPlayerMovment = GetComponentInChildren<PlayerMovement>();
        Assert.IsNotNull(mPlayerMovment, "[PlayerAnimationController]--- mPlayer is null");

        ChildAnimatorState[] states = mAnimatorController.layers[0].stateMachine.states;

        foreach (var state in states)
        {
            if (state.state.name == "attack")
            {
                AnimationClip clip = state.state.motion as AnimationClip;
                mDefaultAttakSpeed = clip.length;
                Debug.Log(clip.name);
                break;
            }
        }
        Debug.Log(mDefaultAttakSpeed);
        
        

    }
    // Update is called once per frame
    void Update()
    {
        mAnimator.SetFloat("speed", mPlayerMovment.Agent.velocity.magnitude);
        UpdateAttackAnimationSpeed_mutiplier(mPlayer.GetAttackSpeed());
    }

    void LateUpdate()
    {
        mAnimator.SetInteger("state", 0);
    }

    public void SetAttackAnimation()
    {
        mAnimator.SetInteger("state", 1);
    }

    public void UpdateAttackAnimationSpeed_mutiplier(float newAttackSpeed)
    {
        mAnimator.SetFloat("attackSpeedMutiplier", mDefaultAttakSpeed / newAttackSpeed );
    }
}

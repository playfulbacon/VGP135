using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEditor.Animations;

public class PlayerAnimationController : MonoBehaviour
{
    private ModelManager.ClassModelData mModelData;
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
        mModelData = FindObjectOfType<ModelManager>().GetModelData(GetComponentInChildren<ClassGetter>().PlayerClass);
        mAnimator.runtimeAnimatorController = mModelData.mAnimationController;

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

    public void SetAttackAnimation()
    {
        mAnimator.SetInteger("state", 1);
    }

    public void SetIdleAnimation()
    {
        mAnimator.SetInteger("state", 0);
    }

    public void UpdateAttackAnimationSpeed_mutiplier(float newAttackSpeed)
    {
        mAnimator.SetFloat("attackSpeedMutiplier", mDefaultAttakSpeed / newAttackSpeed );
    }

    public float GetShootDelay()
    {
        return mModelData.mShootDelay * mPlayer.GetAttackSpeed();
    }
}

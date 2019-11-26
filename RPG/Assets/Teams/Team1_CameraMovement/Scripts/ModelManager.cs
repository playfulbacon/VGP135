using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ModelManager : MonoBehaviour
{
    [System.Serializable]
    public struct ClassModelData
    {
        public string mName;
        public RuntimeAnimatorController mAnimationController;
    }

    public ClassModelData[] mModelDatas = new ClassModelData[1];

    public RuntimeAnimatorController GetAnimator(ClassGetter.CharactorClass charactorClass)
    {
        if (charactorClass == ClassGetter.CharactorClass.None)
        {
            Debug.Log("[ModelManager]--- None ClassType detected. Player gameObject may not have any class scrpit");
            return mModelDatas[0].mAnimationController;
        }
        else
        {
            return mModelDatas[(int)charactorClass].mAnimationController;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassGetter : MonoBehaviour
{
    public enum CharactorClass
    {
        None = -1,
        Ranger = 0,
        Wizard = 1,
        //Mage = 2
    }

    private CharactorClass mPlayerClass;

    public CharactorClass PlayerClass { get { return mPlayerClass; }}


    void Awake()
    {
        if (GetComponent<Ranger>() != null)
            mPlayerClass = CharactorClass.Ranger;
        //else if (GetComponent<Wizard>() != null)
        //    mPlayerClass = CharactorClass.Wizard;
        //else if (GetComponent<Mage>() != null)
        //    mPlayerClass = CharactorClass.Mage;
    }
}

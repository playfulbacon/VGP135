using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassGetter : MonoBehaviour
{
    public enum CharactorClass
    {
        None = -1,
        Ranger = 0,
        //Assassin = 1,
        //Mage = 2
    }

    private CharactorClass mPlayerClass;

    public CharactorClass PlayerClass { get { return mPlayerClass; }}


    void Awake()
    {
        if (GetComponent<Ranger>() != null)
            mPlayerClass = CharactorClass.Ranger;
        //else if (GetComponent<Assassin>() != null)
        //    mPlayerClass = CharactorClass.Assassin;
        //else if (GetComponent<Mage>() != null)
        //    mPlayerClass = CharactorClass.Mage;
    }
}

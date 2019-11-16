using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected int mAttack;

    public int GetWeaponAttack() { return mAttack; }
}
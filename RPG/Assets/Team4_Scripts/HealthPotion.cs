using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Consumable
{
    int mRecoverAmount = 10;

    public override void UseItem()
    {
        if (mItemCount > 0)
        {
            ConsumeItem();
            //Player player = FindObjectsOfType<Player>();
            //player.Heal(mRecoverAmount);
        }
    }

    private void Start()
    {
        mGrade = ItemGrade.mCommon;
        CalculateDropChance();
    }
}
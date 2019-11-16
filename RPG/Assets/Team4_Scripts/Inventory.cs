using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> items = new List<Item>();

    public void AddItemToInventory(List<Item> loots)
    {
        foreach (var loot in loots)
        {
            if (loot is Consumable)
            {
                foreach (var item in items)
                {
                    if (item.GetType().Equals(loot.GetType()))
                    {
                        var lootTemp = loot as Consumable;
                        var itemTemp = item as Consumable;
                        itemTemp.IncreaseItemCount(lootTemp.GetItemCount());
                        return;
                    }
                }
                items.Add(loot);
            }
            else
            {
                items.Add(loot);
            }
        }
        LogItems();
    }

    public void UseItem(int index)
    {
        if (index < items.Count)
            items[index].UseItem();
    }
    //test function
    void LogItems()
    {
        if(items.Count > 0)
            Debug.Log("List of looted items added to inventory");
        foreach (var item in items)
        {
            Debug.Log(item.GetType().Name);
        }

    }
}

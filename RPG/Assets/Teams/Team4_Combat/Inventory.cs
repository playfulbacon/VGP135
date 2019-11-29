using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> items = new List<Item>();

    public void AddItemsToInventory(List<Item> loots)
    {
        foreach (var loot in loots)
        {
            AddItem(loot);
        }
        LogItems();
    }

    private void AddItem(Item loot)
    {
        if (loot is Consumable)
        {
            foreach (var item in items)
            {
                if (item.GetType().Equals(loot.GetType()))
                {
                    var tempLoot = loot as Consumable;
                    var tempItem = item as Consumable;
                    tempItem.IncreaseItemCount(tempLoot.GetItemCount());
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

    public void UseItem(int index)
    {
        if (index < items.Count && items[index] is Consumable)
        {
            items[index].GetComponent<Consumable>().UseItem();
            if(items[index].GetComponent<Consumable>().GetItemCount() == 0)
            {
                items.Remove(items[index]);
            }
        }
    }

    public void EquipItem(int index)
    {
        if (index < items.Count && items[index] is Weapon)
        {
            //var tempWeapon = items[index] as Weapon;
            //Player player = GetComponent<Player>();
            //if(player.GetEquippedWeapon() == null)
            //{
            //    player.SetEuippedWeapon(items[index]);
            //    tempWeapon.EquipItem();
            //}
            //else if(player.GetEquippedWeapon() != items[index])
            //{
            //    player.GetEquippedWeapon().UnequipItem();
            //    player.SetEuippedWeapon(items[index]);
            //    tempWeapon.EquipItem();
            //}
        }
        else if(index < items.Count && items[index] is Armor)
        {
            //var tempArmor = items[index] as Armor;
            //Player player = GetComponent<Player>();
            //if (player.GetEquippedArmor() == null)
            //{
            //    player.SetEuippedArmor(items[index]);
            //    tempArmor.EquipItem();
            //}
            //else if (player.GetEquippedArmor() != items[index])
            //{
            //    player.GetEquippedArmor().UnequipItem();
            //    player.SetEuippedArmor(items[index]);
            //    tempArmor.EquipItem();
            //}
        }

    }

    public void UnEquipItem(int index)
    {
        if (index < items.Count && items[index] is Equipment)
        {
            var tempEquip = items[index] as Equipment;
            if (tempEquip.IsEquipped())
                tempEquip.UnEquipItem();
        }
    }


    //test function
    void LogItems()
    {
        if(items.Count > 0)
            Debug.Log("List of looted items added to inventory");
        foreach (var item in items)
        {
            if (item is Consumable)
            {
                var tempItem = item as Consumable;
                Debug.Log(tempItem.GetType().Name + "X" + tempItem.GetItemCount());
            }
            else
            {
                Debug.Log(item.GetType().Name);
            }
        }

    }
}

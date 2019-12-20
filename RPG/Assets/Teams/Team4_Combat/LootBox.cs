using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootBox : MonoBehaviour
{
    int lootCount;

    List<Item> lootTable;

    public Text text;

    public GameObject inventory;

    void Start()
    {
        lootCount = 3;
        text.text = lootCount.ToString();
        lootTable = new List<Item>();
        SetLootTable();
    }

    public void ObtainLoot()
    {
        if(lootCount > 0)
        {
            SetLootTable();
            int random = Random.Range(0, lootTable.Count);
            List<Item> tempList = new List<Item>();
            tempList.Add(lootTable[random]);
            inventory.GetComponent<Inventory>().AddItemsToInventory(tempList);
            --lootCount;
            text.text = lootCount.ToString();
        }
    }

    void SetLootTable()
    {
        lootTable.Clear();
        lootTable.Add(new HealthPotion());
        lootTable.Add(new FireHappy());
        lootTable.Add(new Frostmourne());
    }

    public void AddLootBoxCount()
    {
        lootCount++;
        text.text = lootCount.ToString();
    }
}

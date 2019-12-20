using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform items;
    InventorySlot[] slots;

    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        slots = items.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        for(int i =0; i < slots.Length; i++)
        {
            if(i < inventory.items.Length)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].CLearSlot();
            }
        }
    }
}

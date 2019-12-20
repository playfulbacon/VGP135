using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region SingleTon
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;

    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChanged;

    public int space = 20;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefault)
        {
            if(items.Count >= space)
            {
                Debug.Log("No enough Space");
                return false;
            }
            items.Add(item);

            if (onItemChanged != null)
            {
                onItemChanged.Invoke();
            }
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChanged != null)
        {
            onItemChanged.Invoke();
        }
    }
}

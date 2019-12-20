using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public void AddItem(Item item)
    {
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void CLearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}

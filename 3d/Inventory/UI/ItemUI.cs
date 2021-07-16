using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image icon = null;
    public Text amount = null;
    public InventoryData_OS Bag { get; set; }
    public int Index { get; set; } = -1;

    public void SetItemUI(ItemDate_SO item, int itemAmount)
    {
        if (itemAmount == 0)
        {
            Bag.items[Index].itemDate = null;
            icon.gameObject.SetActive(false);
            return;
        }
        if (item != null)
        {
            // Debug.Log("UI active");
            icon.sprite = item.itemIcon;
            amount.text = itemAmount.ToString();
            icon.gameObject.SetActive(true);
        }
        else
        {
            icon.gameObject.SetActive(false);
        }
    }

    public ItemDate_SO GetItem()
    {
        return Bag.items[Index].itemDate;
    }
}

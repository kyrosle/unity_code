using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
[CreateAssetMenu(fileName = "Add Inventory",menuName = "Inventory/Inventory Data")]
public class InventoryData_OS : ScriptableObject
{
    public List<InventoryItem> items = new List<InventoryItem>();

    /// <summary>
    /// 添加物品;可堆叠(找到or找不到)
    /// </summary>
    /// <param name="newItemData"></param>
    /// <param name="amount"></param>
    public void AddItem(ItemDate_SO newItemData,int amount)
    {
        bool found = false;// 是否找到同类的物品

        if (newItemData.stackable)
        {
            foreach (var item in items)
            {
                if (item.itemDate == newItemData)
                {
                    found = true;
                    item.amount += amount;
                    break;
                } 
            } 
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemDate == null && !found)
            {
                items[i].itemDate = newItemData;
                items[i].amount = amount;
                break;
            } 
        }
    }
}
[System.Serializable]
public class InventoryItem
{
    public ItemDate_SO itemDate;
    public int amount;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum SlotType{BAG,WEAPON,ARMOR,ACTION}
public class SlotHolder : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public ItemUI itemUI;
    public SlotType SlotType;

    public void UpdateItem()
    {
        switch (SlotType)
        {
            case SlotType.BAG:
                itemUI.Bag = InventoryManager.Instance.inventoryData;
                break;
            case SlotType.ARMOR:
                itemUI.Bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.ACTION:
                itemUI.Bag = InventoryManager.Instance.actionData;
                break;
            case SlotType.WEAPON:
                // Debug.Log("wepon ui update");
                itemUI.Bag = InventoryManager.Instance.equipmentData;
                // 装备武器 切换武器
                if (itemUI.Bag.items[itemUI.Index]!=null)
                {
                    GameManager.Instance.playerState.ChangeWeapon(itemUI.Bag.items[itemUI.Index].itemDate); 
                }
                else
                {
                    GameManager.Instance.playerState.UnEquipWeapon();
                }
                break;
        }

        var item = itemUI.Bag.items[itemUI.Index];
        itemUI.SetItemUI(item.itemDate,item.amount);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount % 2 == 0)
        {
            UseItem(); 
        }
    }

    public void UseItem()
    {
        if(itemUI.GetItem()==null)
            return;
        if (itemUI.GetItem().itemType == ItemType.Useable&& itemUI.Bag.items[itemUI.Index].amount>0)
        {
             GameManager.Instance.playerState.ApplyHealth(itemUI.GetItem().useableData.healthPoint);

             itemUI.Bag.items[itemUI.Index].amount -= 1;
        }
        UpdateItem();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemUI.GetItem())
        {
            InventoryManager.Instance.itemTooltip.SetTooltip(itemUI.GetItem()); 
            InventoryManager.Instance.itemTooltip.gameObject.SetActive(true);
        }        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.itemTooltip.gameObject.SetActive(false); 
    }

    private void OnDisable()
    {
        InventoryManager.Instance.itemTooltip.gameObject.SetActive(false); 
    }
}

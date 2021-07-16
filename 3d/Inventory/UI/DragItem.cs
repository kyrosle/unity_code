using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 和ui组件产生互动
using UnityEngine.EventSystems;
[RequireComponent(typeof(ItemUI))]
public class DragItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private ItemUI currentItemUI;
    private SlotHolder currentHolder;
    private SlotHolder targetHolder;

    private void Awake()
    {
        currentItemUI = GetComponent<ItemUI>();
        currentHolder = transform.parent.GetComponent<SlotHolder>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //记录原始信息
        InventoryManager.Instance.currentDrag = new InventoryManager.DragData();
        // getcompentInParent!! 挂在itemui上的
        // 父级是slotholder
        InventoryManager.Instance.currentDrag.originalHolder = GetComponentInParent<SlotHolder>();
        InventoryManager.Instance.currentDrag.originalParent = (RectTransform) transform.parent;
        transform.SetParent(InventoryManager.Instance.dragCanvas.transform,true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //跟随鼠标移动
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //放下物品结束拖拽
        //是否指向ui物品
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (InventoryManager.Instance.CheckInInventoryUI(eventData.position) ||
                InventoryManager.Instance.CheckInActionUI(eventData.position) || InventoryManager.Instance.CheckInEquipmentUI(eventData.position))
            {
                // 鼠标进入的这个 物体上是否包含这个 slotholder
                if (eventData.pointerEnter.gameObject.GetComponent<SlotHolder>())
                    targetHolder = eventData.pointerEnter.gameObject.GetComponent<SlotHolder>();
                else
                    targetHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SlotHolder>();
                // 判断是否目标holder是我原holder
                if(targetHolder!=InventoryManager.Instance.currentDrag.originalHolder)
                    switch (targetHolder.SlotType)
                    {
                        case SlotType.BAG:
                            SwapItem();
                            break;
                        case SlotType.ARMOR:
                            if (currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].itemDate.itemType == ItemType.Armor)
                                SwapItem();
                            break;
                        case SlotType.ACTION:
                            if (currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].itemDate.itemType == ItemType.Useable)
                                SwapItem();
                            break;
                        case  SlotType.WEAPON:
                            if (currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index].itemDate.itemType == ItemType.Weapon)
                                SwapItem();
                            break;
                    }
                currentHolder.UpdateItem();
                targetHolder.UpdateItem();
            }
        }
        transform.SetParent(InventoryManager.Instance.currentDrag.originalParent);
        RectTransform t=transform as RectTransform;
        // Debug.Log("fix ok!!!");
        t.offsetMax = -Vector2.one * 5;
        t.offsetMin = Vector2.one * 5;
    }

    public void SwapItem()
    {
        var targetItem = targetHolder.itemUI.Bag.items[targetHolder.itemUI.Index];
        var tempItem = currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index];
        bool isSameItem = tempItem.itemDate == targetItem.itemDate;
        if (isSameItem && targetItem.itemDate.stackable)
        {
            targetItem.amount += tempItem.amount;
            tempItem.amount = 0;
            tempItem.itemDate = null;
        }
        else
        {
            currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index] = targetItem;
            targetHolder.itemUI.Bag.items[targetHolder.itemUI.Index] = tempItem;
        }
    }
}

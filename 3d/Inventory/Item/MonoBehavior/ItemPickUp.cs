using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemDate_SO itemDateSo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO: 将物品添加到背包
            InventoryManager.Instance.inventoryData.AddItem(itemDateSo,itemDateSo.itemAmount);            
            InventoryManager.Instance.inventoryUI.RefreshUI();
            //装备武器
            // GameManager.Instance.playerState.EquipWeapon(itemDateSo);
            
            Destroy(gameObject);
        } 
    }
}
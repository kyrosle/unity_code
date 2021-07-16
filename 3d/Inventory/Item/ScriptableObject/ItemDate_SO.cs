using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum ItemType
{
    Useable,Weapon,Armor
}
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item Data")]

public class ItemDate_SO : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemIcon;
    public int itemAmount;
    
    [TextArea]
    public string Description;

    public bool stackable;// 可堆叠

    [FormerlySerializedAs("iteamData")] [Header("Useabe Item")] 
    public UseableItemData_SO useableData;
    [Header("Weapon")]
    public GameObject weaponPrefab;
    [FormerlySerializedAs("AttackDataSo")] 
    public AttackData_SO attackDataSo;

    public AnimatorOverrideController weaponAnimator; 
}

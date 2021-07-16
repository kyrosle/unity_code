using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : Singleton<InventoryManager>
{
    public class DragData
    {
        public SlotHolder originalHolder;
        public RectTransform originalParent;
    }
    //TODO: 最后添加模板用于保存数据
    [Header("Inventory Data")] 
    public InventoryData_OS inventoryTemplate;
    public InventoryData_OS inventoryData;
    public InventoryData_OS actionTemplate;
    public InventoryData_OS actionData;
    public InventoryData_OS equipmentTemplate;
    public InventoryData_OS equipmentData;
    [Header("ContainerS")] 
    public ContianerUI inventoryUI;
    public ContianerUI actionUI;
    public ContianerUI equipmentUI;
    [Header("Drag Canvas")]
    public Canvas dragCanvas;
    public DragData currentDrag;
    [Header("UI Panel")] 
    public GameObject InventioryUI;
    public GameObject StatsUI;
    public bool isOpen=false;
    [Header("Stats Text")]
    public Text healthText;
    public Text attackText;
    [Header("ItemTooltip")] public ItemTooltip itemTooltip;

    protected override void Awake()
    {
        base.Awake();
        
        if (inventoryTemplate != null) 
            inventoryData = Instantiate(inventoryTemplate);
        if (actionTemplate != null)
            actionData = Instantiate(actionTemplate);
        if (equipmentTemplate != null)
            equipmentData = Instantiate(equipmentTemplate);
    }

    private void Start()
    {
        LoadData();
        inventoryUI.RefreshUI();
        actionUI.RefreshUI();
        equipmentUI.RefreshUI();
    }

    private void Update()
    {
        UpdateStatsText((int)GameManager.Instance.playerState.CurrentHealth ,
            (int)GameManager.Instance.playerState.attackData.minDamage,
            (int)GameManager.Instance.playerState.attackData.minDamage);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!InventioryUI.activeSelf && !StatsUI.activeSelf)
            {
                isOpen = false;
            }
            isOpen = !isOpen;
            InventioryUI.SetActive(isOpen);
            StatsUI.SetActive(isOpen);
        }
    }

    public void SavaData()
    {
        SaveManager.Instance.Save(inventoryData,inventoryData.name); 
        SaveManager.Instance.Save(actionData,actionData.name); 
        SaveManager.Instance.Save(equipmentData,equipmentData.name); 
    }

    public void LoadData()
    {
        SaveManager.Instance.Load(inventoryData,inventoryData.name); 
        SaveManager.Instance.Load(actionData,actionData.name); 
        SaveManager.Instance.Load(equipmentData,equipmentData.name); 
    }

    public void UpdateStatsText(int health,int minAttack,int maxAttack)
    {
        healthText.text = health.ToString();
        attackText.text = minAttack.ToString() + " - " + maxAttack.ToString();
    }

    #region 检查拖拽物品是否在每一个slot 范围内

    public bool CheckInInventoryUI(Vector3 position)
    {
        for (int i = 0; i < inventoryUI.slotHolders.Length; i++)
        {
            RectTransform t = inventoryUI.slotHolders[i].transform as RectTransform;

            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckInActionUI(Vector3 position)
    {
        for (int i = 0; i < actionUI.slotHolders.Length; i++)
        {
            RectTransform t = actionUI.slotHolders[i].transform as RectTransform;

            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckInEquipmentUI(Vector3 position)
    {
        for (int i = 0; i < equipmentUI.slotHolders.Length; i++)
        {
            RectTransform t = equipmentUI.slotHolders[i].transform as RectTransform;

            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
            {
                return true;
            }
        }
        return false;
    }
    #endregion
}

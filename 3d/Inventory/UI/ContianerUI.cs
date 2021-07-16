using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContianerUI : MonoBehaviour
{
    public SlotHolder[] slotHolders;

    public void RefreshUI()
    {
        for (int i = 0; i < slotHolders.Length; i++)
        {
            slotHolders[i].itemUI.Index = i;
            slotHolders[i].UpdateItem();
        }
    }
}
/*
 * 问题:
 * 每次更新ui都是全部更新
 * 有时候null还更新
 */
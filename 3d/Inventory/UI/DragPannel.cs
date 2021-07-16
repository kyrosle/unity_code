using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragPannel : MonoBehaviour,IDragHandler,IPointerDownHandler
{
    private RectTransform rectTransfrom;
    private Canvas canvas;

    private void Awake()
    {
        rectTransfrom=GetComponent<RectTransform>();
        canvas = InventoryManager.Instance.GetComponent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransfrom.anchoredPosition += (eventData.delta/canvas.scaleFactor);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransfrom.SetSiblingIndex(2); 
    }
}

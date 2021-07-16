using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text itemName;
    public Text itemInfo;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetTooltip(ItemDate_SO itemDate)
    {
        itemName.text = itemDate.itemName;
        itemInfo.text = itemDate.Description;
    }

    private void OnEnable()
    {
        UpdatePosition();
    }

    private void Update()
    {
        UpdatePosition(); 
    }

    void UpdatePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        
        Vector3[] corner = new Vector3[4];
        rectTransform.GetWorldCorners(corner);

        float width = corner[3].x - corner[0].x;
        float height = corner[1].y - corner[0].y;

        if (mousePos.y < height)
            rectTransform.position = mousePos + Vector3.up * height*0.6f;
        else if (Screen.width - mousePos.x > width)
            rectTransform.position = mousePos + Vector3.right * width * 0.6f;
        else
            rectTransform.position = mousePos + Vector3.left * width * 0.6f;
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarUI : MonoBehaviour
{
    // 预制体
    public GameObject healthBarPrefab;
    // show 血条的位置
    public Transform barPoint;
    // 设置血条是否为永久显示 
    public bool alwaysVisible;
    // 血条显示后多久隐藏
    public float visabletime;
    // 血条显示计时器
    private float timeLeft;
    
    // 血条滑动效果
    private Image healthSlider;
    // 生成血条的载体 
    private Transform UIbar;
    // 血条相对摄像机
    private Transform cam;
    // 用于调用 更新血条事件 
    private CharacterStats currenStats;
    
    

    private void Awake()
    {
        barPoint = transform.GetChild(0).transform;
        
        currenStats = GetComponent<CharacterStats>();

        currenStats.UpdateHealthBarOnAttack += UpdateHealthBar;
    }

    private void OnEnable()
    {
        cam = Camera.main.transform;

        // 以后可能会有很多个canvas
        // 寻找到列表里面的uibar再生成uibar???
        // 吧uibar生成后作为object的子物体
        
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            // 弊端:场景里面还有其他的是 WorldSpace
            if (canvas.renderMode == RenderMode.WorldSpace)
            {
                UIbar=Instantiate(healthBarPrefab, canvas.transform).transform;
                healthSlider = UIbar.GetChild(0).GetComponent<Image>();
                healthSlider.fillAmount = 1;
                UIbar.gameObject.SetActive(alwaysVisible);
            }
        }
    }

    // 添加到事件
    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if(currentHealth<=0)
            Destroy(UIbar.gameObject);
        
        UIbar.gameObject.SetActive(true);
        timeLeft = visabletime;
        float sliderPercent = (float)currentHealth / maxHealth;
        healthSlider.fillAmount = sliderPercent;
    }

    
    // 系统自动调用
    private void LateUpdate()
    {
        if (UIbar != null)
        {
            UIbar.position = barPoint.position;
            UIbar.forward = -cam.position;
            
            if(timeLeft<=0&&!alwaysVisible)
                UIbar.gameObject.SetActive(false);
            else
            {
                timeLeft -= Time.deltaTime;
            }
        } 
    }
}
/**
 *  一个 characterstates 对应一个 updatehealth的方法
 *  
 */

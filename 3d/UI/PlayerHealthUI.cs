using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour
{
    private Text levelText;
    private Image healthSlider;
    private Image expSlider;

    private void Awake()
    {
        levelText = transform.GetChild(2).GetComponent<Text>();
        healthSlider = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        expSlider = transform.GetChild(1).GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        levelText.text = "level " + GameManager.Instance.playerState.characterData.currentLevel.ToString("00");
        UpdateExp();
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        float sliderPercent = (float) GameManager.Instance.playerState.CurrentHealth /
                              GameManager.Instance.playerState.MaxHealth;
        healthSlider.fillAmount = sliderPercent;
    }

    public void UpdateExp()
    {
        float sliderPercent = (float) GameManager.Instance.playerState.characterData.currentExp /
                              GameManager.Instance.playerState.characterData.baseExp;
        expSlider.fillAmount = sliderPercent;
    }

}

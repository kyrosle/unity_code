using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public event Action<int, int> UpdateHealthBarOnAttack; 
    // 模板数据
    public CharacterData_SO templateData;
    // data不是momobehaviour 无法挂载在player身上
    public CharacterData_SO characterData;
    // 通过 maxHealth 读到 characterData的数据
    public AttackData_SO attackData;
    public AttackData_SO baseAttackData;
    private RuntimeAnimatorController baseAnimator;

    [Header("weapon")] public Transform weaponSlot;
        [HideInInspector]
    public bool isCritical; // 判断是否暴击
    
    void Awake() {
        // 模板数据 -- 使相同对象敌人的数据不共串
        if(templateData!=null)
            characterData=Instantiate(templateData);
        baseAttackData = Instantiate(attackData);
        baseAnimator = GetComponent<Animator>().runtimeAnimatorController;
    }
    /*
        characterData 参数
        MaxHealth
        CurrentHealth
        BaseDefence
        CurrentDefence
    */
    #region Read from Data_SO
    public float MaxHealth{
        get// 读取
        {
            if(characterData!=null)
                return characterData.maxHealth;
            else return 0;
        }
        set
        {
            // 对当前下的 maxHealth 赋值 就可以对 characterData.maxhealth 赋值
            characterData.maxHealth=value;
        }
    }
    public float CurrentHealth{
        get{if(characterData!=null)return characterData.currentHealth;else return 0;}
        set{characterData.currentHealth=value;}
    }
    public float BaseDefence{
        get{if(characterData!=null)return characterData.baseDefence;else return 0;}
        set{characterData.baseDefence=value;}
    }
    public float CurrentDefence{
        get{if(characterData!=null)return characterData.currentDefence;else return 0;}
        set{characterData.baseDefence=value;}
    }
#endregion  
    #region  Character Combat
    // 两个人攻击的时候
    // 伤害=攻击者的攻击力-防御者的防御力
    // 获得谁攻击谁-两个人的属性状态
    public void TakeDamage(CharacterStats attacker,CharacterStats defener){
        // 计算伤害值
        int damage=Mathf.Max(attacker.CurrentDamage()-(int)defener.CurrentDefence,0);
        // 防止负值
        CurrentHealth=Mathf.Max(CurrentHealth-damage,0);

        // 动画配合
        defener.GetComponent<Animator>().SetTrigger("hit");
        //FIXME: attacker
        // 是攻击者暴击 而不是 受害者 暴击
        if(attacker.isCritical){
            defener.GetComponent<Animator>().SetTrigger("hit");
        }
        //TODO: Update UI
        //DO: 修改血条bug 一有受伤就闪退 场景用一个用来放bar的
        UpdateHealthBarOnAttack?.Invoke((int)CurrentHealth,(int)MaxHealth);
        //TODO: 经验update
        if (CurrentHealth <= 0)
        {
            attacker.characterData.UpdateExp(characterData.killpoint);
        }
    }

    // 重载
    public void TakeDamage(int damager, CharacterStats defener)
    {
        int currentDamage = Mathf.Max((int)damager - (int)defener.CurrentDefence, 0);
        CurrentHealth = Mathf.Max(CurrentHealth - currentDamage, 0);
        UpdateHealthBarOnAttack?.Invoke((int)CurrentHealth,(int)MaxHealth);

        if (CurrentHealth <= 0) 
            GameManager.Instance.playerState.characterData.UpdateExp(characterData.killpoint);
    }
    
    
    // 攻击和的随机攻击力
    // 以及 暴击
    private int CurrentDamage()
    {
        // 考虑: 我攻击最小值 > 敌防御力 == 加血
        float coreDamage=UnityEngine.Random.Range(attackData.minDamage,attackData.maxDamage);

        if(isCritical){
            coreDamage*=attackData.criticalMultiplier;
            Debug.Log("暴击"+coreDamage);
        }

        // (强转)
        return (int)coreDamage;
    }

    #endregion
    #region weapon

    public void ChangeWeapon(ItemDate_SO data)
    {
        UnEquipWeapon();
        EquipWeapon(data);
    }
    public void EquipWeapon(ItemDate_SO data)
    {
        // Debug.Log("use Equip!!!");
        if (data == null)
        {
            // Debug.Log("null date");
            return;
        }

        if (data.weaponPrefab != null)
        {
            Instantiate(data.weaponPrefab, weaponSlot);
        }
        //TODO: 更新属性
        //TODO:切换动画
        attackData.ApplyAttackData(data.attackDataSo);
        GetComponent<Animator>().runtimeAnimatorController = data.weaponAnimator;
    }

    public void UnEquipWeapon()
    {
        if (weaponSlot.transform.childCount != 0)
        {
            for (int i = 0; i < weaponSlot.transform.childCount; i++)
            {
                Destroy(weaponSlot.transform.GetChild(i).gameObject);
            }
        }
        attackData.ApplyAttackData(baseAttackData);
        //TODO:切换动画
        GetComponent<Animator>().runtimeAnimatorController = baseAnimator;
    }

    #endregion

    #region Apply item Change

    public void ApplyHealth(int amount)
    {
        if (CurrentHealth + amount <= MaxHealth)
        {
            CurrentHealth += amount;
        }
        else
        {
            CurrentHealth = MaxHealth;
        }
    }
    #endregion
}
/*
属性:

int health{get;set;}

get 它将 返回属性值 或 索引器元素。 return ?;

set 它会向 属性或索引器元素 分配 值。 

用途: 设置类成员字段 可读(get) 或 可写(set)

关键字 value: 外面赋予值
*/

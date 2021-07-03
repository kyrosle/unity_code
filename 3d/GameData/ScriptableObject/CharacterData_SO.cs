using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Data",menuName="Character Stats/Data")]
public class CharacterData_SO : ScriptableObject
{
   [Header("Stats Info")]
   public float maxHealth;
   public float currentHealth;
   public float baseDefence;
   public float currentDefence;
   [Header("Kill")] 
   public int killpoint;
   
   [Header("Level")] 
   public int currentLevel;
   public int maxLevel;
   public int baseExp;
   public int currentExp;
   public float levelBuff;

   public float LevelMulitplier
   {
      get { return 1 + (currentLevel - 1) * levelBuff; }
   }


   public void UpdateExp(int point)
   {
      currentExp += point;

      if (currentExp >= baseExp)
      {
         LevelUp();
      }
   }

   private void LevelUp()
   {
      //所有提升数据的方法

      currentLevel =Mathf.Max(currentLevel+1,0,maxLevel);

      baseExp += (int) (baseExp * LevelMulitplier);

      maxHealth = (int) (maxHealth * LevelMulitplier);

      currentHealth = maxHealth;
      
      Debug.Log("Level up : "+ currentLevel+" Max Health"+ maxHealth);
   }
}

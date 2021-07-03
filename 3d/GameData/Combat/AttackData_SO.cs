using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 实例化脚本
[CreateAssetMenu(fileName="New Attack",menuName="Attack/Attack Data")]
/*
   使用scriptObject 储存的item 每次运行的数据改变会保留,需手动复位, 打包后数据域 打开游戏--关闭游戏
*/
public class AttackData_SO : ScriptableObject
{
   public float attackRanger;
   public float skillRanger;
   public float coolDown;
   public float minDamage;
   public float maxDamage;
   public float criticalMultiplier;// 暴击后的加成百分比
   public float cirticalChance;// 暴击率

}

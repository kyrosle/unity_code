using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//巡逻状态
public class PatrolState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.animyState = 0;// 初始 控制 状态动画
        enemy.SwitchPoint();// 初始 选择 目标
    }
    public override void OnUpdate(Enemy enemy)
    {
        // 播放idle动画 先于 判断到达
        if (enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("run"))//当前 动画是否为 idle
        {    
            enemy.animyState = 1;// 动画控制 1
            enemy.MoveToTarget();// 移动方法
        }

        // 敌人到达目标
        if (Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x) < 0.01f)
        {
            enemy.TransitionToState(enemy.patrolState);// 重新进入巡逻状态 == 初始 选择 目标
        }
        
        // 当有可攻击目标
        if (enemy.attackList.Count > 0)
            enemy.TransitionToState(enemy.attackState);
    }
}

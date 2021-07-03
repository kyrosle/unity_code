using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//攻击
public class AttackState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.animyState=2;
        //切换目标
        enemy.targetPoint=enemy.attackList[0];
    }
    
    public override void OnUpdate(Enemy enemy)
    {
        if(enemy.hasBomb)
            return;
        // 没敌人的时候
        if(enemy.attackList.Count==0)
            enemy.TransitionToState(enemy.patrolState);
        
        if(enemy.attackList.Count>1)// 一个以上物体
        {
            // 选最近的 物体 作为 目标
            for(int i=0;i<enemy.attackList.Count;i++)
            {
                if(Mathf.Abs(enemy.transform.position.x-enemy.attackList[i].position.x)
                    <Mathf.Abs(enemy.transform.position.x-enemy.targetPoint.position.x))
                {
                    enemy.targetPoint=enemy.attackList[i];
                }
            }
        }else if(enemy.attackList.Count==1)// 一个物体
            enemy.targetPoint=enemy.attackList[0];

        //判断 攻击 方式
        //用 标签 来识别物体
        if(enemy.targetPoint.CompareTag("player")){
            enemy.AttackAction();
        }
        if(enemy.targetPoint.CompareTag("Bomb")){
            enemy.SkillAction();
        }
        enemy.MoveToTarget();
    }
}
/*

如果你希望 Player 可以被击飞 可以添加以下的代码：

//创建bool变量
    bool isHurt;
    
    void Update()
    {
        anim.SetBool("dead", isDead);
        if (isDead)
            return;
            
        //用来判断是否正在播放受伤动画
        isHurt = anim.GetCurrentAnimatorStateInfo(1).IsName("player_hit");
        CheckInput();
    }

    public void FixedUpdate()
    {
        if (isDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        PhysicsCheck();
        
        //非受伤状态才可以移动和跳跃
        if (!isHurt)
        {
            Movement();//input会覆盖Rigidbody的速度，所以用isHurt来锁定就可以让 Player 被击飞了
            Jump();
        }
    }
*/
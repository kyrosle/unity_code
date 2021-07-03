using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 使用 NavMeshAgent
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    // player 使用 agent 来控制移动
    private NavMeshAgent agent;
    private Animator anim;
    private GameObject attackTarget;
    private float LastAttackTime;
    private CharacterStats characterStats;
    private bool isdeath;
    private float stopDistance;

    [Header("show settings")] 
    public bool CanMove;
    private void Awake()
    {
        agent=GetComponent<NavMeshAgent>();
        anim=GetComponent<Animator>(); 
        characterStats=GetComponent<CharacterStats>();

        stopDistance=agent.stoppingDistance;
    }

    // 场景加载
    private void OnEnable()
    {
        // 只要事件一启用就会调用 MoveToTarget,EventAttack
        MouseManager.Instance.onMouseClicked+=MoveToTarget;
        MouseManager.Instance.OnEnemyClicked+=EventAttack;    
        GameManager.Instance.RigisterPlayer(characterStats); // 死了就 广播   
    }

    private void Start()
    {
        SaveManager.Instance.LoadPlayerData();
    }

    // 场景销毁
    private void OnDisable()
    {
        MouseManager.Instance.onMouseClicked -= MoveToTarget;
        MouseManager.Instance.OnEnemyClicked -= EventAttack;
    }

    void Update()
    {
        CanMove = agent.isStopped;
        // 简单写法
        isdeath=characterStats.CurrentHealth==0;

        if(isdeath){
            GameManager.Instance.NotifyObservers();
        }
        
        SwitchAnimation();

        // 用 gamemanager 管理 
        // // ~~: 自加的死亡效果
        // if(isdeath){
        //     GetComponent<NavMeshAgent>().enabled=false;
        //     GetComponent<Collider>().enabled=false;
        //     return;
        // }
        // //

        LastAttackTime-=Time.deltaTime;
    }
   private void SwitchAnimation(){
        // 把vector3的值(agent.velcoity)转化为浮点值
        // 用于控制人物动画 move-idle
        anim.SetFloat("Speed",agent.velocity.sqrMagnitude);
        anim.SetBool("death",isdeath);
    }

    public void MoveToTarget(Vector3 target){
        StopAllCoroutines();
        if(isdeath)return;
        // 还原停止的状态
        agent.stoppingDistance=stopDistance;
        agent.isStopped=false;
        agent.destination=target;
    }
    private void EventAttack(GameObject target)
    {
        if(isdeath)return;
        // 以防敌人死亡报错
        if(target!=null){
            attackTarget=target;

            // 计算 player暴击
            characterStats.isCritical=UnityEngine.Random.value<characterStats.attackData.cirticalChance;

            StartCoroutine(MoveToAttackTarget());
        }
    }

    //FIXME: player 停止位置
    // 敌人模型大, 目标点在其中心,一直晃不攻击
    // 记录agent.stopDistance 平时为普通值, 攻击时为攻击距离
    IEnumerator MoveToAttackTarget(){
        //确保玩家可动
        agent.isStopped=false;
        agent.stoppingDistance=characterStats.attackData.attackRanger;

        transform.LookAt(attackTarget.transform);

        //修改攻击的范围参数
        while(Vector3.Distance(attackTarget.transform.position,transform.position)>characterStats.attackData.attackRanger){
            agent.destination=attackTarget.transform.position;
            yield return null;
        }
        agent.isStopped=true;

        //attack
        if(LastAttackTime<0){
            anim.SetBool("critical",characterStats.isCritical);
            anim.SetTrigger("Attack");
            // 重置冷却时间
            LastAttackTime=characterStats.attackData.coolDown;
        }

    }

    // 不用物理碰撞检测 -- 使用动画关键帧 执行攻击效果
    void Hit(){
        if (attackTarget.CompareTag("Attackable"))
        {
            if (attackTarget.GetComponent<rock>() &&
                attackTarget.GetComponent<rock>()._rockStates == rock.RockStates.HitNothing)
            {
                attackTarget.GetComponent<rock>()._rockStates = rock.RockStates.HitEnemy;
                
                attackTarget.GetComponent<Rigidbody>().velocity=Vector3.one;
                attackTarget.GetComponent<Rigidbody>().AddForce(transform.forward*20,ForceMode.Impulse);
            }
        }
        else
        {
            var targetStats=attackTarget.GetComponent<CharacterStats>();

            targetStats.TakeDamage(characterStats,targetStats);
        }
    }
}

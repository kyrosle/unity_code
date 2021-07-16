using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class rock : MonoBehaviour
{
    // 石头的状态
    public enum RockStates { HitPlayer,HitEnemy,HitNothing }
    private Rigidbody rb;
    public RockStates _rockStates;

    [Header("Basic Settings")] 
    public float force;

    public float damage;
    private Vector3 direction;
    // 石头碰到的目标
    public GameObject target;
    // 石头的预制体
    public GameObject rockBreakPrefab;
    /// <summary>
    /// 石头的出现时机: 在敌人的动画事件里面
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 初始速度
        rb.velocity=Vector3.one;
        // 默认是攻击敌人的
        _rockStates = RockStates.HitEnemy;
        FlyToTarget();
    }

    /// <summary>
    /// 如果速度为0则 改状态
    /// </summary>
    private void FixedUpdate()
    {
        if (rb.velocity.sqrMagnitude < 1f)
        {
            _rockStates = RockStates.HitNothing;
        } 
    }

    /// <summary>
    /// 目标:玩家
    /// 
    /// </summary>
    void FlyToTarget()
    {
        if (target == null)
            target = FindObjectOfType<PlayerController>().gameObject;
        //方向
        direction = (target.transform.position - transform.position + Vector3.up).normalized;
        //力效果
        rb.AddForce(direction*force,ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        // 检测状态机
        switch (_rockStates)
        {
            case RockStates.HitPlayer:
                // 对玩家产生击退效果
                if (other.gameObject.CompareTag("Player"))
                {
                    other.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                    other.gameObject.GetComponent<NavMeshAgent>().velocity = direction * force;

                    other.gameObject.GetComponent<Animator>().SetTrigger("dizzy");
                    other.gameObject.GetComponent<CharacterStats>().TakeDamage((int)damage,other.gameObject.GetComponent<CharacterStats>());

                    _rockStates = RockStates.HitNothing;
                } 
                break;
           case RockStates.HitEnemy:
               // 对 投石头的敌人做效果
               if (other.gameObject.GetComponent<SwWarrior>())
               {
                   var otherSats = other.gameObject.GetComponent<CharacterStats>();
                   otherSats.TakeDamage((int)damage,otherSats);
                   // 碎石效果 -- 粒子系统
                   Instantiate(rockBreakPrefab, transform.position, quaternion.identity);
                   Destroy(gameObject);
               }

               break;
        } 
    }
}

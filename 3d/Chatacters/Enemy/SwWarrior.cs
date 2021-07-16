using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwWarrior : EnemyController
{
    [Header("Skill")]
    public float kickForce=25;
    public Transform handPos;

    public GameObject rockPrefab;
    public void KickOff(){
        // 敌人有可能攻击玩家的时候 玩家跑开了
        if(attacktarget!=null&&transform.IsFacingTarget(attacktarget.transform)){
            var target=attacktarget.GetComponent<CharacterStats>();

            Vector3 direction=(attacktarget.transform.position-transform.position).normalized;
            //direction.Normalize();

            // 击飞
            target.GetComponent<NavMeshAgent>().isStopped=true;
            target.GetComponent<NavMeshAgent>().velocity=direction*kickForce;
            // 自定义效果
            target.GetComponent<Animator>().SetTrigger("dizzy");
            // 产生伤害
            target.TakeDamage(characterStats,target);
        }
    }
    // Animation event
    public void ThrowRock()
    {
        if (attacktarget != null)
        {
            var rock = Instantiate(rockPrefab, handPos.position, Quaternion.identity);
            rock.GetComponent<rock>().target = attacktarget;
        }
    }
}

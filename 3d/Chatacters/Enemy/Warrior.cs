using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Warrior : EnemyController 
{
    [Header("Skill")]
    public float kickForce=10;
    // Animation event
    public void KickOff(){
        if(attacktarget!=null){
            transform.LookAt(attacktarget.transform);

            Vector3 direction=attacktarget.transform.position-transform.position;
            direction.Normalize();

            attacktarget.GetComponent<NavMeshAgent>().isStopped=true;
            attacktarget.GetComponent<NavMeshAgent>().velocity=direction*kickForce;
            attacktarget.GetComponent<Animator>().SetTrigger("dizzy"); 

        }
    }
    
  
}

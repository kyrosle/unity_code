using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cumb : Enemy,IDamageable
{
    //Animation Event
    public void SetOff(){
        targetPoint.GetComponent<Bomb>().TurnOff();
    }
    public void GetHit(float damage){
        health-=damage;
        if (health<1)
        {
            health=0;
            isDead=true;
        }
        anim.SetTrigger("hit");
    }
}

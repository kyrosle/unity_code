using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale :Enemy,IDamageable 
{
    public float scale;

    public void GetHit(float damage){
        health-=damage;
        if (health<1)
        {
            health=0;
            isDead=true;   
        }
        anim.SetTrigger("hit");
    }
    //Animation Event
    public void Swalow(){
        targetPoint.GetComponent<Bomb>().TurnOff();
        targetPoint.gameObject.SetActive(false);
        transform.localScale*=scale;
    }
}

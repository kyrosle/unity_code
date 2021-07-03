using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy :Enemy,IDamageable 
{
    public Transform pickupPoint;
    public float power=10;
    public void GetHit(float damage){
        health-=damage;
        if (health<1)
        {
            health=0;
            isDead=true;   
        }
        anim.SetTrigger("hit");
    }
    //Animation event
    public void PickUpBomb(){
        if (targetPoint.CompareTag("Bomb")&&!hasBomb)
        {
            // 炸弹 移动到 pickpoint
            targetPoint.gameObject.transform.position=pickupPoint.position;   
            // 吧炸弹 转到 pickpoint的子集 -- 炸弹跟随敌人走
            targetPoint.SetParent(pickupPoint);
            // 设置炸弹重力 1.改gravity 2.改为kinematic(√)
            targetPoint.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Kinematic;

            hasBomb=true;// 否则 大块头 一直翻转
        }
    }

    public void ThrowAway(){
        if (hasBomb)
        {
            // 重新有 重力效果
            targetPoint.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
            // 设置 为 不跟随
            targetPoint.SetParent(transform.parent.parent);
            
            //按 玩家方向 扔 炸弹
            //找到属于某个类型的物体,找到玩家的坐标作比较
            if(FindObjectOfType<PlayerController>().gameObject.transform.position.x-transform.position.x<0){
                targetPoint.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,1)*power,ForceMode2D.Impulse);
            }
            else
                targetPoint.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,1)*power,ForceMode2D.Impulse);
        }
        hasBomb=false;
    }
}
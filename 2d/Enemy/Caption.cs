using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caption : Enemy,IDamageable
{
    SpriteRenderer sprite;
    public override void Init()
    {
        base.Init();
        sprite=GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        base.Update();
        if(animyState==0){
            sprite.flipX=false;
        }
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

    public override void SkillAction()
    {
        base.SkillAction();
        // 翻转前提--一直在attackstate
        // 炸弹没了的话..切入到 巡逻模式
        sprite.flipX=true;
        // 反向移动的 时间 取决于 skill动画 的长度
        if (anim.GetCurrentAnimatorStateInfo(1).IsName("skill"))
        {
            // 跑的跟快 速度改为4倍 很突兀 \\ skill动画针复制 (√)
            // 跑的更远
            if (transform.position.x>targetPoint.position.x)
            {
                transform.position=Vector2.MoveTowards(transform.position,transform.position+Vector3.right,speed*2*Time.deltaTime);
            }
            else
                transform.position=Vector2.MoveTowards(transform.position,transform.position+Vector3.left,speed*2*Time.deltaTime);
        }else
            sprite.flipX=false;
    }
}
// Flip X : 只翻转图片
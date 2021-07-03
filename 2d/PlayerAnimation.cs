using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 玩家动画控制器
public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {   //会有小于0的情况
        //用速度判断idle和run动画切换
        anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));

        anim.SetFloat("velcoityY", rb.velocity.y);

        anim.SetBool("jump",controller.isJump);

        anim.SetBool("ground", controller.isGround);
    }
}
/* 
speed 速度
velcoityY 是否有y速度
jump 是否为跳跃
ground 是否触地
 */
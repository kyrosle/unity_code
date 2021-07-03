using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 炸弹
public class Bomb : MonoBehaviour
{
    private Animator anim;
    private Collider2D coll;
    private Rigidbody2D rb2d;

    public float startTime;// 开始爆炸时间
    public float waitTime;// 等待时间
    public float bombFroce;// 炸弹效果

    [Header("Check")]
    public float radius;// 炸弹 影响范围
    public LayerMask targetLayer;// 炸弹 影响碰撞层

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //检测 范围内可攻击 物体
        coll = GetComponent<Collider2D>();

        rb2d = GetComponent<Rigidbody2D>();
        //初始开始时间
        startTime = Time.time; 
    }

    // Update is called once per frame
    void Update()
    {
        //到点爆炸
        //跑动画
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("bomb_off"))
            if (Time.time>startTime+waitTime)
            {
                anim.Play("bomb_exp");
            }
    }

    //显示 检测范围
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position,radius);
    }

    //爆炸动画
    public void Explotion()
    {
        coll.enabled = false;

        //可攻击物体 数组
        Collider2D[] arroundObject = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        //无重力
        rb2d.gravityScale = 0;

        //对 受体 施加 反冲力
        foreach (var item in arroundObject)
        {
            //判断方向
            Vector3 pos = transform.position - item.transform.position;

            item.GetComponent<Rigidbody2D>().AddForce((-pos+Vector3.up)*bombFroce,ForceMode2D.Impulse);
            // 设置 炸弹引燃炸弹 效果
            if (item.CompareTag("Bomb")&&item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("bomb_off"))
            {
               item.GetComponent<Bomb>().TurnOn();//调用 对方的 点燃方法
            }
            if (item.CompareTag("player"))
            {
                item.GetComponent<IDamageable>().GetHit(3);   
            }
            if(item.CompareTag("Enemy")){
                item.GetComponent<IDamageable>().GetHit(3);
            }
        }
    }
    public void TurnOff(){
        anim.Play("bomb_off");
        gameObject.layer=LayerMask.NameToLayer("NPC");
    }

    public void TurnOn(){
        startTime=Time.time;//启动后不会立即爆炸
        anim.Play("bomb_on");
        gameObject.layer=LayerMask.NameToLayer("NPC");
    }
    //销毁
    public void DestroyThis() {
        Destroy(gameObject);
    }
}

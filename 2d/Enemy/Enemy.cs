using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyBaseState currentState;// 当前状态

    [HideInInspector]public Animator anim;
    public int animyState;// 控制动画

    private GameObject alarmsign;

    [Header("Base State")]
    public float health;
    public bool isDead;
    public bool hasBomb;
    public bool isBoss;

    [Header("Movement")]
    public float speed;
    public Transform pointA, pointB;// 巡逻点
    public Transform targetPoint;// 目标

    [Header("AttackSetting")]
    public float attackRate;//攻击频率
    public float attackRange,skillRange;// 攻击距离 
    private float nextAttack=0;// 运行一瞬间立刻执行攻击

    public List<Transform> attackList = new List<Transform>();// 可攻击列表

    public PatrolState patrolState = new PatrolState();// 巡逻
    public AttackState attackState = new AttackState();// 攻击

    public virtual void Init() {// 初始化扩展
        anim = GetComponent<Animator>();
        alarmsign=transform.GetChild(0).gameObject;

    }
    private void Awake()
    {
        Init();   
    }
    void Start()
    {

        GameManager.instance.IsEnemy(this);
        TransitionToState(patrolState);// 初始进入巡逻状态
        if (isBoss)
        {
        UIManager.instance.SetBossHealth(health);   
        }
    }

    public virtual void Update()
    {
        anim.SetBool("dead",isDead);
        if (isDead)
        {
            GameManager.instance.EnemyDead(this);
            return;
        }
        if (isBoss)
        {
            UIManager.instance.UpdateBossHealth(health);   
        }
        currentState.OnUpdate(this);// 当前状态Update
        anim.SetInteger("state", animyState);// 每一帧检测当前动画的参数
    }

    //进入状态初始
    public void TransitionToState(EnemyBaseState state) 
    {
        currentState = state;// 控制状态动画
        currentState.EnterState(this);// 执行进入状态方法
    }
    // 敌人移动配套方法
    public void MoveToTarget() 
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        FlipDirecton();
    }
    // 虚函数 继承扩展覆写
    public virtual void AttackAction() 
    {
        //如果 玩家在 敌人 上方
        //实际 二维坐标距离
        if(Vector2.Distance(transform.position,targetPoint.position)<attackRange)
        {   //计时器写法
            if (Time.time>nextAttack)
            {

                //播放攻击动画
                anim.SetTrigger("attack");
                nextAttack=  Time.time+attackRate;  
            }
        }
    }
    public virtual void SkillAction() 
    {
         if(Vector2.Distance(transform.position,targetPoint.position)<skillRange)
        {   //计时器写法
            if (Time.time>nextAttack)
            {
                //播放技能动画
                anim.SetTrigger("skill");
                nextAttack=  Time.time+attackRate;  
            }
        }
    }
    
    // 翻转敌人 精灵片
    public void FlipDirecton() 
    {
        if (transform.position.x<targetPoint.position.x)
        {
            transform.rotation =Quaternion.Euler(0f,0f,0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
    //判断到达目标就 切换新目标点
    public void SwitchPoint() {
        if (Mathf.Abs(pointA.position.x - transform.position.x) - Mathf.Abs(pointB.position.x - transform.position.x)<1f)
        {
            targetPoint = pointA;
        }
        else
        {
            targetPoint = pointB;
        }
    }
    //添加可攻击列表
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 检测列表里面--没有该物体--敌人没有携带炸弹--敌人没死--玩家没死(游戏没结束)
        if (!attackList.Contains(collision.transform)&&!hasBomb&&!isDead&&!GameManager.instance.gameOver)
        {
            attackList.Add(collision.transform);
        }
    }
    //移除离开的可攻击列表
    private void OnTriggerExit2D(Collider2D collision)
    {
        attackList.Remove(collision.transform);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!isDead&&!GameManager.instance.gameOver)
            StartCoroutine(OnAlarm());
    }

    IEnumerator OnAlarm(){
        alarmsign.SetActive(true);
        //等待时间 第一个默认动画的长度
        yield return new WaitForSeconds(alarmsign.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length);
        alarmsign.SetActive(false);
    }
}

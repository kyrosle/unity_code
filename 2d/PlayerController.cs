using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//玩家控制器
public class PlayerController : MonoBehaviour,IDamageable
{
    private Rigidbody2D rb;
    private Animator animator;
    private FixedJoystick joystick;

    public float speed;// 移动速度
    public float jumpForce;// 跳跃的力
    [Header("Player State")]
    public float health;
    public bool isDead;

    [Header("Ground Check")]
    public Transform groundCheck;// 与地面的检测 == 是否处于跳跃状态
    public float checkRadius;// 检测环大小
    public LayerMask gourndLayer;// 检测层

    [Header("States Check")]
    public bool isGround;// 是否 在地面
    public bool isJump;// 是否 处于跳跃 
    public bool canJump;// 能否 执行跳跃

    [Header("Jump FX")]
    public GameObject jumpFx;// 跳跃特效
    public GameObject landFx;// 灼地特效

    [Header("Attack Settings")]
    public GameObject bombPrefab;// 玩家武器 炸弹
    public float nextAttack = 0;// 下一次 攻击时间
    public float attackrate;// 攻击频率
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        joystick=FindObjectOfType<FixedJoystick>();

        //先isplayer 再 loadhealth 否则空引用
        GameManager.instance.IsPlayer(this);
        health=GameManager.instance.LoadHealth();
        UIManager.instance.UpdateHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("dead",isDead);
        if(isDead)
            return;

       // CheckInput();// 检测 玩家 输入
    }
    
    // void CheckInput() {
    //     if (Input.GetButtonDown("Jump")&&isGround)// 按下 空格 且 在地面(在空中无法连续跳)
    //         canJump = true;

    //     if (Input.GetKeyDown(KeyCode.J)) {// 按下 攻击键
    //         Attack();
    //     }
    // }
    public void JumpCheck(){
        if (isGround)
        {
            canJump=true;   
        }
    }

    private void FixedUpdate()// 定时 物理update
    {
        
        if(isDead){
            rb.velocity=Vector2.zero;
            return;
        }
        PhysicsCheck();// 跳跃 功能 检测
        Movement();// 移动
        Jump();// 跳跃
    }
    void Movement() {
        //键盘操作
        //float horizontalInput = Input.GetAxis("Horizontal");//-1~1 GetAxisRaw不包括小数
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //horizontalInput在不移动的时候一直为0,一直 覆盖 其他物理效果
        // blog中有 移动方法 集合
        //操作杆
        float horizontalInput=joystick.Horizontal;
        rb.velocity = new Vector2(horizontalInput*speed,rb.velocity.y);

        //如果 移动 输入值为 -1 or 1 作为 localscalse x参数 
        // if (horizontalInput!=0)
        // {
        //     transform.localScale = new Vector3(horizontalInput,1,1);
        // }

        if(horizontalInput>0)
            transform.eulerAngles=new Vector3(0,0,0);
        else 
            transform.eulerAngles=new Vector3(0,180,0);
    }
    /**
     * 翻转方法
     * 1.Scale 1 / -1
     * 2.Rotation 0 / 180
     * 3.Flip x true/false 子物体的都翻转
     **/

     //跳跃
    void Jump() {
        //在 跳跃状态下
        if (canJump)
        {
            isJump = true;// 正在跳跃
            //跳跃特效
            jumpFx.SetActive(true);  
            jumpFx.transform.position = transform.position + new Vector3(0,-0.45f,0);//设置特效在 玩家跳跃时的坐标

            //玩家跳跃
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 4;// 加快下落速度
            canJump = false;// 设置为无法跳跃-->不能连续跳跃
        }
    }

    // 玩家攻击
    public void Attack() {
        //cd时间
        if (Time.time > nextAttack) {
            Instantiate(bombPrefab, transform.position, transform.rotation);

            nextAttack = Time.time + attackrate;
        }
    }

    //玩家检测地板
    void PhysicsCheck() 
    {
        //圆形检测方法
        isGround = Physics2D.OverlapCircle(groundCheck.position,checkRadius,gourndLayer);
        if (isGround)
        {   //人在地面继续播
            rb.gravityScale = 1;
            isJump = false;
        }
    }

    //显示 检测圆环
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position,checkRadius);
    }

    //下落特效
    public void landFX() {
        landFx.SetActive(true);
        landFx.transform.position = transform.position + new Vector3(0,-0.75f,0);
    }
    //实现伤害接口
    public void GetHit(float damage)
    {
        //判断当前动画是否为受伤动画..相当于无敌针
        if(!animator.GetCurrentAnimatorStateInfo(1).IsName("hit")){
            health-=damage;
            if (health<1)
            {
                health=0;   
                isDead=true;
            }
            animator.SetTrigger("hit");

            UIManager.instance.UpdateHealth(health);
        }
    }
}

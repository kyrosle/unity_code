using UnityEngine;
// agent用
using UnityEngine.AI;

// 敌人会有不同状态的切换
// Gruard 巡逻 追击 死亡

public enum EnemyStates{GUARD,PATROL,CHASE,DEAD}

// 只要脚本加载到物件就会自动加载这歌component
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(HealthBarUI))]
public class EnemyController : MonoBehaviour,IEndGameObserver
{
    private NavMeshAgent agent;
    [SerializeField]
    private EnemyStates enemyStates;
    private Animator anim;
    private Collider coll; // 碰撞器的基类

    protected CharacterStats characterStats;

    [Header("Basic Settings")]
    public float sightRadius;// 检测范围
    public bool isGround;// 站岗or巡逻
    private float speed;// 保存初速度
    [SerializeField]
    protected GameObject attacktarget;// 目标
    public float lookAtTime;
    private float remainLookAtTime;// 到点发呆
    private float lastAttackTime;// 攻击cd

    
    [Header("Patrol State")]
    public float partrolRange;// 巡逻距离
    private Vector3 wayPoint;// 巡逻目标点

    private Vector3 guardPos;// 站桩位置
    private Quaternion guardRoation;// 原面向方向

    [Header("Show Emeu")]
    public Collider[] _colliders; // 映射检测列表

    [Header("Show Health")]
    public float NowHealth;

    //bool 配合动画
    bool iswalk;
    bool ischase;
    bool isfollow;
    bool isdeath;
    bool playerDead;

    void detective(){
        NowHealth=characterStats.CurrentHealth;
    }

    void Awake() {
        agent=GetComponent<NavMeshAgent>();
        anim=GetComponent<Animator>();
        coll=GetComponent<Collider>();

        speed=agent.speed;
        guardPos=transform.position;
        guardRoation=transform.rotation;// 四元数

        remainLookAtTime=lookAtTime;
        characterStats=GetComponent<CharacterStats>();
    }
    void Start() {
        if(isGround){
            enemyStates=EnemyStates.GUARD;
        }else{
            enemyStates=EnemyStates.PATROL;
            // 初始waypoint在 0,0,0
            GetNewWayPoint();
        }
        //FIXME:场景切换后改掉
        GameManager.Instance.AddObserver(this);

    }
    // 当场景加载出来,敌人加载出来,
    // TODO:后期场景加载才用
    // void OnEnable() {
    //     GameManager.Instance.AddObserver(this);
    // }
    void OnDisable() {
        if(!GameManager.IsInitialized)return;
        GameManager.Instance.RemoveObserver(this);
       
        if(GetComponent<LootSpawner>()&& isdeath)
            GetComponent<LootSpawner>().Spawnloot();
    }
    void Update() {
        //测试: 
        detective();
        if(characterStats.CurrentHealth==0)
            isdeath=true;
        if(playerDead)
            return;
        SwitchStates();    
        SwitchAnimation();  
        lastAttackTime-=Time.deltaTime; 
    }
    // 把动画和代码配合起来
    void SwitchAnimation(){
        anim.SetBool("walk",iswalk);
        anim.SetBool("chase",ischase);
        anim.SetBool("follow",isfollow);
        anim.SetBool("Critical",characterStats.isCritical);
        anim.SetBool("death",isdeath);
    }


    // 敌人状态机
    void SwitchStates(){
        if(characterStats.CurrentHealth==0)
            enemyStates=EnemyStates.DEAD;

        // 如果发现player 切换到CHASE 非死亡状态下
        else if(FoundPlayer()){
            enemyStates=EnemyStates.CHASE;
        }

        // 状态行为选择
        switch (enemyStates)
        {
            //--:守卫模式
            // 与玩家拉脱 并且是 isground
            case EnemyStates.GUARD:
                ischase=false;

                if(transform.position!=guardPos){
                    iswalk=true;
                    agent.isStopped=false;
                    agent.destination=guardPos;

                    // 计算两个三维向量差值
                    // SqrMagnitude 性能开销小于 distance 版本已经优化
                    if(Vector3.SqrMagnitude(guardPos-transform.position)<=agent.stoppingDistance){
                        iswalk=false;

                        transform.rotation= Quaternion.Lerp(transform.rotation,guardRoation,0.04f);
                    }
                }
                break;

            //--:巡逻模式
            case EnemyStates.PATROL:
                // 巡逻前保证agent可用
                agent.isStopped = false;
                
                ischase=false;
                agent.speed=speed*0.5f;// 乘法性能比除法好

                // 判断是否到了随机巡逻点
                if(Vector3.Distance(wayPoint,transform.position)<=agent.stoppingDistance){
                    iswalk=false;
                    if(remainLookAtTime>0)
                        remainLookAtTime-=Time.deltaTime;
                    else
                        GetNewWayPoint();
                }else{
                    iswalk=true;
                    agent.destination=wayPoint;
                }
                break;

            //--:追逐模式
            case EnemyStates.CHASE:
                //TOD:追player
                
                
                //TODO:配合动画
                iswalk=false;
                ischase=true;

                agent.speed=speed; // 使用追逐速度
                
                if(!FoundPlayer()||Vector3.Distance(attacktarget.transform.position,transform.position)<=agent.stoppingDistance){// 跟丢player了
                    //TODO:拉脱回到上一个状态
                    isfollow=false;
                        //ischase=false;
                    // 脱离后 原地不动
                    if(remainLookAtTime>0){
                        agent.destination=transform.position;
                        remainLookAtTime-=Time.deltaTime;
                    }else if(isGround){
                        enemyStates=EnemyStates.GUARD;
                    }else{
                        enemyStates=EnemyStates.PATROL;
                    }
                }
                else
                { // player 在检测范围里面
                    isfollow=true;

                    agent.isStopped=false;

                    // 移动到目标
                    agent.destination=attacktarget.transform.position;
                }
                //TODO:在攻击范围内则攻击
                if(TargetInAttackRanger()||TargetInSkillRanger()){
                    isfollow=false;
                    agent.isStopped=true;
                    // 计时器cooldown 攻击cd
                    if(lastAttackTime<0){
                        lastAttackTime=characterStats.attackData.coolDown;

                        // 判断暴击
                        characterStats.isCritical= Random.value < characterStats.attackData.cirticalChance;
                        // 执行攻击
                        Attack();
                    }
                }

                break;

            //--:死亡状态
            case EnemyStates.DEAD:
            // Can Transition To Self 要取关
            // 代码顺序!!!
                coll.enabled=false;
                //agent.enabled=false;// 关闭移动
                agent.radius=0;
                Destroy(gameObject,2f);
                break;
        }
    }


    void Attack(){
        transform.LookAt(attacktarget.transform);
        if(TargetInAttackRanger()){
            // 近身攻击动画
            anim.SetTrigger("attack");
        }
        if(TargetInSkillRanger()){
            // 技能攻击动画
            anim.SetTrigger("skill");
        }
    }
    
    bool FoundPlayer(){
        var colliders=Physics.OverlapSphere(transform.position,sightRadius);

        //查看检测物体
        _colliders=colliders;

        foreach(var target in colliders){
            if(target.CompareTag("Player")){
                attacktarget=target.gameObject;
                return true;
            }
        }
        attacktarget=null;
        return false;
    }

    // 进入技能攻击范围
    bool TargetInSkillRanger(){
        if(attacktarget!=null)
            return Vector3.Distance(attacktarget.transform.position,transform.position)<=characterStats.attackData.skillRanger;
        else return false;
    }

    // 进入普通攻击范围
    bool TargetInAttackRanger(){
        if(attacktarget!=null)
            return Vector3.Distance(attacktarget.transform.position,transform.position)<=characterStats.attackData.attackRanger;
        else return false;
    }
    void GetNewWayPoint(){

        remainLookAtTime=lookAtTime;

        float randomX=Random.Range(-partrolRange,partrolRange);
        float randomZ=Random.Range(-partrolRange,partrolRange);
        //FIXME: 检测范围跟着人物跑
        Vector3 randomPoint=new Vector3(guardPos.x+randomX,
                                        transform.position.y,
                                        guardPos.z+randomZ);
        //FIXME: 可能problem
        //wayPoint=randomPoint;
        NavMeshHit hit;
        wayPoint=NavMesh.SamplePosition(randomPoint,out hit,partrolRange,1)?hit.position:transform.position;

    }    
    // public static bool SamplePosition (Vector3 sourcePosition(检测坐标), out AI.NavMeshHit hit(结果属性)), float maxDistance(设置的检测范围)), int areaMask(navmesh里面的检测层)));
    

    // 显示检测范围
    void OnDrawGizmosSelected() {
      Gizmos.color=Color.blue;
      Gizmos.DrawWireSphere(transform.position,sightRadius);
    }
    void  OnDrawGizmos() {
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(transform.position,partrolRange);
    }

    // Animation Event
    void Hit(){
        // 敌人有可能攻击玩家的时候 玩家跑开了
        if(attacktarget!=null&&transform.IsFacingTarget(attacktarget.transform)){
            var target=attacktarget.GetComponent<CharacterStats>();

            target.TakeDamage(characterStats,target);
        }
    }

    public void EndNotify()
    {
        // 获胜动画
        // 停止所有移动
        // 停止agent
        ischase=false;
        iswalk=false;
        attacktarget=null;
        anim.SetBool("win",true);
        playerDead=true;
    }
}

// Physics.OverlapSphere
// 返回一个collider[]数组,其中包含与球体接触或位于球体内部的 所有 碰撞体




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 单例模式
public class GameManager : MonoBehaviour
{
    // 得到 监视 玩家 情况
    public PlayerController player;
    // 单例
    public static GameManager instance;
    // 监视 door 情况
    private Door doorExit;
    // 地图敌人列表 -- 判next door
    public List<Enemy> enemies=new List<Enemy>();
    // 玩家死亡
    public bool gameOver;

    private void Awake()
    {
        if(instance==null)
            instance=this;
        else
            Destroy(gameObject);
        //  若果没有就报错!!
        // player=FindObjectOfType<PlayerController>();
        // doorExit=FindObjectOfType<Door>();
    }

    // 全局检测事件
    private void Update()
    {
        if(player!=null)
            gameOver=player.isDead;
        else
            Debug.Log("player is null");
        UIManager.instance.GameOverUI(gameOver);
    }

    // 观察者模式: 由对象调用
    // 敌人
    public void IsEnemy(Enemy enemy){
        enemies.Add(enemy);
    }
    public void EnemyDead(Enemy enemy ){
        enemies.Remove(enemy);

        if (enemies.Count==0)
        {   
            SaveData();
            doorExit.Opendoor();
        }
    }
    // 玩家
    public void IsPlayer(PlayerController controller){
        player=controller;
    }
    // 门
    public void IsDoor(Door door){
        doorExit=door;
    }
    //

    //加载
    // 这里使用PlayerPrefs 持久化储存 游戏存档
    // 每次测试完后都要清理 存档
    public float LoadHealth(){
        if(!PlayerPrefs.HasKey("playerHealth")){// 如果有这个键
            PlayerPrefs.SetFloat("playerHealth",3f);// 设置
        }
        // 读取存档生命值
        float currentHealth=PlayerPrefs.GetFloat("playerHealth");
        // 根性当前值
        UIManager.instance.UpdateHealth(player.health);
        return currentHealth;
    }
    // 保存存档修改值
    public void SaveData(){
        PlayerPrefs.SetFloat("playerHealth",player.health);
    }
}
/*
PlayerPrefs:

static function DeleteAll():void
移除所有键和值

static function DeleteKey(key:string):void
移除key和对应它的值

static function GetFloat(key:string,defaultValue:float=OF):float
如果存在,返回key对应的值 否则就返回 defaultValue

static function GetInt(key:string defaultValue:int):int
返回key 对应的值,否则返回defaultValue

static function GetString(key:string,defaultValue:string=**):string
返回key对应的值 否则返回 defaultValue

static function HasKey(key:string):bool
如果有这个key就返回真

static function SetFloat(key:string,value:float):void
设置key的对应值

static function SetInt(key:string,value:int):void

static function SetString(key:string, value:string):void


*/
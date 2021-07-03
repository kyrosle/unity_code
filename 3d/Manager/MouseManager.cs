using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 使用event
//using UnityEngine.Events;

// 使用unity自带event
using System;

// 舍弃拖拽的方式
// 创建一个 事件
// 由于这个不属于 MonoBehaviour 不会显示出来要  序列化
// [System.Serializable]
// public class EventVector3:UnityEvent<Vector3>{}
//



 public class MouseManager : Singleton<MouseManager>
{
    //static public MouseManager instance;// 单例模式
    RaycastHit hitinfo;// 获取射线碰到物体的信息

    //指针图片
    public Texture2D point,doorway,attack,target,arrow;

    // 事件
    public event Action<Vector3> onMouseClicked;
    public event Action<GameObject> OnEnemyClicked;
    //public EventVector3 onMouseClicked;

    protected override void Awake()
    {
        base.Awake();
       DontDestroyOnLoad(this);
    }
    // private void Awake()
    // {
    //     if(instance==null){
    //         instance=this;
    //     }
    //     else Destroy(gameObject);// 把多余的删掉
    // }
    private void Update()
    {
        SetCursorTexture();
     
        MouseControl();
    }

//设置指针的贴图
    private void SetCursorTexture(){
        // 移动设备输入
        // Ray ray=Camera.main.ScreenPoint(touch.position);
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hitinfo)){
            //切换鼠标图片
            // void Cursor.SetCursor(Texture2D texture(图片), Vector2 hotspot(偏移量)), CursorMode cursorMode(模式)));
            switch (hitinfo.collider.gameObject.tag)
            {
                case "Ground":
                    Cursor.SetCursor(target,new Vector2(16,16),CursorMode.Auto);   
                    break;
                case "Enemy":
                    Cursor.SetCursor(attack,new Vector2(16,16),CursorMode.Auto); 
                    break;    
                case"Attackable":
                    Cursor.SetCursor(attack,new Vector2(16,16),CursorMode.Auto);
                    break;
                case"Portal":
                    Cursor.SetCursor(doorway,new Vector2(16,16),CursorMode.Auto);
                    break;
                default:
                    Cursor.SetCursor(arrow,new Vector2(16,16),CursorMode.Auto);
                    break;
            }
        }
    }

//控制鼠标
    void MouseControl(){
        //鼠标单击&&非空值
        if(Input.GetMouseButtonDown(0)&&hitinfo.collider!=null){
            //判断碰撞物体
            if(hitinfo.collider.gameObject.CompareTag("Ground")){
                // invoke 防 空 执行
                onMouseClicked?.Invoke(hitinfo.point);
            }
            if(hitinfo.collider.gameObject.CompareTag("Enemy")){
                OnEnemyClicked?.Invoke(hitinfo.collider.gameObject);
            }
            if(hitinfo.collider.gameObject.CompareTag("Attackable")){
                OnEnemyClicked?.Invoke(hitinfo.collider.gameObject);
            }
            if(hitinfo.collider.gameObject.CompareTag("Portal")){
                // invoke 防 空 执行
                onMouseClicked?.Invoke(hitinfo.point);
            }
        }
    }
}

// 射线碰到树木 --> 要指引人物到 树木后面的位置
// 1. 把所有树木的layer设为 ingoreRaycast
// 2. 取消所有树木的碰撞(因为ray 对碰撞模块检测)

/*
    public delegate void Action<in T>(T obj);
    无返回值
    <>内的是参数类型
*/


/*
***Ray***
***RaycastHit***
using UnityEngine;
// C# example.
public class ExampleClass : MonoBehaviour
{
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
-------------------------------------------------------------------



event
Action
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 创建一个工具类文件夹
// 泛型类型创建

// 泛型单例模式
// 被单例类继承

// where 约束泛型类型
public class Singleton<T> : MonoBehaviour where T:Singleton<T>
{

    private static T instance;

    // 只可读 在外部可访问 
    // 单例只有一个
    // 单例不被更改
    public static T Instance{
        get{return instance;}
    }
    // 初始方法
    protected virtual void  Awake() {
            if(instance!=null)
                Destroy(gameObject);
            else 
                instance=(T)this;   
    }

    // 只可读
    public static bool IsInitialized{
        get{return instance!=null;}
    }
    // 销毁方法
    protected virtual void OnDestroy(){
        if(instance==this){
            instance=null;
        }
    }
}

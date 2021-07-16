using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Assertions.Must;

public class GameManager : Singleton<GameManager>
{
    public CharacterStats playerState;

    private CinemachineFreeLook _followcam;
    // 广播列表
    [SerializeField] List<IEndGameObserver>endGameObservers=new List<IEndGameObserver>();

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    public void RegistersPlayer(CharacterStats player){
        playerState=player;
        
        _followcam = FindObjectOfType<CinemachineFreeLook>();

        if (_followcam != null)
        {
            _followcam.Follow = playerState.transform;
            _followcam.LookAt = playerState.transform.GetChild(3).transform;
        }
    }

    // 添加和移除观察者
    public void AddObserver(IEndGameObserver observer){
        // 不用判断是否包含
        // 敌人一开时就注册一定不会有重复
        endGameObservers.Add(observer);
    }
    public void RemoveObserver(IEndGameObserver observer){
        endGameObservers.Remove(observer);
    }

    // 调用广播方法
    public void NotifyObservers(){
        // 让每一个观察者调用自己的 方法(自定义化)
        foreach(var observer in endGameObservers){
            observer.EndNotify();
        }
    }
    // 时机: player isdeath 下调用 
    // or 
    // Update里面实时检测

    public Transform GetEntrance()
    {
        foreach (var item in FindObjectsOfType<TransitionDestinion>())
        {
            if (item.destinationTag == TransitionDestinion.DestinationTag.ENTER)
            {
                return item.transform;
            }
        }

        return null;
    }

}

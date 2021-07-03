using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class ScenceController : Singleton<ScenceController>,IEndGameObserver
{
    public GameObject playerPrefab;
    private GameObject player;
    private NavMeshAgent playeragent;
    public ScenceFade scenceFaderPrefab;
    private bool fadeFinished;
    protected override void Awake()
    {
        base.Awake();
        // 保证这个scenecontroller一直存在
        DontDestroyOnLoad(this);
        fadeFinished = true;
    }

    private void Start()
    {
        GameManager.Instance.AddObserver(this);
    }

    public void TrnasitionToDestination(TransitionPoint transitionPoint)
    {
        switch (transitionPoint.transitionType)
        {
            case TransitionPoint.TransitionType.SameScene:
                StartCoroutine(Transition(SceneManager.GetActiveScene().name, transitionPoint.destinationTag));
                break;
            case TransitionPoint.TransitionType.DifferentScene:
                StartCoroutine(Transition(transitionPoint.sceneName, transitionPoint.destinationTag));
                break;
        }
    }

    IEnumerator Transition(string sceneName, TransitionDestinion.DestinationTag destinationTag)
    {
        // FIXME:可以加入fader
        // TODO: 保存数据
        SaveManager.Instance.SavePlayerData();
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            ScenceFade fade = Instantiate(scenceFaderPrefab);
            yield return fade.FadeOut(2f);
            
            // 场景加载
            yield return SceneManager.LoadSceneAsync(sceneName);
            yield return Instantiate(playerPrefab, getDestination(destinationTag).transform.position,getDestination(destinationTag).transform.rotation);
            // 不同场景读取数据
            SaveManager.Instance.LoadPlayerData();
            yield return fade.FadeIn(2f);
            yield break;// 中断协程
        }
        else
        {
            player = GameManager.Instance.playerState.gameObject;
            // 传送之后跑回来--> 击飞后返回原来位置
            playeragent = player.GetComponent<NavMeshAgent>();
            playeragent.enabled = false;
            player.transform.SetPositionAndRotation(getDestination(destinationTag).transform.position,getDestination(destinationTag).transform.rotation);
            playeragent.enabled = true;
            yield return null;
        }
    }

    // 遍历全部protal 找到对应的标签
    private TransitionDestinion getDestination(TransitionDestinion.DestinationTag destinationTag)
    {
        var entrances = FindObjectsOfType<TransitionDestinion>();
        for (int i = 0; i < entrances.Length; i++)
        {
            if (entrances[i].destinationTag == destinationTag)
            {
                return entrances[i];
            } 
        }
        return null;
    }

    public void TransitionToMain()
    {
        StartCoroutine(LoadMain());
    }

    public void TransitionToFirstLevel()
    {
        StartCoroutine(LoadLevel("01"));
    }

    public void TransitionToLoadgame()
    {
        StartCoroutine(LoadLevel(SaveManager.Instance.SceneName));
    }
    IEnumerator LoadLevel(string scene)
    {
        ScenceFade fade = Instantiate(scenceFaderPrefab);
        if (scene != "")
        {
            yield return StartCoroutine(fade.FadeOut(2.5f));
            yield return SceneManager.LoadSceneAsync(scene);
            yield return player = Instantiate(playerPrefab, GameManager.Instance.GetEntrance().position,
            GameManager.Instance.GetEntrance().rotation);
            // 保存游戏
            yield return StartCoroutine(fade.FadeIn(2.5f));
            SaveManager.Instance.SavePlayerData();
            yield break;
        }
    }

    IEnumerator LoadMain()
    {
        ScenceFade fade = Instantiate(scenceFaderPrefab);
        yield return StartCoroutine(fade.FadeOut(2f));
        SaveManager.Instance.SavePlayerData();
        //效果
        yield return StartCoroutine(fade.FadeIn(2f));
        yield return SceneManager.LoadSceneAsync("Main");
        yield break;
    }
    // 要注册观察者
    // 在update里面
    public void EndNotify()
    {
        if (fadeFinished)
        {
            fadeFinished = false;
            StartCoroutine(LoadMain());
        }
    }
}
/*
 void Transform.SetPositionAndRoation(Vector3 pos,Quaternion roation);
 
 设置变换组件世界空间和旋转
 
 
 *  在后台异步加载场景
SceneManager.LoadSceneAsync
public static AsyncOperation LoadSceneAsync (string sceneName, SceneManagement.LoadSceneMode mode= LoadSceneMode.Single);
public static AsyncOperation LoadSceneAsync (int sceneBuildIndex, SceneManagement.LoadSceneMode mode= LoadSceneMode.Single);
public static AsyncOperation LoadSceneAsync (string sceneName, SceneManagement.LoadSceneParameters parameters);
public static AsyncOperation LoadSceneAsync (int sceneBuildIndex, SceneManagement.LoadSceneParameters parameters);

参数
sceneName	要加载的场景的名称或路径。
sceneBuildIndex	Build Settings 中要加载场景的索引。
mode	如果为 LoadSceneMode.Single，则系统将在加载场景之前卸载所有当前场景。
parameters	用于将各种参数（除了名称和索引）收集到单个位置的结构。

返回
AsyncOperation 使用 AsyncOperation 确定操作是否已完成。

描述
在后台异步加载场景。

You can provide the full Scene path, the path shown in the Build Settings window, or just the Scene name. If you only provide the Scene name, Unity loads the first Scene in the list that matches. If you have multiple Scenes with the same name but different paths, you should use the full Scene path in the Build Settings.

Examples of supported formats:
"Scene1"
"Scenes/Scene1"
"Scenes/Others/Scene1"
"Assets/scenes/others/scene1.unity"

Note: Scene name input is not case-sensitive.
If you call this method with an invalid sceneName or sceneBuildIndex, Unity throws an exception.

例子:
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Example : MonoBehaviour
{
    void Update()
    {
        // Press the space key to start coroutine
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Use a coroutine to load the Scene in the background
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene2");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
 */

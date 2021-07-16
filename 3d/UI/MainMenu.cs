using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour
{
   private Button newGameBtn;
   private Button continueBtn;
   private Button quitBtn;

   private PlayableDirector director;
   private void Awake()
   {
       newGameBtn = transform.GetChild(0).GetComponent<Button>();
       continueBtn = transform.GetChild(1).GetComponent<Button>();
       quitBtn = transform.GetChild(2).GetComponent<Button>();
       
       newGameBtn.onClick.AddListener(PlayTimeLine);
       continueBtn.onClick.AddListener(continueSence);
       quitBtn.onClick.AddListener(QuitGame);
       
       director = FindObjectOfType<PlayableDirector>();
       director.stopped += newGame;// 参数要一样
   }

   
   void PlayTimeLine()
   {
       director.Play();
   }
   

   public void newGame(PlayableDirector obj)
   {
       PlayerPrefs.DeleteAll();
       
       // 转换场景
       ScenceController.Instance.TransitionToFirstLevel();
       
   }

   public void continueSence()
   {
        ScenceController.Instance.TransitionToLoadgame();
   }

   void QuitGame()
   {
       Application.Quit();
       Debug.Log("quit!!");
   }
}

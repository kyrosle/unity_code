using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// UI 总管理脚本
// 单例模式
public class UIManager : MonoBehaviour
{
    //方便 其他功能调用 该脚本
    public static UIManager instance;
    
    //控制元素 
    public GameObject HealthBar;
    public GameObject gameOverPanel;

    [Header("UI Elements")]
    public GameObject pauseMenu;
    public Slider bossHealthBar;

    private void Awake()
    {
        // 单例模式 
        if (instance==null)
        {
            instance=this;   
        }else
            Destroy(gameObject);
    }    

    // 控制 血量ui
    public void UpdateHealth(float currentHealth)
    {
        switch (currentHealth)
        {
                case 3:
                    HealthBar.transform.GetChild(0).gameObject.SetActive(true);
                    HealthBar.transform.GetChild(1).gameObject.SetActive(true);
                    HealthBar.transform.GetChild(2).gameObject.SetActive(true);
                    break;   
                case 2:
                    HealthBar.transform.GetChild(0).gameObject.SetActive(true);
                    HealthBar.transform.GetChild(1).gameObject.SetActive(true);
                    HealthBar.transform.GetChild(2).gameObject.SetActive(false);
                    break;   
                case 1:
                    HealthBar.transform.GetChild(0).gameObject.SetActive(true);
                    HealthBar.transform.GetChild(1).gameObject.SetActive(false);
                    HealthBar.transform.GetChild(2).gameObject.SetActive(false);
                    break;   
                case 0:
                    HealthBar.transform.GetChild(0).gameObject.SetActive(false);
                    HealthBar.transform.GetChild(1).gameObject.SetActive(false);
                    HealthBar.transform.GetChild(2).gameObject.SetActive(false);
                    break;   
        }
    }

    // 暂停ui
    public void PauseGame(){
        //显示 ui
        pauseMenu.SetActive(true);
        //暂停 or 百分比减缓 
        Time.timeScale=0;
    }

    // 返回游戏
    public void ReasumeGame(){
        // 关闭 暂停ui
        pauseMenu.SetActive(false);
        // 恢复时间
        Time.timeScale=1;
    }

    // 控制boss 血量显示条
    public void SetBossHealth(float health){
        bossHealthBar.maxValue=health;
    }

    public void UpdateBossHealth(float health){
        bossHealthBar.value=health;
    }


    // 游戏结束 ui
    public void GameOverUI(bool playerDead){
        // 根据 玩家 情况 实时检测
        gameOverPanel.SetActive(playerDead);
    }

    // 当前场景 重新开始
    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.DeleteKey("playerHealth");
    }

    // 整个 游戏重新开始
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        PlayerPrefs.DeleteKey("playerHealth");
    }

    // 进入下一关
    public void NextLevel(){
        // 加载next场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    // 退出游戏 只在 实装有用
    public void QuitGame()
    {
        Application.Quit();
    }
}

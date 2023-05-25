using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


// 控制玩家的状态: 1. 玩家的生命值 2. 玩家是否处于无敌状态


public class PlayerManager : MonoBehaviour
{
    // 属性值
    public int health = 5;
    public int playerScore = 0;
    public bool isDead;
    public bool isDefeated;

    public GameObject bornEffectPrefab;

    public TMP_Text playerHealthText;
    public TMP_Text playerScoreText;

    public GameObject gameOverUI;   
    


    // 单例模式
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    // 游戏一开始就会执行的方法，将实例赋值给instance
    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 实时检测玩家是否按下ESC按键，如果按下，游戏结束，并返回到主菜单
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenu();
        }


        // 如果玩家死亡，游戏结束
        if(isDefeated)
        {
            // 游戏结束，显示游戏结束UI
            Invoke("ReturnToMenu", 3);
            gameOverUI.SetActive(true);
            return; 
        }


        // 玩家死亡,但是游戏并未结束
        if(isDead&& !isDefeated)
        {
            // 游戏结束，显示游戏结束UI
            // Invoke("ReturnToMenu", 3);
            Recover();
        }

        // 更新UI
        playerHealthText.text = health.ToString();
        playerScoreText.text = playerScore.ToString();
        
    }



    // 玩家复活的方法
    public void Recover()
    {
        if (health <= 0)
        {
            // 玩家生命值为0，游戏结束
            isDefeated = true;
            // 游戏结束，显示游戏结束UI
            Invoke("ReturnToMenu", 3);
        }
        else
        { 
            // 玩家生命值不为0，玩家复活
            health--;
            // 更新UI
            // UIManager.Instance.UpdatePlayerHealth(health);
            // 重置玩家位置
            GameObject player = Instantiate(bornEffectPrefab, new Vector3(-2, -8, 0), Quaternion.identity);
            isDead = false;

        }
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}

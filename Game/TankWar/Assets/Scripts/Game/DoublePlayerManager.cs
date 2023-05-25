using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DoublePlayerManager : MonoBehaviour
{
    // 属性值
    public int health1 = 5;
    public int playerScore1 = 0;

    public int health2 = 5;
    public int playerScore2 = 0;

    public bool isDead1;
    public bool isDead2;

    // 玩家完全处于死亡状态: false(默认为false),当生命值被耗尽的时候设置为true
    public bool finallyDead1;
    public bool finallyDead2;


    public bool isDefeated;

    public GameObject bornEffectPrefab1;
    public GameObject bornEffectPrefab2;


    public TMP_Text player1HealthText;
    public TMP_Text player1ScoreText;

    public TMP_Text player2HealthText;
    public TMP_Text player2ScoreText;

    public GameObject gameOverUI;
    


    // 单例模式
    private static DoublePlayerManager instance;

    public static DoublePlayerManager Instance
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

        if(finallyDead1&&finallyDead2)
        {
            isDefeated = true;
        }



        // 玩家死亡,但是游戏并未结束
        if(isDead1)
        {
            Recover1();
        }

        if (isDead2)
        {
            Recover2();
        }


        // 更新UI1
        player1HealthText.text = health1.ToString();
        player1ScoreText.text = playerScore1.ToString();

        // 更新UI2
        player2HealthText.text = health2.ToString();
        player2ScoreText.text = playerScore2.ToString();

    }



    // 玩家复活的方法
    public void Recover1()
    {
        if (health1 <= 0)
        {
            isDead1 = true;
            finallyDead1 = true;
        }
        else
        { 
            // 玩家生命值不为0，玩家复活
            health1--;
            if (health1 < 0)
                health1 = 0;
            // 重置玩家位置
            GameObject player1 = Instantiate(bornEffectPrefab1, new Vector3(-2, -8, 0), Quaternion.identity);
            isDead1 = false;

        }
    }


    // 玩家复活的方法
    public void Recover2()
    {
        if (health2 <= 0)
        {
            // 玩家二
            isDead2 = true;
            finallyDead2 = true;
        }
        else
        {
            // 玩家生命值不为0，玩家复活
            health2--;
            if (health2 < 0)
                health2 = 0;
            // 重置玩家位置
            GameObject player2 = Instantiate(bornEffectPrefab2, new Vector3(2, -8, 0), Quaternion.identity);
            isDead2 = false;

        }
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}

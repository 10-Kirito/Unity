using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    public int gameMode;
    public Transform position1;
    public Transform position2;
    public Transform position3;

    // 设置计数器:
    // 1 ： 单人模式
    // 2 ： 双人模式
    // 3 ： 退出游戏
    private int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(++count == 4)
                count = 1;
            gameMode = count;
            transform.position = gameMode == 1 ? position1.position : gameMode == 2 ? position2.position : position3.position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(--count == 0)
                count = 3;
            gameMode = count;
            transform.position = gameMode == 1 ? position1.position : gameMode == 2 ? position2.position : position3.position;
        }

        // 如果玩家选择好游戏模式，按下空格键，开始游戏
        if (gameMode == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("加载单人游戏场景");
            // 加载游戏场景
            SceneManager.LoadScene(1);
        }

        if(gameMode == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("加载双人游戏场景");
            // 加载游戏场景
            SceneManager.LoadScene(2);
        }
        if(gameMode == 3 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("退出游戏");
            // 退出游戏
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

    }
}

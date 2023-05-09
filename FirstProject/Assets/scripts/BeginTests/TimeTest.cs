using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        // 游戏从开始到现在所花费的时间
        Debug.Log(Time.time);
        // 时间的缩放值，就是时间倍速
        Debug.Log(Time.timeScale);
        // 固定时间间隔
        Debug.Log(Time.fixedDeltaTime);
        // 上一帧到这一帧所用的游戏时间
        Debug.Log(Time.deltaTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        // 计时器
        timer += Time.deltaTime;
        // 上一帧到这一帧所用的游戏时间
        Debug.Log(Time.deltaTime);

        // 如果游戏运行时间大于10秒的话
        if (timer > 10)
        {
            Debug.Log("时间大于10秒");
        }
    }
}

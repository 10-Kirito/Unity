using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 1. 游戏数据文件夹路径(只读，加密存储)
        Debug.Log(Application.dataPath);
        // 上面的函数会返回文件路径:D:/Desktop/Unity/FirstProject/Assets,即我们工程的文件夹
        // 这样的话，如果我们想要获得我们工程中的某一个文件的话，就可以使用下面的方式:
        // Debug.Log(Application.dataPath + '/新建文件');

        // 2. 持久化文件路径(可写)
        Debug.Log(Application.persistentDataPath);
        // 输出结果:
        // C:/Users/z1769/AppData/LocalLow/DefaultCompany/FirstProject

        // 3. StreamingAssets文件夹路径(只读)
        Debug.Log(Application.streamingAssetsPath);
        // 输出结果:
        // D:/Desktop/Unity/FirstProject/Assets/StreamingAssets
        // 该文件路径师用来存储一些配置文件的，该文件里面的内容是不需要进行加密的

        // 4. 临时文件夹
        Debug.Log(Application.temporaryCachePath);
        // 输出结果:
        // C:/Users/z1769/AppData/Local/Temp/DefaultCompany/FirstProject

        // 控制是否在后台运行
        Debug.Log(Application.runInBackground);

        // 5. 打开URL
        Application.OpenURL("www.google.com");

        // 6. 退出游戏
        Application.Quit();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneTest : MonoBehaviour
{
    // public Slider progressBar;
    // Start is called before the first frame update
    void Start()
    {
        // 两个类，场景类，场景管理类

        // 下面的代码，我们传入参数的时候，可以传入场景的名称或者场景的编号
        // SceneManager.LoadScene("MyScene");

        // 异步加载名为"NewScene"的场景
        /*AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MyScene");
        while (!asyncOperation.isDone)
        {
            // 获取场景加载的进度条，并且设置进度条的值
            // float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            // progressBar = GetComponent<Slider>();
            // progressBar.value = progress;
            // 等待场景加载完成
            yield return null;

            // 异步加载完场景之后，执行其余的动作，比如说我们可以将之前的场景卸载
            // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            // 我们异步加载场景的时候还可以获取加载的进度
            // 我们可以使用asyncOperatioin.progress属性来获得加载的进度
        }*/

        // 获取当前场景
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        // 场景是否已经被加载
        Debug.Log(scene.isLoaded);
        // 场景路径
        Debug.Log(scene.path);

        // 场景索引号
        Debug.Log(scene.buildIndex);

        // 得到当前所有的游戏物体
        GameObject[] objects = scene.GetRootGameObjects();
        Debug.Log(objects.Length);

        // 创建新场景
        Scene newScene = SceneManager.CreateScene("MySecondScene");
        // 已加载场景个数
        Debug.Log(SceneManager.sceneCount);

        // 卸载场景
        SceneManager.UnloadSceneAsync(newScene);

        // 加载场景，替换场景,Single参数作用是替换, Additive是共存，会将两个场景的东西叠加在一起
        // SceneManager.LoadScene("MyScene", LoadSceneMode.Single);
        SceneManager.LoadScene("MyScene", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

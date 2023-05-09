using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncTest : MonoBehaviour
{
    AsyncOperation operation;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // 协程方法用来异步加载场景
    IEnumerator LoadScene()
    {
        operation = SceneManager.LoadSceneAsync(1);
        // 加载完成场景先不要进行跳转，等待玩家进行交互，然后再去进行跳转
        operation.allowSceneActivation = false;
        yield return operation;
    }

    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        // 加载场景数值的最大值为0.9
        Debug.Log(operation.progress);
        timer += Time.deltaTime;
        if (timer >5)
        {
            operation.allowSceneActivation = true;
        }
    }
}

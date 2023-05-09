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

    // Э�̷��������첽���س���
    IEnumerator LoadScene()
    {
        operation = SceneManager.LoadSceneAsync(1);
        // ������ɳ����Ȳ�Ҫ������ת���ȴ���ҽ��н�����Ȼ����ȥ������ת
        operation.allowSceneActivation = false;
        yield return operation;
    }

    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        // ���س�����ֵ�����ֵΪ0.9
        Debug.Log(operation.progress);
        timer += Time.deltaTime;
        if (timer >5)
        {
            operation.allowSceneActivation = true;
        }
    }
}

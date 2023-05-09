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
        // �����࣬�����࣬����������

        // ����Ĵ��룬���Ǵ��������ʱ�򣬿��Դ��볡�������ƻ��߳����ı��
        // SceneManager.LoadScene("MyScene");

        // �첽������Ϊ"NewScene"�ĳ���
        /*AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MyScene");
        while (!asyncOperation.isDone)
        {
            // ��ȡ�������صĽ��������������ý�������ֵ
            // float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            // progressBar = GetComponent<Slider>();
            // progressBar.value = progress;
            // �ȴ������������
            yield return null;

            // �첽�����곡��֮��ִ������Ķ���������˵���ǿ��Խ�֮ǰ�ĳ���ж��
            // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            // �����첽���س�����ʱ�򻹿��Ի�ȡ���صĽ���
            // ���ǿ���ʹ��asyncOperatioin.progress��������ü��صĽ���
        }*/

        // ��ȡ��ǰ����
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        // �����Ƿ��Ѿ�������
        Debug.Log(scene.isLoaded);
        // ����·��
        Debug.Log(scene.path);

        // ����������
        Debug.Log(scene.buildIndex);

        // �õ���ǰ���е���Ϸ����
        GameObject[] objects = scene.GetRootGameObjects();
        Debug.Log(objects.Length);

        // �����³���
        Scene newScene = SceneManager.CreateScene("MySecondScene");
        // �Ѽ��س�������
        Debug.Log(SceneManager.sceneCount);

        // ж�س���
        SceneManager.UnloadSceneAsync(newScene);

        // ���س������滻����,Single�����������滻, Additive�ǹ��棬�Ὣ���������Ķ���������һ��
        // SceneManager.LoadScene("MyScene", LoadSceneMode.Single);
        SceneManager.LoadScene("MyScene", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

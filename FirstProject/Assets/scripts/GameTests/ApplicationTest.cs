using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 1. ��Ϸ�����ļ���·��(ֻ�������ܴ洢)
        Debug.Log(Application.dataPath);
        // ����ĺ����᷵���ļ�·��:D:/Desktop/Unity/FirstProject/Assets,�����ǹ��̵��ļ���
        // �����Ļ������������Ҫ������ǹ����е�ĳһ���ļ��Ļ����Ϳ���ʹ������ķ�ʽ:
        // Debug.Log(Application.dataPath + '/�½��ļ�');

        // 2. �־û��ļ�·��(��д)
        Debug.Log(Application.persistentDataPath);
        // ������:
        // C:/Users/z1769/AppData/LocalLow/DefaultCompany/FirstProject

        // 3. StreamingAssets�ļ���·��(ֻ��)
        Debug.Log(Application.streamingAssetsPath);
        // ������:
        // D:/Desktop/Unity/FirstProject/Assets/StreamingAssets
        // ���ļ�·��ʦ�����洢һЩ�����ļ��ģ����ļ�����������ǲ���Ҫ���м��ܵ�

        // 4. ��ʱ�ļ���
        Debug.Log(Application.temporaryCachePath);
        // ������:
        // C:/Users/z1769/AppData/Local/Temp/DefaultCompany/FirstProject

        // �����Ƿ��ں�̨����
        Debug.Log(Application.runInBackground);

        // 5. ��URL
        Application.OpenURL("www.google.com");

        // 6. �˳���Ϸ
        Application.Quit();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        // ��Ϸ�ӿ�ʼ�����������ѵ�ʱ��
        Debug.Log(Time.time);
        // ʱ�������ֵ������ʱ�䱶��
        Debug.Log(Time.timeScale);
        // �̶�ʱ����
        Debug.Log(Time.fixedDeltaTime);
        // ��һ֡����һ֡���õ���Ϸʱ��
        Debug.Log(Time.deltaTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        // ��ʱ��
        timer += Time.deltaTime;
        // ��һ֡����һ֡���õ���Ϸʱ��
        Debug.Log(Time.deltaTime);

        // �����Ϸ����ʱ�����10��Ļ�
        if (timer > 10)
        {
            Debug.Log("ʱ�����10��");
        }
    }
}

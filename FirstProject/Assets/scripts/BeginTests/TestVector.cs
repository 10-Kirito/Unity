using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ���������Դ������꣬��ת�����ŵȵ�
        Vector3 vector3 = new Vector3(1, 1, 1);

        Vector3 vector3_1 = new Vector3(0, 1, 0);

        // ������������ļн�
        Debug.Log(Vector3.Angle(vector3, vector3_1));

        // ��������֮��ľ���
        Debug.Log(Vector3.Distance(vector3, vector3_1));

        // ���
        Debug.Log(Vector3.Dot(vector3, vector3_1));

        // ���
        Debug.Log(Vector3.Cross(vector3, vector3_1));

        // ��ֵ, �ͺ���Ķ��������йأ�һ��ʱ��ƽ���Ĺ���
        Debug.Log(Vector3.Lerp(Vector3.zero, Vector3.one, 0.8f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��Ԫ��
public class QuaternionTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // ������Ԫ��
        Quaternion quaternion = Quaternion.identity;
        Debug.Log(quaternion);
        quaternion = transform.rotation;
        Debug.Log(quaternion);

        // ����ĳһ�������ķ���
        quaternion = Quaternion.LookRotation(new Vector3(1, 1, 1));
        Debug.Log(quaternion);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

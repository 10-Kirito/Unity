using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���ĵ��
        // ����������0���м�2���Ҽ�1
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("���������");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("����Ҽ����");
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            Debug.Log("����м����");
        }

        // ��������ĳһ������
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("��������������");
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("������̧��");
        }
      
    }
}

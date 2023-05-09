using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
    public GameObject gameObjectTemp;
    // Start is called before the first frame update
    void Start()
    {
        // ��ȡλ��
        Debug.Log(transform.position);
        Debug.Log(transform.localPosition);

        // ��ȡ��ת
        Debug.Log(transform.rotation);
        Debug.Log(transform.localRotation);
        Debug.Log(transform.eulerAngles);
        Debug.Log(transform.localEulerAngles);

        // ��ȡ����
        Debug.Log(transform.localScale);

        // ��ȡXYZ������
        // X
        Debug.Log(transform.forward);
        // Z
        Debug.Log(transform.right);
        // Y
        Debug.Log(transform.up);

        // ���ӹ�ϵ
        // ��ȡ������
        GameObject tempParent =  transform.parent.gameObject;
        // ���������
        Debug.Log(transform.childCount);
        // �����������֮��ĸ��ӹ�ϵ
        transform.DetachChildren();
        // ��ȡ������
        Transform transform_temp = transform.Find("Child");
        transform_temp = transform.GetChild(0);
        // �ж���һ�������ǲ�������һ�������������
        bool res = transform_temp.IsChildOf(transform);
        Debug.Log(res);
        // ����Ϊ������
        transform_temp.SetParent(transform);

    }

    // Update is called once per frame
    void Update()
    {
        // ʱʱ�̿̿���000��
        // transform.LookAt(Vector3.zero);

        // ����UP��Ҳ����Y����ת
        transform.Rotate(Vector3.up, 1);

        // ����ĳһ��������ת
        // ����������Ҫ����ȥ������������һ����Ŀ�������λ�ã��ڶ�����Χ����һ���������ת��������������ת������
        transform.RotateAround(gameObjectTemp.transform.position, Vector3.up, 5);
    }
}

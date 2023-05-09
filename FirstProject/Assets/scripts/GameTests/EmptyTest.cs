using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTest : MonoBehaviour
{
    public GameObject Cube;

    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        // �õ���ǰ�ű������ص�����
        GameObject gameObject = this.gameObject;
        Debug.Log(gameObject.name);
        // Tag
        Debug.Log(gameObject.tag);
        // Layer
        Debug.Log(gameObject.layer);
        // ��ӡ���������Ϣ
        Debug.Log(Cube.name);
        // ��ǰ��Ӧ��������ļ���״̬
        Debug.Log(Cube.activeInHierarchy);
        // �ж�����ļ���״̬
        Debug.Log(Cube.activeSelf);
        // ��ȡTransform���
        Transform transform = this.transform;
        Debug.Log(transform);
        // ��ȡ��������������˵��ײ��ȵ�
        CapsuleCollider box = GetComponent<CapsuleCollider>();
        Debug.Log(box);

        // ��ȡ��ǰ��������������ϵ�ĳ�����
        // GetComponentInChildren<CapsuleCollider>(box);

        // ��ȡ��ǰ����ĸ��������ϵ�ĳ�����
        // GetComponentInParent<BoxCollider>(box);

        // ���һ�����
        gameObject.AddComponent<AudioSource>();

        // ͨ����Ϸ�������������ȡ��Ϸ����
        // GameObject test = GameObject.Find("Test");

        // ͨ����Ϸ��ǩ����ȡ��Ϸ����
        // test = GameObject.FindWithTag("Enemy");
        // ��������ļ���״̬
        // test.SetActive(false);


        // ͨ�������Ȼ��Ԥ�Ƽ���Ȼ��ȥʵ����һ������
        GameObject temp = Instantiate(Prefab, transform);

        // �������
        Destroy(temp);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

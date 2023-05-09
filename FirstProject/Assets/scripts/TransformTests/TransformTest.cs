using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
    public GameObject gameObjectTemp;
    // Start is called before the first frame update
    void Start()
    {
        // 获取位置
        Debug.Log(transform.position);
        Debug.Log(transform.localPosition);

        // 获取旋转
        Debug.Log(transform.rotation);
        Debug.Log(transform.localRotation);
        Debug.Log(transform.eulerAngles);
        Debug.Log(transform.localEulerAngles);

        // 获取缩放
        Debug.Log(transform.localScale);

        // 获取XYZ轴向量
        // X
        Debug.Log(transform.forward);
        // Z
        Debug.Log(transform.right);
        // Y
        Debug.Log(transform.up);

        // 父子关系
        // 获取父物体
        GameObject tempParent =  transform.parent.gameObject;
        // 子物体个数
        Debug.Log(transform.childCount);
        // 解除与子物体之间的父子关系
        transform.DetachChildren();
        // 获取子物体
        Transform transform_temp = transform.Find("Child");
        transform_temp = transform.GetChild(0);
        // 判断另一个物体是不是另外一个物体的子物体
        bool res = transform_temp.IsChildOf(transform);
        Debug.Log(res);
        // 设置为父物体
        transform_temp.SetParent(transform);

    }

    // Update is called once per frame
    void Update()
    {
        // 时时刻刻看向000点
        // transform.LookAt(Vector3.zero);

        // 绕着UP轴也就是Y轴旋转
        transform.Rotate(Vector3.up, 1);

        // 绕着某一个物体旋转
        // 这里我们需要穿进去三个参数，第一个是目标物体的位置，第二个是围绕哪一个轴进行旋转，第三个就是旋转的速率
        transform.RotateAround(gameObjectTemp.transform.position, Vector3.up, 5);
    }
}

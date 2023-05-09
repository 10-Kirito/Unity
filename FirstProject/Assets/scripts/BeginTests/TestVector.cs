using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 该向量可以代表坐标，旋转，缩放等等
        Vector3 vector3 = new Vector3(1, 1, 1);

        Vector3 vector3_1 = new Vector3(0, 1, 0);

        // 求出两个向量的夹角
        Debug.Log(Vector3.Angle(vector3, vector3_1));

        // 计算两点之间的距离
        Debug.Log(Vector3.Distance(vector3, vector3_1));

        // 点乘
        Debug.Log(Vector3.Dot(vector3, vector3_1));

        // 叉乘
        Debug.Log(Vector3.Cross(vector3, vector3_1));

        // 插值, 和后面的动画制作有关，一个时间平滑的过渡
        Debug.Log(Vector3.Lerp(Vector3.zero, Vector3.one, 0.8f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

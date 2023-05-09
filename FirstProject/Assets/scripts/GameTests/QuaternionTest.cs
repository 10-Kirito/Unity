using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 四元数
public class QuaternionTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // 创建四元数
        Quaternion quaternion = Quaternion.identity;
        Debug.Log(quaternion);
        quaternion = transform.rotation;
        Debug.Log(quaternion);

        // 看向某一个向量的方向
        quaternion = Quaternion.LookRotation(new Vector3(1, 1, 1));
        Debug.Log(quaternion);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

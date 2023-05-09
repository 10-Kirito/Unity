using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 获取水平轴
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log("horizontal: "+horizontal + "  , vertical: " + vertical);

        // 虚拟按键
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("空格");
        }
    }
}

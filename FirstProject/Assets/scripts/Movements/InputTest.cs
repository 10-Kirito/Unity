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
        // 鼠标的点击
        // 按下鼠标左键0、中间2、右键1
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("鼠标左键点击");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("鼠标右键点击");
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            Debug.Log("鼠标中键点击");
        }

        // 持续按下某一个按键
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("持续按下鼠标左键");
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("鼠标左键抬起");
        }
      
    }
}

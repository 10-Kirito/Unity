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
        // ��ȡˮƽ��
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log("horizontal: "+horizontal + "  , vertical: " + vertical);

        // ���ⰴ��
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("�ո�");
        }
    }
}

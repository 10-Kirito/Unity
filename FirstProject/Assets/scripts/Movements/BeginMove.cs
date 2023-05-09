using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginMove : MonoBehaviour
{
    private CharacterController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // ˮƽ��
        float horizontal = Input.GetAxis("Horizontal");
        // ��ֱ��
        float vertical = Input.GetAxis("Vertical");

        // ������һ����������    
        Vector3 dir = new Vector3(horizontal, 0, vertical);

        // ��ҳ���÷����ƶ�
        player.SimpleMove(dir * 10);
    }
}

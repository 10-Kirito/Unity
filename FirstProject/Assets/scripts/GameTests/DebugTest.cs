using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, Unity");
        Debug.LogWarning("Warning");
        Debug.LogError("Error");
    }

    // Update is called once per frame
    void Update()
    {
        // ����һ����
        Debug.DrawLine(Vector3.zero, Vector3.one);

        // ����һ������
        Debug.DrawRay(Vector3.zero, Vector3.up, Color.red);
    }
}

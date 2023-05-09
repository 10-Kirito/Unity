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
        // 拿到当前脚本所挂载的物体
        GameObject gameObject = this.gameObject;
        Debug.Log(gameObject.name);
        // Tag
        Debug.Log(gameObject.tag);
        // Layer
        Debug.Log(gameObject.layer);
        // 打印子组件的信息
        Debug.Log(Cube.name);
        // 当前对应组件真正的激活状态
        Debug.Log(Cube.activeInHierarchy);
        // 判断自身的激活状态
        Debug.Log(Cube.activeSelf);
        // 获取Transform组件
        Transform transform = this.transform;
        Debug.Log(transform);
        // 获取其余的组件，比如说碰撞体等等
        CapsuleCollider box = GetComponent<CapsuleCollider>();
        Debug.Log(box);

        // 获取当前物体的子物体身上的某个组件
        // GetComponentInChildren<CapsuleCollider>(box);

        // 获取当前物体的父物体身上的某个组件
        // GetComponentInParent<BoxCollider>(box);

        // 添加一个组件
        gameObject.AddComponent<AudioSource>();

        // 通过游戏物体的名称来获取游戏物体
        // GameObject test = GameObject.Find("Test");

        // 通过游戏标签来获取游戏物体
        // test = GameObject.FindWithTag("Enemy");
        // 设置组件的激活状态
        // test.SetActive(false);


        // 通过代码先获得预制件，然后去实例化一个物体
        GameObject temp = Instantiate(Prefab, transform);

        // 销毁组件
        Destroy(temp);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

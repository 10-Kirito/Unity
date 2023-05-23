using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornPlayer : MonoBehaviour
{
// 1. 产生一个坦克
    public GameObject playerPrefab;



    // Start is called before the first frame update
    void Start()
    {
        // 异步调用
        Invoke("BornTank", 1f);
        // 摧毁自身
        Destroy(gameObject, 1f);
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }

    private void BornTank()
    {
        // 1. 产生一个坦克
        Instantiate(playerPrefab, transform.position, Quaternion.identity);



        // 2. 产生特效
        // 3. 产生声音
        
    }
}

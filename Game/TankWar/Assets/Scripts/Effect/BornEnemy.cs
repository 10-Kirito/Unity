using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornEnemy : MonoBehaviour
{
    // 1. ��������̹��Ԥ����
    public GameObject[] enemyPrefabList;

    // public static event System.Action<int> OnEnemyInstantiate;
    public static int tankCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        Invoke("BornTank", 1f);
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BornTank()
    {
        // 1. �������һ������̹��
        int num = Random.Range(0, 3);
        GameObject enemy = Instantiate(enemyPrefabList[num], transform.position, Quaternion.identity);
        EnemyController enemyScript = enemy.GetComponent<EnemyController>();
        tankCount++;
        if (enemyScript != null)
        {
            enemyScript.setId(tankCount);
        }
        // 2. ������Ч
        // 3. ��������
    }

}

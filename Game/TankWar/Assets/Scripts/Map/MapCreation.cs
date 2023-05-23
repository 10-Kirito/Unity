using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    // 1. 用来装饰地图的物体
    // 0. 家 1. 墙 2. 障碍 3. 河流 4. 草 5. 空气墙 6. 敌人出生特效 7. 玩家出生特效
    public GameObject[] item;

    // 已经有物体的位置
    private List<Vector3> itemPositionList = new List<Vector3>();

    private void Awake()
    {
        InitMap();
    }


    private void InitMap()
    {
        // 实例化老家
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        // 用墙把老家围起来
        CreateItem(item[1], new Vector3(-1f, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1f, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1f, -7f, 0), Quaternion.identity);
        CreateItem(item[2], new Vector3(0, -7f, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1f, -7f, 0), Quaternion.identity);


        // 实例化上下外围墙
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[5], new Vector3(i, 9, 0), Quaternion.identity);
            CreateItem(item[5], new Vector3(i, -9, 0), Quaternion.identity);
        }
        // 实例化左右外围墙
        for (int i = -8; i < 9; i++)
        {
            CreateItem(item[5], new Vector3(-11.25f, i, 0), Quaternion.identity);
            CreateItem(item[5], new Vector3(11.25f, i, 0), Quaternion.identity);
        }

        // 初始化玩家
        GameObject player = Instantiate(item[7], new Vector3(-2, -8, 0), Quaternion.identity);

        // 初始化敌人
        Instantiate(item[6], new Vector3(-10, 8, 0), Quaternion.identity);
        Instantiate(item[6], new Vector3(10, 8, 0), Quaternion.identity);
        Instantiate(item[6], new Vector3(0, 8, 0), Quaternion.identity);


        // 产生敌人,每隔一段时间产生一个敌人,InvokeRepeating(方法名, 第一次调用的时间, 间隔时间)
        InvokeRepeating("CreateEnemy", 4, 5);


        // 实例化地图
        // 1. 实例化墙
        for (int i = 0; i < 60; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
        }
        // 2. 实例化障碍
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
        }
        // 3. 实例化河流
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[3], CreateRandomPosition(), Quaternion.identity);
        }
        // 4. 实例化草
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
        }
    }

    private GameObject CreateItem(GameObject createGameObject, Vector3 createPosition, Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);

        return itemGo;
    }

    // 产生随机位置的方法
    private Vector3 CreateRandomPosition()
    {
        // 不生成x=-10,10 y=-8,8的位置
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!HasThePosition(createPosition))
            {
                return createPosition;
            }
        }
    }

    // 判断位置列表中是否有这个位置
    private bool HasThePosition(Vector3 createPos)
    {
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            if (createPos == itemPositionList[i])
            {
                return true;
            }
        }

        return false; 
    }

    // 产生敌人的方法
    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 enemyPos = new Vector3();
        if (num == 0)
        {
            enemyPos = new Vector3(-10, 8, 0);
        }
        else if (num == 1)
        {
            enemyPos = new Vector3(0, 8, 0);
        }
        else
        {
            enemyPos = new Vector3(10, 8, 0);
        }
        GameObject tank = CreateItem(item[6], enemyPos, Quaternion.identity);

    }

}

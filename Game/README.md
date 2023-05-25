# 坦克大战

# 1. 控制坦克的移动

实现逻辑，当我们按下相应的控制按键之后，我们会切换坦克的显示图片为相应的坦克图片，并且通过我们预先设置的速度来进行坦克的移动：

下面的代码仅仅是对于水平方向的按键的一个触发控制，其次我们理想状况下的设定是***坦克只能水平和垂直移动，所以说我们每一次读取完`horizantal`的值或者`vertical`的值之后，就会立即结束函数，进行下一帧的更新。***这样就可以解决我们想要控制坦克只能水平和垂直移动的问题。

```C#
private float moveSpeed = 10;

······
private void Move(){
    float horizantal = Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right * horizantal * moveSpeed * Time.fixedDeltaTime, Space.World);

    if (horizantal > 0)
    {
        spriteRenderer.sprite = tankSprite[1];
    }
    else if (horizantal < 0)
    {
        spriteRenderer.sprite = tankSprite[3];
    }

    if (horizantal != 0)
    {
        return;
    }
}
```

# 2. 生成玩家

其实就是一个动画播放完毕之后***new***出来一个坦克对象：

```C#
void Start()
{
    // 异步调用
    Invoke("BornTank", 1f);
    // 摧毁自身
    Destroy(gameObject, 1f);
}

private void BornTank()
{
    // 1. 产生一个坦克
    Instantiate(playerPrefab, transform.position, Quaternion.identity);
    // 2. 产生特效
    // 3. 产生声音
}
```

# 3. 创建地图

地图是随机生成的：

```C#
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
```

实例化的过程中，会检测当前位置是否已经生成物体，如果该位置已经有物体生成的话，就会重新随机生成一个位置:

```C#
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
```





# 4. 单人模式





# 5. 双人模式

***积分：***

玩家会记录自己所发射的子弹，如果说自己的子弹和敌人相撞，即敌人被我们摧毁的话，我们的分数累加。

下面是具体的实现方法：利用事件在不同的物体之间传递消息：

```C#
// 定义事件
// 如果子弹射到了敌人，如果是玩家的子弹的话，会触发下面的事件，记录玩家的分数
public delegate void GetScore(string tag);
public static event GetScore OnGetScore;



// 订阅事件
void OnGetScore()
{
    Bullet.OnGetScore += ifMyBullet;
}

void ifMyBullet(string tag)
{
    if (isDouble)
    {
        if (tag == "PlayerBullet")
        {
            DoublePlayerManager.Instance.playerScore1++;
        }
    }
}



void Start()
{
    // 订阅子弹击中敌人的事件，如果是自己的子弹的话，则对应的分数就会加一
    OnGetScore();
}
```




















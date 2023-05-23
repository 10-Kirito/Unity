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

# 2. 生成玩家1

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

# 3. 随机生成敌人

> 敌人的种类暂时设置为三类：
>
> - 低级坦克，玩家射中一发之后就可以摧毁相应的坦克敌人，子弹速度为4，射击频率很快；
> - 中级坦克，玩家需要射中两发才可以摧毁相应的坦克敌人，子弹速度为3，射击频率中等水平；
> - 高级坦克，玩家需要射中5发才可以摧毁相应的坦克敌人，子弹速度为2，射击频率很慢；

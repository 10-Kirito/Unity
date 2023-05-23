using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    // 玩家的属性：
    // 1. 玩家移动的速度
    public float moveSpeed = 10;
    // 2. 生成子弹时候的角度
    private Vector3 bullectEulerAngles;
    // 3. 生成子弹的CD
    private float timeVal;
    // 4. 玩家的生命值
    // private float health = 100;
    // 5. 玩家是否处于无敌状态
    private bool isDefended = true;
    // 6. 玩家的无敌时间
    private float defendTimeVal = 2;
    // 7. 玩家射击子弹的CD
    private float timeValShoot = 0.6f;


    // 引用组件:
    // 1. 玩家不同方向的时候精灵渲染器渲染的内容
    public Sprite[] tankSprite; // 上 右 下 左
    // 2. 子弹预制体
    public GameObject bulletPrefab;
    // 3. 爆炸特效
    public GameObject explosionPrefab;
    // 4. 精灵渲染器
    private SpriteRenderer spriteRenderer;
    // 5. 无敌特效
    public GameObject defendEffectPrefab;

    public static bool isDouble;

    void OnGetScore()
    {
        Bullet.OnGetScore += ifMyBullet;
    }

    void ifMyBullet(string tag)
    {
        if (tag == "Player2Bullet")
        {
            DoublePlayerManager.Instance.playerScore2++;
        }
    }


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = tankSprite[0];
    }


    // Start is called before the first frame update
    void Start()
    {
        OnGetScore();
    }

    // Update is called once per frame
    void Update()
    {
        // 是否处于无敌状态
        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal <= 0)
            {
                defendEffectPrefab.SetActive(false);
                isDefended = false;
            }
        }


        // 攻击CD
        if (timeVal >= timeValShoot)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }


    private void FixedUpdate()
    {
        if (!isDouble)
        {
            if (PlayerManager.Instance.isDefeated)
            {
                return;
            }

            Move();
        }
        else
        {
            if (DoublePlayerManager.Instance.isDefeated)
            {
                return;
            }

            Move();
        }



    }


    // 1. 控制坦克的移动
    private void Move()
    {
        float horizantal = Input.GetAxis("HorizontalPlayer2");
        transform.Translate(Vector3.right * horizantal * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (horizantal > 0)
        {
            spriteRenderer.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }
        else if (horizantal < 0)
        {
            spriteRenderer.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }

        if (horizantal != 0)
        {
            return;
        }

        float vertical = Input.GetAxis("VerticalPlayer2");
        transform.Translate(Vector3.up * vertical * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (vertical > 0)
        {
            spriteRenderer.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);
        }
        else if (vertical < 0)
        {
            spriteRenderer.sprite = tankSprite[2];
            bullectEulerAngles = new Vector3(0, 0, -180);
        }
    }

    // 2. 坦克攻击方法

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            GameObject temp = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            temp.GetComponent<Bullet>().isPlayerBullet = true;
            timeVal = 0;
        }
    }

    // 3. 坦克的死亡方法
    private void Die()
    {
        // 如果处于无敌状态，不死亡
        if (isDefended)
        {
            return;
        }

        DoublePlayerManager.Instance.isDead2 = true;

        // 产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        // 摧毁坦克物体
        Destroy(gameObject);
    }

    // 4. 获取当前对象的刚体组件，设置将其弹力设置为0
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    // }
    // 4. 当玩家的坦克与不同的建筑物碰撞的时候，会触发不同的事件
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Home":
                // 玩家与老家碰撞，玩家死亡
                Debug.Log("这是老家");
                break;
            case "Wall":
                // 玩家与墙碰撞，玩家不死亡
                Debug.Log("这是墙");
                break;
            case "Barrier":
                // 玩家与障碍物碰撞，玩家不死亡
                Debug.Log("这是障碍物");
                break;
            case "Water":
                // 玩家与河流碰撞，玩家不死亡
                Debug.Log("这是河流");
                break;
            default:
                break;
        }
    }

    // 进入触发器
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            Debug.Log("这是草");
        }

    }
}

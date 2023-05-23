using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // 0. 切换游戏模式，双人还是单人
    public static bool isDouble;


    // 1. 敌人不同方向的时候精灵渲染器渲染的内容
    private SpriteRenderer spriteRenderer;
    public Sprite[] tankSprite; // 上 右 下 左
    // 2. 敌人被摧毁的特效
    public GameObject explosionPrefab;
    // 3. 敌人的子弹
    public GameObject bulletPrefab;
    // 4. 敌人的移动速度
    public float moveSpeed = 3;
    private float timeVal;
    private Vector3 bullectEulerAngles;

    // 5. 控制敌人转向的时间
    private float timeValChangeDirection;

    private float vertical = -1;
    private float horizantal;

    // 6. 坦克的唯一标识符
    public int id;
    // 7. 是否允许坦克开火
    private bool ifFire = true;
 

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 订阅事件
        OnHitWall();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDouble)
        {
            // 攻击的时间间隔
            if (timeVal >= 1.5f && !PlayerManager.Instance.isDefeated)
            {
                Attack();
            }
            else
            {
                timeVal += Time.deltaTime;
                // Debug.Log(timeVal);
            }
        }
        else
        {
            // 攻击的时间间隔
            if (timeVal >= 1.5f && !DoublePlayerManager.Instance.isDefeated)
            {
                Attack();
            }
            else
            {
                timeVal += Time.deltaTime;
                // Debug.Log(timeVal);
            }
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
        }else
        {
            if(DoublePlayerManager.Instance.isDefeated)
            {
                return;
            }
            Move();
        }
    }


    // 敌人的移动方法，控制敌人朝向玩家的位置移动，会自动避开障碍物
    private void Move()
    {
        // 1. 判断是否需要转向
        if(timeValChangeDirection >= 4){
            int num = Random.Range(0, 8);
            if (num > 3)
            {
                vertical = -1;
                horizantal = 0;
            }
            else if(num == 0)
            {
                vertical = 1;
                horizantal = 0;
            }
            else if(num > 0 && num <= 2)
            {
                vertical = 0;
                horizantal = -1;
            }
            else
            {
                vertical = 0;
                horizantal = 1;
            }
            timeValChangeDirection = 0;
        }else{
            timeValChangeDirection += Time.fixedDeltaTime;
        }

        // 2. 移动
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
        if (ifFire)
        {
            // 实例化子弹并且将其父组件设置为gameObject
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.setBelongId(id);
            timeVal = 0;
        }
    }


    private void resetFire()
    {
        ifFire = true;
    }

    // 订阅事件
    void OnHitWall()
    {
        Bullet.OnHitIronwall += ifHitWall;
    }

    void ifHitWall(int belongId)
    {
        if(id == belongId)
        {
            Debug.Log(id + "号坦克的子弹射中了墙壁");
            ifFire = false;
            Invoke("resetFire", 3);
            timeValChangeDirection = 4;
        }
    }



    // 敌人的死亡方法
    public void Die()
    {
        if (!isDouble)
        {
            // 0. 分数
            PlayerManager.Instance.playerScore++;
        }
        // 1. 产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        // 2. 产生声音

        // 3. 销毁自身
        Destroy(gameObject);
    }

    // 碰撞检测，如果碰到障碍物，就转向
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Barrier" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Water")
        {
            timeValChangeDirection = 4;
        }else if(collision.gameObject.tag == "Barrier")
        {
            Debug.Log("你撞到了空气墙，请你转头");
        }

    }

    // 进入触发器
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Grass")
        {
            // 静止两秒
            moveSpeed = 0;
            Invoke("ResetSpeed", 2);  
        }
    }
    
    // 重置速度
    private void ResetSpeed()
    {
        moveSpeed = 3;
    }


    // 提供接口设置生成敌人坦克的编号
    public void setId(int num)
    {
        id = num;
    }
}

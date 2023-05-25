using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float movespeed = 10;
    public bool isPlayerBullet;
    public AudioClip hit;

    // 玩家发射子弹的声效
    public AudioClip fire;

    public int belongEnemyId;

    // 如果敌方坦克射击到了铁墙，就停止射击
    public delegate void HitIronWall(int tankId);
    public static event HitIronWall OnHitIronwall;



    // 如果子弹射到了敌人，如果是玩家的子弹的话，会触发下面的事件，记录玩家的分数
    public delegate void GetScore(string tag);
    public static event GetScore OnGetScore;


    public static void InvokeOnGetScore(string tag)
    {
        if(OnGetScore != null)
        {
            OnGetScore.Invoke(tag);
        }
    }




    public static void InvokeOnHitIronwall(int tankId)
    {
        if(OnHitIronwall != null)
        {
            // 这将会触发相对应的事件，并将参数tankId传递给事件的委托实例
            OnHitIronwall.Invoke(tankId);
        }   
    }


    // Start is called before the first frame update
    void Start()
    {
        if (isPlayerBullet)
        {
            AudioSource.PlayClipAtPoint(fire, transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * movespeed * Time.deltaTime,Space.World);
    }


    public void setBelongId(int num)
    {
        belongEnemyId = num;
    }


    // set trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        switch(collision.tag)
        {
            // 判断是不是玩家的子弹,如果是玩家的子弹,不做处理
            case "Player1":
                if (!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Player2":
                if (!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            // 判断是否是自己的老窝,如果是自己的老窝,则触发老窝的死亡效果，无论是玩家的子弹还是敌人的子弹，都会触发老窝的死亡效果
            case "Home":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            // 判断是否是玩家的子弹,如果是玩家的子弹,则触发敌人的死亡效果
            case "Enemy":
                if (isPlayerBullet){
                    collision.SendMessage("Die");
                    OnGetScore.Invoke(gameObject.tag);
                    Destroy(gameObject);
                }
                break;
            // 如果子弹遇到墙壁,则子弹和墙壁都会消失
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            // 如果子弹遇到铁墙,则子弹会消失,子弹消失之前播放音效
            case "Barrier":
                if (!isPlayerBullet)
                {
                    InvokeOnHitIronwall(belongEnemyId);
                }
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(hit, transform.position);
                break;
            // 如果子弹遇到空气墙,则子弹会消失
            case "AirWall":
                Destroy(gameObject);
                break;
            // 如果子弹遇到敌人的子弹,则子弹和敌人的子弹都会消失
            case "EnemyBullet":
                if (isPlayerBullet){
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // 引用组件:
    // 1. 精灵渲染器，用来改变老窝的渲染
    private SpriteRenderer spriteRenderer;
    // 2. 精灵渲染器的精灵
    public Sprite brokenSprite;
    // 3. 爆炸特效
    public GameObject explosionPrefab;

    public AudioClip dieAudioClip;

    public static bool isDouble;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Die()
    {
        // 1. 改变老窝的渲染
        spriteRenderer.sprite = brokenSprite;
        // 2. 产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        // 3. 玩家血量为0
        if (!isDouble)
        {
            PlayerManager.Instance.isDefeated = true;
        }
        else
        {
            DoublePlayerManager.Instance.isDefeated = true;
        }
        

        // 4. 播放死亡音乐
        AudioSource.PlayClipAtPoint(dieAudioClip, transform.position);
        
    }
}

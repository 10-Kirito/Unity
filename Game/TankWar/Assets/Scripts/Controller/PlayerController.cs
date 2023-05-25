using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ��ҵ����ԣ�
    // 1. ����ƶ����ٶ�
    public float moveSpeed = 5;
    // 2. �����ӵ�ʱ��ĽǶ�
    private Vector3 bullectEulerAngles;
    // 3. �����ӵ���CD
    private float timeVal;
    // 4. ��ҵ�����ֵ
    // private float health = 100;
    // 5. ����Ƿ����޵�״̬
    private bool isDefended = true;
    // 6. ��ҵ��޵�ʱ��
    private float defendTimeVal = 2;
    // 7. �������ӵ���CD
    private float timeValShoot = 0.6f;


    // �������:
    // 1. ��Ҳ�ͬ�����ʱ������Ⱦ����Ⱦ������
    public Sprite[] tankSprite; // �� �� �� ��
    // 2. �ӵ�Ԥ����
    public GameObject bulletPrefab;
    // 3. ��ը��Ч
    public GameObject explosionPrefab;
    // 4. ������Ⱦ��
    private SpriteRenderer spriteRenderer;
    // 5. �޵���Ч
    public GameObject defendEffectPrefab;

    public static bool isDouble;

    // 6. ̹���ƶ�ʱ�����Ч
    public AudioSource moveAudio;
    public AudioClip[] audioClips;

    private float horizantal;
    private float vertical;


    // 7. ̹�˷����ӵ�����Ч

    // �����¼�
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


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = tankSprite[0];
    }


    // Start is called before the first frame update
    void Start()
    {
        // �����ӵ����е��˵��¼���������Լ����ӵ��Ļ������Ӧ�ķ����ͻ��һ
        OnGetScore();
    }

    // Update is called once per frame
    void Update()
    {
        // �Ƿ����޵�״̬
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


        // ����CD
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


    // 1. ����̹�˵��ƶ�
    private void Move()
    {
        horizantal = Input.GetAxis("HorizontalPlayer1");
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

        vertical = Input.GetAxis("VerticalPlayer1");
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


        /*if (Mathf.Abs(horizantal) > 0.05f)
        {
            moveAudio.clip = audioClips[1];

            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }*/
    }

    // 2. ̹�˹�������
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            temp.GetComponent<Bullet>().isPlayerBullet = true;
            timeVal = 0;
        }
    }

    // 3. ̹�˵���������
    private void Die()
    {
        // ��������޵�״̬��������
        if (isDefended)
        {
            return;
        }
        if (!isDouble)
        {
            PlayerManager.Instance.isDead = true;
        }
        else
        {
            DoublePlayerManager.Instance.isDead1 = true;
        }

        // ������ը��Ч
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        // �ݻ�̹������
        Destroy(gameObject);
    }

    // 4. ��ȡ��ǰ����ĸ�����������ý��䵯������Ϊ0
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    // }
    // 4. ����ҵ�̹���벻ͬ�Ľ�������ײ��ʱ�򣬻ᴥ����ͬ���¼�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Home":
                // ������ϼ���ײ���������
                Debug.Log("�����ϼ�");
                break;
            case "Wall":
                // �����ǽ��ײ����Ҳ�����
                Debug.Log("����ǽ");
                break;
            case "Barrier":
                // ������ϰ�����ײ����Ҳ�����
                Debug.Log("�����ϰ���");
                break;
            case "Water":
                // ����������ײ����Ҳ�����
                Debug.Log("���Ǻ���");
                break;
            default:
                break;
        }
    }

    // ���봥����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Grass")
        {
            Debug.Log("���ǲ�");
        }
    
    }
    
}

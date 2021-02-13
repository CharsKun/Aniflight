using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBullet : MonoBehaviour
{

    // Start is called before the first frame update
    public bool targetPlayer;
    public float atkSpeed;
    public bool multiple;
    public int bulletCount=3;
    public float startAngle = 120f;
    public float endAngle = 240f;
    public bool rapidFire;
    public int bulletWave = 1;
    private float waitTime;

    private float rapidTime;   
    private bool rapidOn;

    void Start()
    {
        
        atkSpeed = 10 - atkSpeed;

        if (rapidFire)
        {
            if (!multiple)
            {
                atkSpeed = 0.6f;
            }
            atkSpeed /= (bulletWave*2);
        }
        
            InvokeRepeating("Fire", 0f, atkSpeed);
        if (multiple)
        {
            bulletCount++ ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rapidTime < 0.25f && waitTime <=0f)
        {
            rapidTime += 1f * Time.deltaTime;
            rapidOn = true;
        }
        else if(rapidTime > 0.25f && waitTime<=1f)
        {
            waitTime += 1f * Time.deltaTime;
            rapidOn = false;
        }
        else
        {
            rapidTime = 0f;
            waitTime = 0f;
        }
    }
    Player target;

    private void Fire()
    {
        if (targetPlayer&&!rapidFire&&!multiple)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); //<Player>();
            Vector2 bulDir = (target.transform.position - transform.position).normalized;

            GameObject bul = BulletPool_M.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet_M>().SetMoveDirection(bulDir);
        }
        else if(!targetPlayer&& !rapidFire && multiple)
        {
            
            float angleStep1 = (endAngle - startAngle) / (bulletCount - 2);
            float angle1 = startAngle;
            
            for (int i = 0; i < bulletCount - 2 + 1; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle1 * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle1 * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool_M.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet_M>().SetMoveDirection(bulDir);

                angle1 += angleStep1;
            }
        }
        else if (!targetPlayer && rapidFire && !multiple)
        {

            if (rapidOn)
            {
                float bulDirX = transform.position.x + Mathf.Sin((Random.Range(240f - 90f, 300f - 90f) * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((Random.Range(240f - 90f, 300f - 90f) * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool_M.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet_M>().SetMoveDirection(bulDir);
            }
        }
        else if (targetPlayer && rapidFire && !multiple)
        {
            if (rapidOn)
            {
                target = GameObject.FindObjectOfType<Player>();
                Vector2 bulDir = (target.transform.position - transform.position).normalized;

                GameObject bul = BulletPool_M.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet_M>().SetMoveDirection(bulDir);
            }
        }
        else if (!targetPlayer && rapidFire && multiple)
        {

            if (rapidOn)
            {
                float angleStep1 = (endAngle - startAngle) / (bulletCount - 2);
                float angle1 = startAngle;

                for (int i = 0; i < bulletCount - 2 + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle1 * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((angle1 * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool_M.bulletPoolInstanse.GetBullet();
                    bul.transform.position = transform.position;
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet_M>().SetMoveDirection(bulDir);

                    angle1 += angleStep1;
                }
            }
        }
        else
        {
            float bulDirX = transform.position.x + Mathf.Sin((Random.Range(240f - 90f, 300f - 90f) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((Random.Range(240f - 90f, 300f - 90f) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool_M.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet_M>().SetMoveDirection(bulDir);
        }
    }
}

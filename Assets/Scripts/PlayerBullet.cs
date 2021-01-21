using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 1;

    [SerializeField]
    private float startAngle = 90f;
    private float endAngle = 270f;
    private float startTime = 10f;
    private float currentTime;
    private float timeShoot;

    private int Power = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        if(timeShoot <= 3f)
        {
            CancelInvoke();
        }
        else
        {
            InvokeRepeating("Fire", 0f, 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timeShoot += 1 * Time.deltaTime;
        if(currentTime <= 0f)
        {
            currentTime = 0f;
        }

        if(timeShoot >= 3f)
        {
            timeShoot = 3f;
        }
    }

    public void changeSpeed(float fspeed)
    {
        CancelInvoke();
        InvokeRepeating("Fire", 0f, fspeed);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;
        //SKILL BURST KNIGHT
        if (GetComponent<Player>().isRage == true && PlayerPrefs.GetInt("Character")==1)
        {
            
            if (Power == 1)
            {
                for (int i = 0; i < bulletsAmount + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 90f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                    bul.transform.localScale = new Vector3(9, 9, 9);
                    Vector2 v = new Vector2(this.GetComponent<Player>().transform.position.x - 0.3f, this.GetComponent<Player>().transform.position.y);
                    bul.transform.position = v;
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                    angle += angleStep;
                }
            }
            else if (Power == 2)
            {
                if (currentTime > 0f)
                {
                    for (int i = 0; i < bulletsAmount + 1; i++)
                    {
                        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);

                        Vector3 bulMoveVector = new Vector3(bulDirX, 0f);
                        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                        GameObject bul = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                        bul.transform.localScale = new Vector3(9, 9, 9);
                        Vector2 v = new Vector2(this.GetComponent<Player>().transform.position.x - 0.3f, this.GetComponent<Player>().transform.position.y);
                        bul.transform.position = v;
                        bul.transform.rotation = transform.rotation;
                        bul.SetActive(true);
                        bul.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                        angle += angleStep;
                    }
                }
                else if (currentTime <= 0f)
                {
                    Power = 1;
                }
            }
        }
        //SKILL BURST ARCHER
        else if (GetComponent<Player>().isRage == true && PlayerPrefs.GetInt("Character") == 2)
        {
            if (Power == 1)
            {
                for (int i = 0; i < bulletsAmount + 3; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 90f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                    bul.transform.localScale = new Vector3(4, 5, 4);
                    Vector2 v = new Vector2(this.GetComponent<Player>().transform.position.x - 0.3f, this.GetComponent<Player>().transform.position.y);
                    bul.transform.position = v;
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                    GameObject bul2 = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                    bul2.transform.localScale = new Vector3(3, 4, 3);
                    Vector2 v2 = new Vector2(this.GetComponent<Player>().transform.position.x - 0f, this.GetComponent<Player>().transform.position.y-0.4f);
                    bul2.transform.position = v2;
                    bul2.transform.rotation = transform.rotation;
                    bul2.SetActive(true);
                    bul2.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                    GameObject bul3 = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                    bul3.transform.localScale = new Vector3(3, 4, 3);
                    Vector2 v3 = new Vector2(this.GetComponent<Player>().transform.position.x - 0.6f, this.GetComponent<Player>().transform.position.y-0.4f);
                    bul3.transform.position = v3;
                    bul3.transform.rotation = transform.rotation;
                    bul3.SetActive(true);
                    bul3.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                    angle += angleStep;
                }
            }
            else if (Power == 2)
            {
                if (currentTime > 0f)
                {
                    for (int i = 0; i < bulletsAmount + 3; i++)
                    {
                        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 90f);

                        Vector3 bulMoveVector = new Vector3(bulDirX, 0f);
                        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                        GameObject bul = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                        bul.transform.localScale = new Vector3(4, 5, 4);
                        Vector2 v = new Vector2(this.GetComponent<Player>().transform.position.x - 0.3f, this.GetComponent<Player>().transform.position.y);
                        bul.transform.position = v;
                        bul.transform.rotation = transform.rotation;
                        bul.SetActive(true);
                        bul.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                        GameObject bul2 = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                        bul2.transform.localScale = new Vector3(3, 4, 3);
                        Vector2 v2 = new Vector2(this.GetComponent<Player>().transform.position.x - 0f, this.GetComponent<Player>().transform.position.y-0.3f);
                        bul2.transform.position = v2;
                        bul2.transform.rotation = transform.rotation;
                        bul2.SetActive(true);
                        bul2.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                        GameObject bul3 = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                        bul3.transform.localScale = new Vector3(3, 4, 3);
                        Vector2 v3 = new Vector2(this.GetComponent<Player>().transform.position.x - 0.6f, this.GetComponent<Player>().transform.position.y-0.3f);
                        bul3.transform.position = v3;
                        bul3.transform.rotation = transform.rotation;
                        bul3.SetActive(true);
                        bul3.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                        GameObject bul4 = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                        bul4.transform.localScale = new Vector3(3, 4, 3);
                        Vector2 v4 = new Vector2(this.GetComponent<Player>().transform.position.x - 0.1f, this.GetComponent<Player>().transform.position.y+0.5f);
                        bul4.transform.position = v4;
                        bul4.transform.rotation = transform.rotation;
                        bul4.SetActive(true);
                        bul4.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                        GameObject bul5 = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                        bul5.transform.localScale = new Vector3(3, 4, 3);
                        Vector2 v5 = new Vector2(this.GetComponent<Player>().transform.position.x - 0.5f, this.GetComponent<Player>().transform.position.y+0.5f);
                        bul5.transform.position = v5;
                        bul5.transform.rotation = transform.rotation;
                        bul5.SetActive(true);
                        bul5.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                        angle += angleStep;
                    }
                }
                else if (currentTime <= 0f)
                {
                    Power = 1;
                }
            }
        }
        //SKILL BURST MAGE
        else if (GetComponent<Player>().isRage == true && PlayerPrefs.GetInt("Character") == 3)
        {
            if (Power == 1)
            {
                /*for (int i = 0; i < bulletsAmount + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 90f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                    Vector2 v = new Vector2(this.GetComponent<Player>().transform.position.x - 0.3f, this.GetComponent<Player>().transform.position.y);
                    bul.transform.position = v;
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);

                    angle += angleStep;
                }*/

                float bulDirX = transform.position.x + Mathf.Sin((Random.Range(345f, 375f) * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((Random.Range(345f, 375f) * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);
            }
            else if (Power == 2)
            {
                //changeSpeed(0.1f);
                if (currentTime > 0f)
                {
                    for (int i = 0; i < bulletsAmount + 1; i++)
                    {
                        float bulDirX = transform.position.x + Mathf.Sin((Random.Range(345f, 375f) * Mathf.PI) / 180f);
                        float bulDirY = transform.position.y + Mathf.Cos((Random.Range(345f, 375f) * Mathf.PI) / 180f);

                        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                        GameObject bul = BulletPool_PBurst.bulletPoolInstanse.GetBullet();
                        bul.transform.position = transform.position;
                        bul.transform.rotation = transform.rotation;
                        bul.SetActive(true);
                        bul.GetComponent<Bullet_PBurst>().SetMoveDirection(bulDir);
                    }
                }
                else if (currentTime <= 0f)
                {
                    Power = 1;
                    //changeSpeed(0.03f);
                }
            }
        }
        else
        {
            if (Power == 1)
            {
                for (int i = 0; i < bulletsAmount + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 90f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool_P.bulletPoolInstanse.GetBullet();
                    Vector2 v = new Vector2(this.GetComponent<Player>().transform.position.x - 0.3f, this.GetComponent<Player>().transform.position.y);
                    bul.transform.position = v;
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet_P>().SetMoveDirection(bulDir);

                    angle += angleStep;
                }
            }
            else if (Power == 2)
            {
                if (currentTime > 0f)
                {
                    for (int i = 0; i < bulletsAmount + 1; i++)
                    {
                        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);

                        Vector3 bulMoveVector = new Vector3(bulDirX, 0f);
                        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                        GameObject bul = BulletPool_P.bulletPoolInstanse.GetBullet();
                        Vector2 v = new Vector2(this.GetComponent<Player>().transform.position.x - 0.3f, this.GetComponent<Player>().transform.position.y);
                        bul.transform.position = v;
                        bul.transform.rotation = transform.rotation;
                        bul.SetActive(true);
                        bul.GetComponent<Bullet_P>().SetMoveDirection(bulDir);

                        angle += angleStep;
                    }
                }
                else if (currentTime <= 0f)
                {
                    Power = 1;
                    changeSpeed(0.2f);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            Power = 2;
            currentTime = startTime;
            Debug.Log("Hit");
        }
    }


}

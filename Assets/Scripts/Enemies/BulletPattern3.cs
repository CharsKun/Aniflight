using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern3 : MonoBehaviour
{
    private int bulletsAmount = 6;
    private float startAngle = 140f;
    private float endAngle = 220f;
    public GameObject Boss;
    private float angle2 = 180f, angle3 = 180f;

    Player target;
    private float timeChange;
    private float timeChange2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.2f);
        InvokeRepeating("Fire2", 0f, 0.2f);
        InvokeRepeating("Fire3", 0f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        timeChange += 1 * Time.deltaTime;
        timeChange2 += 1 * Time.deltaTime;
        if (timeChange >= 10f)
        {
            timeChange = 0f;
        }
        if (timeChange2 >= 2f)
        {
            timeChange2 = 0f;
        }

    }

    private void Fire()
    {
        //if (timeChange > 5)
        //{

        if (Boss.GetComponent<MovementBoss>().Health > 100 && Boss.GetComponent<MovementBoss>().Health <=200 || Boss.GetComponent<MovementBoss>().Health > 300 && Boss.GetComponent<MovementBoss>().Health <= 400)
        {

            float bulDirX = transform.position.x + Mathf.Sin((angle2 * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle2 * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            if (timeChange2 >= 1f)
            {
                angle2 += 12f;
            }
            else
            {
                angle2 -= 12f;
            }

            float bulDirX2 = transform.position.x + Mathf.Sin((angle3 * Mathf.PI) / 180f);
            float bulDirY2 = transform.position.y + Mathf.Cos((angle3 * Mathf.PI) / 180f);

            Vector3 bulMoveVector2 = new Vector3(bulDirX2, bulDirY2, 0f);
            Vector2 bulDir2 = (bulMoveVector2 - transform.position).normalized;

            GameObject bul2 = BulletPool.bulletPoolInstanse.GetBullet();
            bul2.transform.position = transform.position;
            bul2.transform.rotation = transform.rotation;
            bul2.SetActive(true);
            bul2.GetComponent<Bullet>().SetMoveDirection(bulDir2);

            if (timeChange2 >= 1f)
            {
                angle3 -= 12f;
            }
            else
            {
                angle3 += 12f;
            }
        }
        //}

    }

    /*private void Fire2()
    {
        if (Boss.GetComponent<MovementBoss>().Health <= Boss.GetComponent<MovementBoss>().maxHealth/4)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle2 * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle2 * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            angle2 += 20f;
        }
    }*/

    private void Fire2()
    {
        if (Boss.GetComponent<MovementBoss>().Health > 200 && Boss.GetComponent<MovementBoss>().Health <= 300)
        {
            Vector3 bulVec = new Vector3(0f, -8f, 0f);
            target = GameObject.FindObjectOfType<Player>();

            Vector2 bulDir2 = (target.transform.position - transform.position).normalized;

            GameObject bul2 = BulletPool.bulletPoolInstanse.GetBullet();
            bul2.transform.position = new Vector2(transform.position.x - 2f, transform.position.y);
            bul2.transform.rotation = transform.rotation;
            bul2.SetActive(true);
            bul2.GetComponent<Bullet>().SetMoveDirection(bulDir2);

            Vector2 bulDir3 = (target.transform.position - transform.position).normalized;

            GameObject bul3 = BulletPool.bulletPoolInstanse.GetBullet();
            bul3.transform.position = new Vector2(transform.position.x+2f,transform.position.y);
            bul3.transform.rotation = transform.rotation;
            bul3.SetActive(true);
            bul3.GetComponent<Bullet>().SetMoveDirection(bulDir3);
        }
    }

    private void Fire3()
    {
        float angleStep = (endAngle - startAngle) / 6;
        float angle = startAngle;

        if (Boss.GetComponent<MovementBoss>().Health > 0 && Boss.GetComponent<MovementBoss>().Health <= 100 || Boss.GetComponent<MovementBoss>().Health > 400 && Boss.GetComponent<MovementBoss>().Health <= 500)
        {
            if(timeChange >= 5f)
            {
                for (int i = 0; i < 6 + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                    bul.transform.position = transform.position;
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                    angle += angleStep;
                }
            }
            else
            {
                float angleStep1 = (endAngle - startAngle) / 4;
                float angle1 = startAngle;

                for (int i = 0; i < 5; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle1 * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((angle1 * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                    bul.transform.position = transform.position;
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                    angle1 += angleStep1;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern5_2nd : MonoBehaviour
{

    private float startAngle = 140f;
    private float endAngle = 220f;

    private float angle2 = 0f, angle3 = 90f, angle4 = 180f, angle5 = 270f;
    private float ang = 0f, ang2 = 0f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireSpam", 0f, 5f);
        InvokeRepeating("Fire1", 0f, 1.2f);
        InvokeRepeating("Fire2", 0f, 0.05f);
        InvokeRepeating("Fire3", 0f, 0.2f);
        InvokeRepeating("Fire4", 0f, 0.05f);
        InvokeRepeating("Fire5", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;

        if (time >= 10f) time = 0f;
    }

    private void FireSpam()
    {
        float angleStep = (endAngle - startAngle) / 1;
        float angle = 180;

        if (this.GetComponent<MovementBoss>().Health > 0 && this.GetComponent<MovementBoss>().Health <= 800)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool2.bulletPoolInstanse.GetBullet();
            bul.transform.position = new Vector2(Random.Range(-3f, 3f), 1.5f);
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet2>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }

    private void Fire1()
    {
        if(this.GetComponent<MovementBoss>().Health <= 800 && this.GetComponent<MovementBoss>().Health > 500)
        {
            if (time <= 5f)
            {
                float angleStep = (endAngle - 40 - startAngle + 40) / 6;
                float angle = startAngle + 40;
                float angleStep1 = (endAngle - 40 - startAngle + 40) / 6;
                float angle1 = startAngle - 40;

                for (int i = 0; i < 6 + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                    bul.transform.position = new Vector2(transform.position.x + 2f, transform.position.y - 2f);
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                    angle += angleStep;
                }

                for (int i = 0; i < 6 + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle1 * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((angle1 * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                    bul.transform.position = new Vector2(transform.position.x - 2f, transform.position.y - 2f);
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                    angle1 += angleStep1;
                }
            }
            else
            {
                float angleStep = (endAngle - startAngle) / 2;
                float angle = startAngle;
                float angleStep1 = (endAngle - startAngle) / 2;
                float angle1 = startAngle;

                for (int i = 0; i < 2 + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                    bul.transform.position = new Vector2(transform.position.x + 2f, transform.position.y - 2f);
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                    angle += angleStep;
                }

                for (int i = 0; i < 2 + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle1 * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((angle1 * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                    bul.transform.position = new Vector2(transform.position.x - 2f, transform.position.y - 2f);
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                    angle1 += angleStep1;
                }
            }
        }
    }

    private void Fire2()
    {
        if(this.GetComponent<MovementBoss>().Health <= 500 && this.GetComponent<MovementBoss>().Health > 250)
        {
            if(time < 4f)
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

                float bulDirX2 = transform.position.x + Mathf.Sin((angle3 * Mathf.PI) / 180f);
                float bulDirY2 = transform.position.y + Mathf.Cos((angle3 * Mathf.PI) / 180f);

                Vector3 bulMoveVector2 = new Vector3(bulDirX2, bulDirY2, 0f);
                Vector2 bulDir2 = (bulMoveVector2 - transform.position).normalized;

                GameObject bul2 = BulletPool.bulletPoolInstanse.GetBullet();
                bul2.transform.position = transform.position;
                bul2.transform.rotation = transform.rotation;
                bul2.SetActive(true);
                bul2.GetComponent<Bullet>().SetMoveDirection(bulDir2);

                angle3 += 20f;

                float bulDirX3 = transform.position.x + Mathf.Sin((angle4 * Mathf.PI) / 180f);
                float bulDirY3 = transform.position.y + Mathf.Cos((angle4 * Mathf.PI) / 180f);

                Vector3 bulMoveVector3 = new Vector3(bulDirX3, bulDirY3, 0f);
                Vector2 bulDir3 = (bulMoveVector3 - transform.position).normalized;

                GameObject bul3 = BulletPool.bulletPoolInstanse.GetBullet();
                bul3.transform.position = transform.position;
                bul3.transform.rotation = transform.rotation;
                bul3.SetActive(true);
                bul3.GetComponent<Bullet>().SetMoveDirection(bulDir3);

                angle4 += 20f;

                float bulDirX4 = transform.position.x + Mathf.Sin((angle5 * Mathf.PI) / 180f);
                float bulDirY4 = transform.position.y + Mathf.Cos((angle5 * Mathf.PI) / 180f);

                Vector3 bulMoveVector4 = new Vector3(bulDirX4, bulDirY4, 0f);
                Vector2 bulDir4 = (bulMoveVector4 - transform.position).normalized;

                GameObject bul4 = BulletPool.bulletPoolInstanse.GetBullet();
                bul4.transform.position = transform.position;
                bul4.transform.rotation = transform.rotation;
                bul4.SetActive(true);
                bul4.GetComponent<Bullet>().SetMoveDirection(bulDir4);

                angle5 += 20f;
            }
        }
    }

    private void Fire3()
    {
        if (this.GetComponent<MovementBoss>().Health <= 500 && this.GetComponent<MovementBoss>().Health > 250)
        {
            if (time >= 4f && time <= 7.5f)
            {
                float bulDirX = transform.position.x + Mathf.Sin((Random.Range(240f - 90f, 300f - 90f) * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((Random.Range(240f - 90f, 300f - 90f) * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            }
            else if (time > 7.5f)
            {
                float angleStep = (endAngle - startAngle) / 4;
                float angle = startAngle;

                for (int i = 0; i < 4 + 1; i++)
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
        }
    }

    private void Fire4()
    {
        if(this.GetComponent<MovementBoss>().Health <= 250 && this.GetComponent<MovementBoss>().Health > 0)
        {
            if (time <= 5f)
            {
                float bulDirX = transform.position.x + Mathf.Sin((ang * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((ang * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                ang += 20f;
            }

            if (time <= 5f)
            {
                float bulDirX = transform.position.x + Mathf.Sin((ang2 * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((ang2 * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                ang2 -= 20f;
            }
        }
    }

    private void Fire5()
    {
        if(this.GetComponent<MovementBoss>().Health <= 250 && this.GetComponent<MovementBoss>().Health > 0)
        {
            if (time > 5f)
            {
                float angleStep = (endAngle - 40 - startAngle + 40) / 4;
                float angle = startAngle + 40;
                float angleStep1 = (endAngle - 40 - startAngle + 40) / 4;
                float angle1 = startAngle - 40;

                for (int i = 0; i < 4 + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                    bul.transform.position = new Vector2(transform.position.x + 2f, transform.position.y - 2f);
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                    angle += angleStep;
                }

                for (int i = 0; i < 4 + 1; i++)
                {
                    float bulDirX = transform.position.x + Mathf.Sin((angle1 * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((angle1 * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                    bul.transform.position = new Vector2(transform.position.x - 2f, transform.position.y - 2f);
                    bul.transform.rotation = transform.rotation;
                    bul.SetActive(true);
                    bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                    angle1 += angleStep1;
                }

            }
        }
    }
}

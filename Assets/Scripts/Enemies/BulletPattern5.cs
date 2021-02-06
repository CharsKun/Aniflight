using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern5 : MonoBehaviour
{
    // Start is called before the first frame update
    private float startAngle = 120f;
    private float endAngle = 240f;

    private float angle2 = 0f;
    private float angle3 = 0f;
    private float angle4 = 0f;

    private float time1;
    void Start()
    {
        InvokeRepeating("Fire",0f, 0.1f);
        InvokeRepeating("Fire2", 0f, 0.02f);
        InvokeRepeating("Fire3", 0f, 1f);
        InvokeRepeating("Fire4", 0f, 0.05f);
        InvokeRepeating("Fire5", 0f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        time1 += 1 * Time.deltaTime;

        if (time1 >= 10f) time1 = 0f;
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / 6;
        float angle = startAngle;

        if (this.GetComponent<MovementBoss>().Health <= 600 && this.GetComponent<MovementBoss>().Health > 400)
        {
            if(time1 <= 5f)
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
        }
    }

    private void Fire2()
    {
        if(this.GetComponent<MovementBoss>().Health <= 400 && this.GetComponent<MovementBoss>().Health > 200)
        {
            if(time1 <= 5f)
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
        }
    }

    private void Fire3()
    {
        if (this.GetComponent<MovementBoss>().Health <= 400 && this.GetComponent<MovementBoss>().Health > 200)
        {
            if(time1 > 5f)
            {
                float angleStep = (endAngle-40 - startAngle+40) / 5;
                float angle = startAngle+40;
                float angleStep1 = (endAngle-40 - startAngle+40) / 5;
                float angle1 = startAngle-40;

                for (int i = 0; i < 5 + 1; i++)
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

                for (int i = 0; i < 5 + 1; i++)
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

    private void Fire4()
    {
        if(this.GetComponent<MovementBoss>().Health <= 200 && this.GetComponent<MovementBoss>().Health > 0)
        {
            if(time1 <= 5f)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle3 * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle3 * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                angle3 += 10f;
            }

            if(time1 <= 5f)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle4 * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle4 * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                angle4 -= 10f;
            }
        }
    }

    private void Fire5()
    {
        if (this.GetComponent<MovementBoss>().Health <= 200 && this.GetComponent<MovementBoss>().Health > 0)
        {
            if(time1 > 5f)
            {
                float bulDirX = transform.position.x + Mathf.Sin((Random.Range(240f - 90f, 300f - 90f) * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((Random.Range(240f - 90f, 300f - 90f) * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                bul.transform.position = new Vector2(transform.position.x + 2f, transform.position.y - 2f);
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                float bulDirX2 = transform.position.x + Mathf.Sin((Random.Range(240f - 90f, 300f - 90f) * Mathf.PI) / 180f);
                float bulDirY2 = transform.position.y + Mathf.Cos((Random.Range(240f - 90f, 300f - 90f) * Mathf.PI) / 180f);

                Vector3 bulMoveVector2 = new Vector3(bulDirX2, bulDirY2, 0f);
                Vector2 bulDir2 = (bulMoveVector2 - transform.position).normalized;

                GameObject bul2 = BulletPool.bulletPoolInstanse.GetBullet();
                bul2.transform.position = new Vector2(transform.position.x - 2f, transform.position.y - 2f);
                bul2.transform.rotation = transform.rotation;
                bul2.SetActive(true);
                bul2.GetComponent<Bullet>().SetMoveDirection(bulDir2);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern2 : MonoBehaviour
{
    private int bulletsAmount = 6;
    private float startAngle = 160f;
    private float endAngle = 200f;
    public GameObject Boss;
    private float angle2 = 150f;

    Player target;
    private float timeChange;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.05f);
        InvokeRepeating("Fire2", 0f, 0.2f);
        InvokeRepeating("Fire3", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timeChange += 1 * Time.deltaTime;

        if (timeChange >= 2f)
        {
            timeChange = 0f;
        }
    }

    private void Fire()
    {
        //if (timeChange > 5)
        //{

            if (Boss.GetComponent<MovementBoss>().Health <= Boss.GetComponent<MovementBoss>().maxHealth / 2 && Boss.GetComponent<MovementBoss>().Health > Boss.GetComponent<MovementBoss>().maxHealth / 4)
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
        if (Boss.GetComponent<MovementBoss>().Health <= Boss.GetComponent<MovementBoss>().maxHealth / 4)
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

    private void Fire3()
    {
        float angleStep = (endAngle - startAngle) / 2;
        float angle = startAngle;
        float angleStep1 = (endAngle - startAngle) / 2;
        float angle1 = startAngle;

        if (Boss.GetComponent<MovementBoss>().Health > Boss.GetComponent<MovementBoss>().maxHealth / 2)
        {
            for (int i = 0; i < 2 + 1; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                bul.transform.position = new Vector2(transform.position.x+2f, transform.position.y-2f);
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
                bul.transform.position = new Vector2(transform.position.x-2f, transform.position.y-2f);
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                angle1 += angleStep1;
            }
        }
    }
}

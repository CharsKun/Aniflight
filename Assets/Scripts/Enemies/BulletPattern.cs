using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern : MonoBehaviour
{
    private int bulletsAmount = 6;
    private float startAngle = 120f;
    private float endAngle = 240f;
    public GameObject Boss;
    private float angle2 = 0f;

    Player target;
    private float timeChange;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.5f);
        InvokeRepeating("Fire2", 0f, 0.1f);
        InvokeRepeating("Fire3", 0f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        timeChange += 1 * Time.deltaTime;

        if(timeChange >= 10)
        {
            timeChange = 0;
        }
    }

    private void Fire()
    {
        if (timeChange > 5)
        {
            float angleStep = (endAngle - startAngle) / bulletsAmount;
            float angle = startAngle;

            if (Boss.GetComponent<MovementBoss>().Health <= Boss.GetComponent<MovementBoss>().maxHealth / 2 && Boss.GetComponent<MovementBoss>().Health > Boss.GetComponent<MovementBoss>().maxHealth / 4)
            {

                for (int i = 0; i < bulletsAmount + 1; i++)
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
        }else if(timeChange <= 5)
        {
            float angleStep1 = (endAngle - startAngle) / (bulletsAmount - 2);
            float angle1 = startAngle;

            if (Boss.GetComponent<MovementBoss>().Health <= Boss.GetComponent<MovementBoss>().maxHealth / 2 && Boss.GetComponent<MovementBoss>().Health > Boss.GetComponent<MovementBoss>().maxHealth / 4)
            {

                for (int i = 0; i < bulletsAmount-2 + 1; i++)
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
            float bulDirX = transform.position.x + Mathf.Sin((Random.Range(240f-90f, 300f-90f) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((Random.Range(240f-90f, 300f-90f) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        }
    }

    private void Fire3()
    {
        if (Boss.GetComponent<MovementBoss>().Health > Boss.GetComponent<MovementBoss>().maxHealth / 2)
        {
            target = GameObject.FindObjectOfType<Player>();
            Vector2 bulDir = (target.transform.position - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern4 : MonoBehaviour
{
    private int bulletsAmount = 6;
    private float startAngle = 140f;
    private float endAngle = 220f;
    public GameObject Boss;
    private float angle2 = 0f, angle3 = 120f, angle4 = 240f;

    private float a1 = 0f, a2 = 10f, a3 = 20f, a4 = 120f, a5 = 130f, a6 = 140f, a7 = 240f, a8 = 250f, a9 = 260f;
    Player target;
    private float timeChange;
    private float timeChange2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.2f);
        InvokeRepeating("Fire2", 0f, 0.2f);
        InvokeRepeating("Fire3", 0f, 0.1f);
        InvokeRepeating("Fire4", 0f, 1.75f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Fire()
    {
        //if (timeChange > 5)
        //{

        if (Boss.GetComponent<MovementBoss>().Health > 100 && Boss.GetComponent<MovementBoss>().Health <= 200 || Boss.GetComponent<MovementBoss>().Health > 300 && Boss.GetComponent<MovementBoss>().Health <= 400)
        {
            float bulDirX = transform.position.x + Mathf.Sin((a1 * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((a1 * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            a1 += 30f;

            float bulDirX2 = transform.position.x + Mathf.Sin((a2 * Mathf.PI) / 180f);
            float bulDirY2 = transform.position.y + Mathf.Cos((a2 * Mathf.PI) / 180f);

            Vector3 bulMoveVector2 = new Vector3(bulDirX2, bulDirY2, 0f);
            Vector2 bulDir2 = (bulMoveVector2 - transform.position).normalized;

            GameObject bul2 = BulletPool.bulletPoolInstanse.GetBullet();
            bul2.transform.position = transform.position;
            bul2.transform.rotation = transform.rotation;
            bul2.SetActive(true);
            bul2.GetComponent<Bullet>().SetMoveDirection(bulDir2);

            a2 += 30f;

            float bulDirX3 = transform.position.x + Mathf.Sin((a3 * Mathf.PI) / 180f);
            float bulDirY3 = transform.position.y + Mathf.Cos((a3 * Mathf.PI) / 180f);

            Vector3 bulMoveVector3 = new Vector3(bulDirX3, bulDirY3, 0f);
            Vector2 bulDir3 = (bulMoveVector3 - transform.position).normalized;

            GameObject bul3 = BulletPool.bulletPoolInstanse.GetBullet();
            bul3.transform.position = transform.position;
            bul3.transform.rotation = transform.rotation;
            bul3.SetActive(true);
            bul3.GetComponent<Bullet>().SetMoveDirection(bulDir3);

            a3 += 30f;

            float bulDirX4 = transform.position.x + Mathf.Sin((a4 * Mathf.PI) / 180f);
            float bulDirY4 = transform.position.y + Mathf.Cos((a4 * Mathf.PI) / 180f);

            Vector3 bulMoveVector4 = new Vector3(bulDirX4, bulDirY4, 0f);
            Vector2 bulDir4 = (bulMoveVector4 - transform.position).normalized;

            GameObject bul4 = BulletPool.bulletPoolInstanse.GetBullet();
            bul4.transform.position = transform.position;
            bul4.transform.rotation = transform.rotation;
            bul4.SetActive(true);
            bul4.GetComponent<Bullet>().SetMoveDirection(bulDir4);

            a4 += 30f;

            float bulDirX5 = transform.position.x + Mathf.Sin((a5 * Mathf.PI) / 180f);
            float bulDirY5 = transform.position.y + Mathf.Cos((a5 * Mathf.PI) / 180f);

            Vector3 bulMoveVector5 = new Vector3(bulDirX5, bulDirY5, 0f);
            Vector2 bulDir5 = (bulMoveVector5 - transform.position).normalized;

            GameObject bul5 = BulletPool.bulletPoolInstanse.GetBullet();
            bul5.transform.position = transform.position;
            bul5.transform.rotation = transform.rotation;
            bul5.SetActive(true);
            bul5.GetComponent<Bullet>().SetMoveDirection(bulDir5);

            a5 += 30f;

            float bulDirX6 = transform.position.x + Mathf.Sin((a6 * Mathf.PI) / 180f);
            float bulDirY6 = transform.position.y + Mathf.Cos((a6 * Mathf.PI) / 180f);

            Vector3 bulMoveVector6 = new Vector3(bulDirX6, bulDirY6, 0f);
            Vector2 bulDir6 = (bulMoveVector6 - transform.position).normalized;

            GameObject bul6 = BulletPool.bulletPoolInstanse.GetBullet();
            bul6.transform.position = transform.position;
            bul6.transform.rotation = transform.rotation;
            bul6.SetActive(true);
            bul6.GetComponent<Bullet>().SetMoveDirection(bulDir6);

            a6 += 30f;

            float bulDirX7 = transform.position.x + Mathf.Sin((a7 * Mathf.PI) / 180f);
            float bulDirY7 = transform.position.y + Mathf.Cos((a7 * Mathf.PI) / 180f);

            Vector3 bulMoveVector7 = new Vector3(bulDirX7, bulDirY7, 0f);
            Vector2 bulDir7 = (bulMoveVector7- transform.position).normalized;

            GameObject bul7 = BulletPool.bulletPoolInstanse.GetBullet();
            bul7.transform.position = transform.position;
            bul7.transform.rotation = transform.rotation;
            bul7.SetActive(true);
            bul7.GetComponent<Bullet>().SetMoveDirection(bulDir7);

            a7 += 30f;

            float bulDirX8 = transform.position.x + Mathf.Sin((a8 * Mathf.PI) / 180f);
            float bulDirY8 = transform.position.y + Mathf.Cos((a8 * Mathf.PI) / 180f);

            Vector3 bulMoveVector8 = new Vector3(bulDirX8, bulDirY8, 0f);
            Vector2 bulDir8 = (bulMoveVector8 - transform.position).normalized;

            GameObject bul8 = BulletPool.bulletPoolInstanse.GetBullet();
            bul8.transform.position = transform.position;
            bul8.transform.rotation = transform.rotation;
            bul8.SetActive(true);
            bul8.GetComponent<Bullet>().SetMoveDirection(bulDir8);

            a8 += 30f;

            float bulDirX9 = transform.position.x + Mathf.Sin((a9 * Mathf.PI) / 180f);
            float bulDirY9 = transform.position.y + Mathf.Cos((a9 * Mathf.PI) / 180f);

            Vector3 bulMoveVector9 = new Vector3(bulDirX9, bulDirY9, 0f);
            Vector2 bulDir9 = (bulMoveVector2 - transform.position).normalized;

            GameObject bul9 = BulletPool.bulletPoolInstanse.GetBullet();
            bul9.transform.position = transform.position;
            bul9.transform.rotation = transform.rotation;
            bul9.SetActive(true);
            bul9.GetComponent<Bullet>().SetMoveDirection(bulDir9);

            a9 += 30f;
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
    private void Fire4()
    {
        float angleStep = (endAngle - startAngle) / 1;
        float angle = 180;

        if (Boss.GetComponent<MovementBoss>().Health > 0 && Boss.GetComponent<MovementBoss>().Health <= 300)
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
    private void Fire2()
    {

        if (Boss.GetComponent<MovementBoss>().Health > 200 && Boss.GetComponent<MovementBoss>().Health <= 300)
        {
            Vector3 bulVec = new Vector3(0f, -8f, 0f);
            target = GameObject.FindObjectOfType<Player>();

            Vector2 bulDir2 = (target.transform.position - transform.position).normalized;

            GameObject bul2 = BulletPool.bulletPoolInstanse.GetBullet();
            bul2.transform.position = transform.position;
            bul2.transform.rotation = transform.rotation;
            bul2.SetActive(true);
            bul2.GetComponent<Bullet>().SetMoveDirection(bulDir2);

            

        }
    }

    private void Fire3()
    {

        if (Boss.GetComponent<MovementBoss>().Health > 0 && Boss.GetComponent<MovementBoss>().Health <= 100 || Boss.GetComponent<MovementBoss>().Health > 400 && Boss.GetComponent<MovementBoss>().Health <= 500)
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
            float bulDirY2 = transform.position.y + Mathf.Cos((angle3* Mathf.PI) / 180f);

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
        }
    }
}

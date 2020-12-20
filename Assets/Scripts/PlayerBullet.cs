﻿using System.Collections;
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

    private int Power = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("Fire", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if(currentTime <= 0f)
        {
            currentTime = 0f;
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

       if(Power == 1)
        {
            for (int i = 0; i < bulletsAmount + 1; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 90f);

                Vector3 bulMoveVector = new Vector3(bulDirX, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool_P.bulletPoolInstanse.GetBullet();
                Vector2 v = new Vector2(this.GetComponent<Player>().transform.position.x -0.3f, this.GetComponent<Player>().transform.position.y);
                bul.transform.position = v;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet_P>().SetMoveDirection(bulDir);

                angle += angleStep;
            }
        }else if(Power == 2)
        {
            if(currentTime > 0f)
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
            }else if(currentTime <= 0f)
            {
                Power = 1;
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

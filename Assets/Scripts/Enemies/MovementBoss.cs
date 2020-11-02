﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoss : MonoBehaviour
{
    private float moveSpeed;
    private bool moveRight;

    public int maxHealth = 200;
    public int Health;
    public HealthBar_Boss healthBar;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        moveRight = true;
        Health = maxHealth;
        healthBar.Setmaxhealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x > 3f)
        {
            moveRight = false;
        }else if(transform.position.x < -3f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletPlayer")
        {
            Health--;
            healthBar.setHealth(Health);
            //Debug.Log("Health : "+ Health);
        }
    }
}
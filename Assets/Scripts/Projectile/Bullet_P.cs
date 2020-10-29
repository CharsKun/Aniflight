﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_P : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;

    private void OnEnable()
    {
        Invoke("Destroy", 1.7f);
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 9f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss1" || collision.tag == "Minion")
        {
            gameObject.SetActive(false);
        }
    }
}
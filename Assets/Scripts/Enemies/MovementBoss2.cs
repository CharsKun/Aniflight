using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoss2 : MonoBehaviour
{
    private float moveSpeed;
    private bool moveRight, moveTop;
    private Renderer rend;
    private float redTime = 0f;
    public GameObject explodeBoss;
    //redTime = waktu berapa lama warna dioverlay merah

    public int maxHealth = 500;
    public int Health;
    public HealthBar_Boss healthBar;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        moveRight = true;
        moveTop = true;
        Health = maxHealth;
        healthBar.Setmaxhealth(maxHealth);
        rend = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        redTime -= 1 * Time.deltaTime;
        if (redTime <= 0f)
        {
            redTime = 0f;
            rend.material.color = Color.white;
        }

        if (Health <= 0)
        {
            Instantiate(explodeBoss, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        if(Health > 200 && Health <= 300)
        {
            if (transform.position.x > 3f)
            {
                moveTop = false;
            }
            else if (transform.position.y > -13f)
            {
                moveRight = false;
            }else if (transform.position.x < -3f) 
            {
                moveTop = true;
            }else if (transform.position.y > -1.5f)
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            }
            else if(!moveRight)
            {
                transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            }else if (moveTop)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            }
            else if (!moveTop)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            }
        }
        else
        {

            if (transform.position.x > 3f)
            {
                moveRight = false;
            }
            else if (transform.position.x < -3f)
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletPlayer")
        {
            Health--;
            rend.material.color = Color.red;
            redTime = 0.05f;
            healthBar.setHealth(Health);
            //Debug.Log("Health : "+ Health);
        }
    }
}

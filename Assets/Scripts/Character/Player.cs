using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector2 moveD;

    public GameObject BulletP;
    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;
    public Player player;
    public int maxMana = 100;
    public int currentMana;

    private bool formTimeOut = false;
    private Animator anim;

    private int state;
    /*
    STATE
    1 normal
    2 burst form
    3 burst ultimate
    */

    public float currentTime = 0f;
    public float startTime = 5f;

    void InputProses()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveD = new Vector2(moveX, moveY);
    }

    void Move()
    {

        rb.velocity = new Vector2(moveD.x * speed, moveD.y * speed);

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.Setmaxhealth(maxHealth);
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        InputProses();
        if (state == 1)
        {
            if (Input.GetButtonDown("Form") && currentMana >= 100)
            {
                state = 2;
                anim.SetBool("Burst",true);
            }
        } else if (state == 2)
        {
            if (Input.GetButtonDown("Form") || formTimeOut == true)
            {
                state = 3;
                //anim.SetBool("Burst", true);
            }
        } else if (state == 3)
        {
            ultimate();
            state = 1;
            anim.SetBool("Burst", false);
        }
        BulletP.GetComponent<Bullet_P>().currentTime = currentTime;
        //changeForm();
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
        }

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y != 0f)
        {
            Move();
        }


    }

    /*private void changeForm()
    {
        Debug.Log("Form Actived");
        if (Input.GetButtonDown("Form"))
        {
            currentTime = startTime;
        }

        BulletP.GetComponent<Bullet_P>().currentTime = currentTime;

        if (currentTime > 0f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Form;
            if(isRage == false)
            {
                this.GetComponent<PlayerBullet>().changeSpeed(0.1f);
                isRage = true;
            }
        }
        else if(currentTime <= 0f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = backForm;
            if(isRage == true)
            {
                this.GetComponent<PlayerBullet>().changeSpeed(0.2f);
                isRage = false;
            }
        }
        print(currentTime);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BossBullet")
        {
            currentHealth--;
            healthBar.setHealth(currentHealth);
            Debug.Log("Health : " + currentHealth);
        }
    }

    private void ultimate()
    {
        moveD = new Vector2(0,-11);
    }


}

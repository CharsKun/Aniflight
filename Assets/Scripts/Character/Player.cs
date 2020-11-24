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
    public float currentMana;
    public HealthBar healthBar;
    public ManaBar manaBar;

    private bool isRage = true;
    public Sprite backForm;
    public Sprite Form;
    Animator anim;

    public float currentTime = 0f;
    public float startTime = 7f;
    public float currentUltiTime = 0f;
    public float UltiTime = 1f;
    

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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputProses();
        changeForm();
        currentTime -= 1 * Time.deltaTime;
        currentUltiTime -= 1 * Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
        }

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        if(currentMana <=20)
        {
            currentMana += 1 * Time.deltaTime;

            manaBar.setMana(currentMana);
        }
    }

    void FixedUpdate()
    {
        if(transform.position.y != 0f)
        {
            Move();
        }


    }

    private void changeForm()
    {
        
        if (Input.GetButtonDown("Form")&&isRage==false && currentMana>=20)
        {
            Debug.Log("Form Actived");
            currentTime = startTime;
            currentMana = 0;
        }

        BulletP.GetComponent<Bullet_P>().currentTime = currentTime;

        if (currentTime > 0f)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = Form;
            if(isRage == false)
            {
                this.GetComponent<PlayerBullet>().changeSpeed(0.1f);
               // BulletP.GetComponent<SpriteRenderer>().color = new Color(0, 0, 244);
                isRage = true;
            }
        }
        else if(currentTime <= 0f)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = backForm;
            if(isRage == true)
            {
                this.GetComponent<PlayerBullet>().changeSpeed(0.2f);
                //BulletP.GetComponent<SpriteRenderer>().color = new Color(254, 244, 0);

                isRage = false;
            }
        }

        if(isRage == false)
        {
            anim.SetBool("isRage", false);
        }
        else
        {
            anim.SetBool("isRage", true);
        }

        //Ulti
        if(Input.GetButtonDown("Form") && isRage == true && anim.GetBool("isUlti")==false && currentTime > 0f && currentTime <3f)
        {

            Debug.Log("Ulti");

            
            currentUltiTime = 2f;
        }

        if (currentUltiTime > 0f)
        {
            anim.SetBool("isUlti", true);
        }
        else if(anim.GetBool("isUlti")==true && currentUltiTime <=0f)
        {
            anim.SetBool("isUlti", false);
            currentTime = 0f;
            
        }

        //Debug.Log(currentTime);
    }

    private void ultimate()
    {
        

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BossBullet")
        {
            currentHealth--;
            healthBar.setHealth(currentHealth);
            Debug.Log("Health : "+ currentHealth);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUpMana"))
        {
            currentMana = 20f;
        }

        if (collision.gameObject.CompareTag("PowerUpHealth"))
        {
            currentHealth ++;
            healthBar.setHealth(currentHealth);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector2 moveD;

    public GameObject BulletP;
    private bool isHit;
    private bool isShield;
    public int maxHealth = 5;
    public int currentHealth;
    public float currentMana;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public ParticleSystem ManaFull;

    private float timeTakeDamage;
    private bool canTakeDamage;

    private bool isRage = true;
    // public Sprite backForm;
    // public Sprite Form;
    Animator anim;
    public Animator ShakeEffect;
    public GameObject Defeat;
    public GameObject Victory;

    private float shieldTime;
    private float currentTime = 0f;
    private float startTime = 7f;
    //public float currentUltiTime = 0f;
    //private float UltiTime = 1f;
    

    void InputProses()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveD = new Vector2(moveX, moveY);
    }
    private void Awake()
    {
        ManaFull = Instantiate(ManaFull);
        ManaFull.transform.position = new Vector2(4f, -15.55f);
    }
    void Move()
    {
   
        rb.velocity = new Vector2(moveD.x * speed, moveD.y * speed);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Defeat.SetActive(false);
        currentHealth = maxHealth;
        healthBar.Setmaxhealth(maxHealth);
        anim = GetComponent<Animator>();
        ManaFull.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        isHit = false;
        InputProses();
        changeForm();
        //EffectParticle();

        timeTakeDamage += 1 * Time.deltaTime;
        currentTime -= 1 * Time.deltaTime;

        if(shieldTime >= 0f)
        {
            shieldTime -= 1 * Time.deltaTime;
        }

        if (currentTime <= 0f)
        {
            currentTime = 0f;
        }

        if(timeTakeDamage >= 1.5f)
        {
            canTakeDamage = true;
            timeTakeDamage = 1.5f;
        }
        else
        {
            canTakeDamage = false;
        }

        if (shieldTime <= 0f)
        {
            GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
            isShield = true;
        }

        if(currentHealth <= 0)
        {
            ManaFull.Clear();
            ManaFull.Pause();
            Victory.SetActive(false);
            Destroy(this.gameObject);
            Defeat.SetActive(true);
            Destroy(healthBar.gameObject);
            Destroy(manaBar.gameObject);
            
        }

        if(currentHealth > 5)
        {
            currentHealth = 5;
        }

        if(currentMana <=20)
        {
            currentMana += 1 * Time.deltaTime;

            manaBar.setMana(currentMana);
        }

        if (currentMana >= 20f)
        {
            ManaFull.Play();
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
            //Debug.Log("Form Actived");
            currentTime = startTime;
            currentMana = 0;
            ManaFull.Pause();
            ManaFull.Clear();
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
        /*if(Input.GetButtonDown("Form") && isRage == true && anim.GetBool("isUlti")==false && currentTime > 0f && currentTime <3f)
        {

            Debug.Log("Ulti");

            
            currentUltiTime = 2f;
        }*/

        /*if (currentUltiTime > 0f)
        {
            anim.SetBool("isUlti", true);
        }
        else if(anim.GetBool("isUlti")==true && currentUltiTime <=0f)
        {
            anim.SetBool("isUlti", false);
            currentTime = 0f;
            
        }*/

        //Debug.Log(currentTime);
    }

    private void ultimate()
    {
        

    }

    private void EffectParticle()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BossBullet")
        {
            if (canTakeDamage && isShield)
            {
                ShakeEffect.SetTrigger("shake");
                currentHealth--;
                healthBar.setHealth(currentHealth);
                timeTakeDamage = 0f;
            }
        }

        if(collision.tag == "EnemyBullet" && !isHit)
        {
            
            isHit = true;
            if (canTakeDamage && isShield)
            {
                ShakeEffect.SetTrigger("shake");
                currentHealth--;
                healthBar.setHealth(currentHealth);
                timeTakeDamage = 0f;
            }
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

        if (collision.gameObject.CompareTag("PowerUpShield"))
        {
            shieldTime = 5;
            isShield = false;
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
        }
    }
}

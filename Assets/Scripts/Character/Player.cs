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
    public GameObject SkillBtn;

    private float timeTakeDamage;
    private bool canTakeDamage;
    private bool isSkill;

    public bool isRage = true;
    // public Sprite backForm;
    // public Sprite Form;
    Animator anim;

    public Animator ShakeEffect;
    public GameObject Defeat;
    public GameObject Victory;
    public GameObject stage;
    public GameObject PauseButton;
    public GameObject SoundManager;

    private float shieldTime;
    private float currentTime = 0f;
    private float startTime = 7f;
    //public float currentUltiTime = 0f;
    //private float UltiTime = 1f;

    private float timeBeforeStart = 0f;


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
        timeTakeDamage = 1.5f;
        Defeat.SetActive(false);
        currentHealth = maxHealth;
        healthBar.Setmaxhealth(maxHealth);
        anim = GetComponent<Animator>();
        ManaFull.Pause();

        if(PlayerPrefs.GetInt("Character") == 1)
        {
            anim.SetInteger("Character", 1);
        }else if(PlayerPrefs.GetInt("Character") == 2)
        {
            anim.SetInteger("Character", 2);
        }else if(PlayerPrefs.GetInt("Character") == 3)
        {
            anim.SetInteger("Character", 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //SetActiveStageContoller (Mulai Spawn Minion)
        timeBeforeStart += Time.deltaTime;
        if (timeBeforeStart>=3)
        {
            stage.SetActive(true);
        }


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
            if(isShield == true)
            {
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
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

        if(currentHealth <= 0 && !Victory.activeInHierarchy)
        {
            ManaFull.Clear();
            ManaFull.Pause();
            Destroy(this.gameObject);
            Defeat.SetActive(true);
            Victory.SetActive(false);
            PauseButton.SetActive(false);
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
            isSkill = false;
        }

        if (currentMana >= 20f)
        {
            SkillBtn.SetActive(true);
            ManaFull.Play();
        }

        if(canTakeDamage == false)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f);
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
        
        if (Input.GetButtonDown("Form") && isRage==false && currentMana>=20 || isSkill && isRage == false && currentMana >= 20)
        {
            currentTime = startTime;
            currentMana = 0;
            ManaFull.Pause();
            ManaFull.Clear();
            SoundManager.GetComponent<SoundManager>().manaFull();
        }

        BulletP.GetComponent<Bullet_P>().currentTime = currentTime;

        if (currentTime > 0f)
        {
            if(isRage == false)
            {
                if (PlayerPrefs.GetInt("Character") == 1)
                {
                    this.GetComponent<PlayerBullet>().changeSpeed(0.1f);
                }
                else if (PlayerPrefs.GetInt("Character") == 2)
                {
                    this.GetComponent<PlayerBullet>().changeSpeed(0.8f);
                }
                else
                {
                    this.GetComponent<PlayerBullet>().changeSpeed(0.05f);
                }
                isRage = true;
            }
        }
        else if(currentTime <= 0f)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = backForm;
            if(isRage == true )
            {
                if (PlayerPrefs.GetInt("Character") == 1)
                {
                    this.GetComponent<PlayerBullet>().changeSpeed(0.2f);
                }else if(PlayerPrefs.GetInt("Character") == 2)
                {
                    this.GetComponent<PlayerBullet>().changeSpeed(0.2f);
                }
                else
                {
                    this.GetComponent<PlayerBullet>().changeSpeed(0.2f);
                }
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
            SoundManager.GetComponent<SoundManager>().powerUp();
        }

        if (collision.gameObject.CompareTag("PowerUpHealth"))
        {
            currentHealth ++;
            healthBar.setHealth(currentHealth);
            SoundManager.GetComponent<SoundManager>().powerUp();
        }

        if (collision.gameObject.CompareTag("PowerUpShield"))
        {
            shieldTime = 5;
            isShield = false;
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
            SoundManager.GetComponent<SoundManager>().powerUp();
        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
            SoundManager.GetComponent<SoundManager>().powerUp();
        }
    }

    public void SkillButton()
    {
        isSkill = true;
        SkillBtn.SetActive(false);
    }
}

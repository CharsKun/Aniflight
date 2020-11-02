using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector2 moveD;

    public GameObject BulletP;

    public Sprite backForm;
    public Sprite Form;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        InputProses();
        changeForm();
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
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
        Debug.Log("Form Actived");
        if (Input.GetButtonDown("Form"))
        {
            currentTime = startTime;
        }

        BulletP.GetComponent<Bullet_P>().currentTime = currentTime;

        if (currentTime > 0f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Form;
            GetComponent<PlayerBullet>().fireSpeed = 0.1f;
        }
        else if(currentTime <= 0f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = backForm;
            GetComponent<PlayerBullet>().fireSpeed = 0.2f;
        }
        print(currentTime);
    }

}

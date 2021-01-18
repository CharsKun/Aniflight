using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_PBurst : MonoBehaviour
{
    private Vector2 moveDirection;
    public float moveSpeed;
    public GameObject Player;

    public Sprite Projectile1;
    public Sprite Projectile2;
    public Sprite Projectile3;
    //public bool validation;

    public float currentTime;
    
    private void OnEnable()
    {
        Invoke("Destroy", 1.7f);
    }

    // Start is called before the first frame update
    void Start()
    {
        int chooseCharacter = PlayerPrefs.GetInt("Character");
        if (chooseCharacter == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Projectile1;
        }
        else if (chooseCharacter == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Projectile2;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Projectile3;
        }
        // validation = true;
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
            //Player.GetComponent<Player>().currentMana++;
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private int Health = 5;
    private int RandomVariable;

    public GameObject PowerUp;
    private GameObject puspawn;
    public GameObject PowerUpMana;
    private GameObject puspawn2;

    public Sprite Minion1;
    public Sprite Minion2;
    public Sprite Minion3;

    public GameObject ManagerGame;
    // Start is called before the first frame update
    void Start()
    {
        Change();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f,speed*-1.0f);
   }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.y < -15.5f || Health <= 0)
        {
            if (Health <= 0)
            {
                if(transform.position.y <= -5.5f)
                {
                    RandomVariable = Random.Range(0, 10);
                    if (RandomVariable == 4)
                    {
                        puspawn = Instantiate(PowerUp);
                        puspawn.transform.position = transform.position;
                        puspawn.transform.rotation = transform.rotation;
                        puspawn.SetActive(true);
                    }
                    else if (RandomVariable == 6)
                    {
                        puspawn2 = Instantiate(PowerUpMana);
                        puspawn2.transform.position = transform.position;
                        puspawn2.transform.rotation = transform.rotation;
                        puspawn2.SetActive(true);
                    }
                }
                ManagerGame.GetComponent<Manager>().count++;
            }
            Destroy(this.gameObject);
            

        }
    }

    void Change()
    {
        if(ManagerGame.GetComponent<Manager>().randomMinion == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Minion1;
        }
        else if (ManagerGame.GetComponent<Manager>().randomMinion == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Minion2;
        }
        else if (ManagerGame.GetComponent<Manager>().randomMinion == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Minion3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletPlayer")
        {
            Health--;
            //Debug.Log("Health : "+ Health);
        }
    }
}

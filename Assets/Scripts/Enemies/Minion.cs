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

    public GameObject ManagerGame;
    // Start is called before the first frame update
    void Start()
    {
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
                RandomVariable = Random.Range(0, 10);
                if(RandomVariable == 4)
                {
                    puspawn = Instantiate(PowerUp);
                    puspawn.transform.position = transform.position;
                    puspawn.transform.rotation = transform.rotation;
                    puspawn.SetActive(true);
                }
                ManagerGame.GetComponent<Manager>().count++;
            }
            Destroy(this.gameObject);
            

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

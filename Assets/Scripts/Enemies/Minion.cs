using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private int Health = 5;

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
            if(Health <= 0) ManagerGame.GetComponent<Manager>().count++;
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

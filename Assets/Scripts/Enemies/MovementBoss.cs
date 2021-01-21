using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoss : MonoBehaviour
{
    private Renderer rend;
    private float redTime=0f;
    public GameObject explodeBoss;
    //redTime = waktu berapa lama warna dioverlay merah

    public int maxHealth = 400;
    public int Health;
    public HealthBar_Boss healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Health = maxHealth;
        healthBar.Setmaxhealth(maxHealth);
        rend = this.GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        redTime -= 1*Time.deltaTime;
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
        else if(collision.tag == "BulletPlayerBurst")
        {
            Health -= 2;
            rend.material.color = Color.red;
            redTime = 0.05f;
            healthBar.setHealth(Health);
        }
    }
}

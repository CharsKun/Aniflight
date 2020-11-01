using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-5f * 25f, 3f * 25f));
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
        if (transform.position.y >= -4)
        {
            Debug.Log("Hit");
            rb.AddForce(new Vector2(-2f * 15f, -10f * 15f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Collider") && this.transform.position.y == transform.position.y -3.6) 
        //{
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);
        //}

        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        
    }
}

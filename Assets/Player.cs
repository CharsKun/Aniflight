using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector2 moveD;

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
        if(transform.position.y == 0)
        {
            Debug.Log("Trigger");
        }
    }

    void FixedUpdate()
    {
        if(transform.position.y != 0f)
        {
            Move();
        }
    }

   
}

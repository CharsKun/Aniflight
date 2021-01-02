using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{   
    public float moveSpeed = 3f;

    public int pathIndex;
    private int pathPointIndex;

    public float spawnTime;

    //public float speed = 3f;
    private Rigidbody2D rb;
    public int Health = 5;
    private int RandomVariable;

    public GameObject explode;
    private Renderer rend;
    private float redTime = 0f;
    //redTime = waktu berapa lama warna dioverlay merah

    public GameObject PowerUp;
    private GameObject puspawn;
    public GameObject PowerUpMana;
    private GameObject puspawn2;
    public GameObject PowerUpHealth;
    private GameObject puspawn3;
    public GameObject PowerUpShield;
    private GameObject puspawn4;

    //public GameObject ManagerGame;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.timeSinceLevelLoad;
        rend = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        redTime -= 1 * Time.deltaTime;
        if (redTime <= 0f)
        {
            redTime = 0f;
            rend.material.color = Color.white;
        }

        if (Health <= 0)
        {
            if (transform.position.y <= -5.5f)
            {
                RandomVariable = Random.Range(0, 10);
                if (RandomVariable == 2)
                {
                    puspawn = Instantiate(PowerUp);
                    puspawn.transform.position = transform.position;
                    puspawn.transform.rotation = transform.rotation;
                    puspawn.SetActive(true);
                }
                else if (RandomVariable == 4)
                {
                    puspawn2 = Instantiate(PowerUpMana);
                    puspawn2.transform.position = transform.position;
                    puspawn2.transform.rotation = transform.rotation;
                    puspawn2.SetActive(true);
                }
                else if (RandomVariable == 6)
                {
                    puspawn3 = Instantiate(PowerUpHealth);
                    puspawn3.transform.position = transform.position;
                    puspawn3.transform.rotation = transform.rotation;
                    puspawn3.SetActive(true);
                }else if(RandomVariable == 8)
                {
                    puspawn4 = Instantiate(PowerUpShield);
                    puspawn4.transform.position = transform.position;
                    puspawn4.transform.rotation = transform.rotation;
                    puspawn.SetActive(true);
                }
            }
            //ManagerGame.GetComponent<Manager>().count++;
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }



        var path = StageController.current.GetPath(pathIndex);
        if (path == null)
        {
            return;
        }
        var target = path[pathPointIndex];
        var delta = target - (Vector2)transform.position;
      
        transform.position = Vector2.MoveTowards(transform.position,target, moveSpeed*Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            pathPointIndex++;
        }

        if (pathPointIndex >= path.Count)
            {
                Destroy(this.gameObject);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletPlayer")
        {
            Health--;
            //Debug.Log("Health : "+ Health);
            rend.material.color = Color.red;
            redTime = 0.05f;
        }
    }
}



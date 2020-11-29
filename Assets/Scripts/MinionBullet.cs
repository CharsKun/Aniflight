using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBullet : MonoBehaviour
{
    
    // Start is called before the first frame update
   // Minion minion;
    void Start()
    {
        //if (!minion.enabled)
        // {
            InvokeRepeating("Fire", 0f, 3f);
            
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
    Player target;

    private void Fire()
    {
        //for (int i = 0; i < bulletsAmount + 1; i++)
        //{
            target = GameObject.FindObjectOfType<Player>();
            Vector2 bulDir = (target.transform.position - transform.position).normalized;

            GameObject bul = BulletPool_M.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet_M>().SetMoveDirection(bulDir);
        //}
    }
}

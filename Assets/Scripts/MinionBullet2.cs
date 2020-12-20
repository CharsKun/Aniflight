using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBullet2 : MonoBehaviour
{

    // Start is called before the first frame update
    // Minion minion;
    private float startAngle = 140f;
    private float endAngle = 220f;
    void Start()
    {
        //if (!minion.enabled)
        // {
        InvokeRepeating("Fire", 0f, 1.5f);

        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
    Player target;

    private void Fire()
    {
        float angleStep1 = (endAngle - startAngle) / 2;
        float angle1 = startAngle;

        //if (Boss.GetComponent<MovementBoss>().Health <= Boss.GetComponent<MovementBoss>().maxHealth / 2 && Boss.GetComponent<MovementBoss>().Health > Boss.GetComponent<MovementBoss>().maxHealth / 4)
        //{

            for (int i = 0; i < 2 + 1; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle1 * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle1 * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool_M.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet_M2>().SetMoveDirection(bulDir);

                angle1 += angleStep1;
            }
        //}
    }
}

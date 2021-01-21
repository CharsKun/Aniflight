using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSelectionBG : MonoBehaviour
{
    public float awal = 22.9f;
    public float akhir = -15f;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        if(transform.position.x <= akhir)
        {
            transform.position = new Vector2(awal, transform.position.y);
        }

    }
}

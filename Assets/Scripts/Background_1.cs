using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translation: Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -39.465f)
        {
            transform.position = startPos;
        }
    }
}

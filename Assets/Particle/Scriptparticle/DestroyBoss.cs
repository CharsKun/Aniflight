using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoss : MonoBehaviour
{
    private float destroy;
    // Update is called once per frame
    void Update()
    {
        destroy += 1 * Time.deltaTime;
        
        if(destroy >= 4f)
        {
            Destroy(this.gameObject);
        }
    }
}

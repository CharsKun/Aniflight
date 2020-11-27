using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float destroy;

    // Update is called once per frame
    void Update()
    {
        destroy += 1 * Time.deltaTime;

        if(destroy >= 0.4f)
        {
            Destroy(this.gameObject);
        }
    }
}

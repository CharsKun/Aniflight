using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWarning : MonoBehaviour
{
    public GameObject SoundManager;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager = GameObject.FindGameObjectWithTag("SM");
        SoundManager.GetComponent<SoundManager>().bossWarning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

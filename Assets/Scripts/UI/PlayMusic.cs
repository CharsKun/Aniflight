﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GameObject.FindGameObjectWithTag("BGM").GetComponent<VolumeChange>().playMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

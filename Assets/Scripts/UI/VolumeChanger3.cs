using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger3 : MonoBehaviour
{
    private AudioSource sumbersuara;

    private float volume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        sumbersuara = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sumbersuara.volume = PlayerPrefs.GetFloat("VolumeMusik");
    }


    public void setVolume(float vol)
    {
        PlayerPrefs.SetFloat("VolumeMusik", vol);
    }
}

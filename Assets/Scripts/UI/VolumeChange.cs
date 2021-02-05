using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    private AudioSource sumbersuara;

    private float volume = 1f;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        sumbersuara = GetComponent<AudioSource>();
    }


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

    public void playMusic()
    {
        if (sumbersuara.isPlaying)
        {
            return;
        }
        else
        {
            sumbersuara.Play();
        }
    }

    public void stopMusic()
    {
        sumbersuara.Stop();
    }

}

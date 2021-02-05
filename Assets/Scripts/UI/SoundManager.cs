using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioSource sumberSuara;
    static AudioClip kelik;
    static AudioClip pause;
    static AudioClip manafull;
    static AudioClip powerup;

    // Start is called before the first frame update
    void Start()
    {
        kelik = Resources.Load<AudioClip>("ButtonClicked");
        pause = Resources.Load<AudioClip>("Paused");
        manafull = Resources.Load<AudioClip>("ManaFull");
        powerup = Resources.Load<AudioClip>("PowerUp");
        sumberSuara = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tombolKlik()
    {
        //Debug.Log("suara");
        sumberSuara.PlayOneShot(kelik);
    }

    public void paused()
    {
        sumberSuara.PlayOneShot(pause);
    }

    public void manaFull()
    {
        sumberSuara.PlayOneShot(manafull);
    }

    public void powerUp()
    {
        sumberSuara.PlayOneShot(powerup);
    }

}

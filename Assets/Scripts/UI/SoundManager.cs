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
    static AudioClip hitted;
    static AudioClip spawned;
    static AudioClip bosswarning;

    // Start is called before the first frame update
    void Start()
    {
        kelik = Resources.Load<AudioClip>("ButtonClicked");
        pause = Resources.Load<AudioClip>("Paused");
        manafull = Resources.Load<AudioClip>("ManaFull");
        powerup = Resources.Load<AudioClip>("PowerUp");
        hitted = Resources.Load<AudioClip>("Hitted");
        spawned = Resources.Load<AudioClip>("Spawned");
        bosswarning = Resources.Load<AudioClip>("BossWarning");
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

    public void Hitted()
    {
        sumberSuara.PlayOneShot(hitted);
    }

    public void Spawned()
    {
        sumberSuara.PlayOneShot(spawned);
    }

    public void bossWarning()
    {
        sumberSuara.PlayOneShot(bosswarning);
    }

}

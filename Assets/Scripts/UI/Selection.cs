using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour
{
    public GameObject SoundManager;

    bool mulai = false;
   
    private float delay;

    private int sken = 0;

    private void Start()
    {
        delay = 0;
    }

    private void Update()
    {
        if (mulai == true)
        {
            delay += Time.deltaTime;
        }

        if (delay >= 0.3f && sken == 1)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (delay >= 0.3f && sken == 2)
        {
            SceneManager.LoadScene("StageSelection");
        }
    }

    public void Knight()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        PlayerPrefs.SetInt("Character", 1);
        mulai = true;
        sken = 2;
    }

    public void Archer()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        PlayerPrefs.SetInt("Character", 2);
        mulai = true;
        sken = 2;
    }

    public void Mage()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        PlayerPrefs.SetInt("Character", 3);
        mulai = true;
        sken = 2;
    }

    public void Back()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        mulai = true;
        sken = 1;
    }
}

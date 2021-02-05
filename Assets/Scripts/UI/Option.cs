using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public GameObject slider;
    public GameObject slider2;
    public GameObject SoundManager;
    // Start is called before the first frame update
    void Start()
    {
        slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("VolumeMusik");
        slider2.GetComponent<Slider>().value = PlayerPrefs.GetFloat("VolumeSuara");
    }

    // Update is called once per frame
    void Update()
    {
        slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("VolumeMusik");
        slider2.GetComponent<Slider>().value = PlayerPrefs.GetFloat("VolumeSuara");
    }

    public void resetOption()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        PlayerPrefs.SetFloat("VolumeMusik", 0.266f);
        PlayerPrefs.SetFloat("VolumeSuara", 0.8f);
    }


}

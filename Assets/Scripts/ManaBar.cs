using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject SoundManager;

    private bool played = false;

    void Start()
    {
        slider.maxValue = 20;
    }

    private void Update()
    {
        /*if(slider.value >= slider.maxValue && played ==false)
        {
            SoundManager.GetComponent<SoundManager>().manaFull();
            played = true;
        }

        if(slider.value < slider.maxValue && played == true)
        {
            played = false;
        }*/
    }

    public void setMana(float mana)
    {
        slider.value = mana;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

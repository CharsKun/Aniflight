using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        slider.maxValue = 20;
    }
    public void setMana(float mana)
    {
        slider.value = mana;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

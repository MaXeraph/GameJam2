using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private float current;
    public void setMaxHealth(float health)
    {
        //TY BRACKEYS
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(float health)
    {
        current = health;
    }

    void Update()
    {
        //Easing the health bar value
        if (current != slider.value)
        {
            slider.value = Mathf.MoveTowards(slider.value, current, 1);
        }

    }
}

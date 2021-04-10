using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBarScript : MonoBehaviour
{
    public Slider slider;

    public void setMaxShield(int health) {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setShield(int health) {
        slider.value = health;
    }
}

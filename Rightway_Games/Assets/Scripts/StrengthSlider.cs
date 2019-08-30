using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthSlider : MonoBehaviour
{
    Slider slider;
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        slider = GetComponent<Slider>();
        slider.maxValue = player.GetStrength();
        slider.value = slider.maxValue;

        player.onTakenDamage += UpdateSlider;
    }

    private void UpdateSlider(float damage)
    {
        slider.value += damage;
    }
}

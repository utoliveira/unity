using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider slider;

    [SerializeField]
    private Gradient gradient;

    public Image fill;
    // Start is called before the first frame update
    void Awake()
    {
        slider = this.GetComponent<Slider>();
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHelth(int health)
    {
        slider.maxValue = health;
        SetHealth(health);
        fill.color = gradient.Evaluate(1f);
    }
}

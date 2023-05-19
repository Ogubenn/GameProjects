using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;//renklerde yumuşak geçiş için gradient kullandık
    public Image fill;

    public void SetMaxHealt(int healt)
    {
        slider.maxValue = healt;
        slider.value = healt;

        fill.color = gradient.Evaluate(1f);//Animasyonların değerini hesaplamak ve değiştirmek için kullanılan ifadedir.Evaulate
        //gradientin belirlitilen zaman noktasındaki renk değerini output verir.
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}//class

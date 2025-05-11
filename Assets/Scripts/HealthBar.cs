using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI hpInt;

    public void SetMaxHp(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
        hpInt.text = hp.ToString();
    }

    public void SetHp(int hp)
    {
        slider.value = hp;
        hpInt.text = hp.ToString();
    }
}

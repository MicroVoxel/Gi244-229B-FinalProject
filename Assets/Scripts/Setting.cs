using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public TMP_Dropdown graphicDropdown;
    public Slider volume;
    public AudioMixer audioMixer;

    void Start()
    {
        audioMixer.SetFloat("master", volume.value);
    }

    void Update()
    {
        
    }

    public void ChangeVolume()
    {
        audioMixer.SetFloat("master", volume.value);
    }

    public void ChangeQuality()
    {
        QualitySettings.SetQualityLevel(graphicDropdown.value);
    }
}

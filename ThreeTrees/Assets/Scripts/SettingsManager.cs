using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [SerializeField] Slider sliderVolume;
    [SerializeField] Slider sliderPitch;

    [SerializeField] AudioSource sud;
    
    void Start()
    {
        sliderVolume.value = sud.volume;
        sliderPitch.value = sud.pitch * 0.5f;
    }

    void Update()
    {
        sud.volume = sliderVolume.value;
        sud.pitch = sliderPitch.value * 2;
    }
}

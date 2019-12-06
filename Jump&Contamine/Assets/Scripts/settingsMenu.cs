using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour
{

    public Slider slider;
    public AudioMixer audioMixer;

    private void Start()
    {
        slider.onValueChanged.AddListener(delegate { setVolume(); });
    }

    public void setVolume()
    {
        audioMixer.SetFloat("volume", Mathf.Log10(slider.value) * 20 );
    }

}

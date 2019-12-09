using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void stopMusic()
    {
        audioMixer.SetFloat("volume",  -80 );
    }

    public void playMusic()
    {
        audioMixer.SetFloat("volume",  10 );
    }

}

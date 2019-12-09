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
        audioMixer.SetFloat("music", -80);
    }

    public void playMusic()
    {
        audioMixer.SetFloat("music", 0);
    }

    public void stopSounds()
    {
        audioMixer.SetFloat("sounds", -80);
    }

    public void playSounds()
    {
        audioMixer.SetFloat("sounds", 0);
    }

}

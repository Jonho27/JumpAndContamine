using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public static AudioClip cambio;
    public static AudioSource audioSource;


    public Image fr0;
    public Image fr1;
    public Image fr2;
    public Image fr3;
    public Image fr4;
    public Image fr5;
    public Image fr6;
    public int number, aux;
    private float timer;
    


    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        number = Random.Range(0,7);
        aux = number;
        cambio = Resources.Load<AudioClip>("cambio");

        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        activar();
        
        if (timer >= 5){
            
            //number = Random.Range(0,7);
            while(number == aux){
                number = Random.Range(0,7);}

            Debug.Log(number);
            timer = 0f;
            aux = number;
            audioSource.PlayOneShot(cambio);
            activar();}

        
    }

    public void activar()
    {

        switch (number)
        {
            case 0:
                fr0.GetComponent<Image>().enabled = true;
                fr1.GetComponent<Image>().enabled = false;
                fr2.GetComponent<Image>().enabled = false;
                fr3.GetComponent<Image>().enabled = false;
                fr4.GetComponent<Image>().enabled = false;
                fr5.GetComponent<Image>().enabled = false;
                fr6.GetComponent<Image>().enabled = false;
                break;
            case 1:
                fr1.GetComponent<Image>().enabled = true;

                fr0.GetComponent<Image>().enabled = false;
                fr2.GetComponent<Image>().enabled = false;
                fr3.GetComponent<Image>().enabled = false;
                fr4.GetComponent<Image>().enabled = false;
                fr5.GetComponent<Image>().enabled = false;
                fr6.GetComponent<Image>().enabled = false;
                break;
            case 2:
                fr2.GetComponent<Image>().enabled = true;                
                
                fr1.GetComponent<Image>().enabled = false;
                fr0.GetComponent<Image>().enabled = false;
                fr3.GetComponent<Image>().enabled = false;
                fr4.GetComponent<Image>().enabled = false;
                fr5.GetComponent<Image>().enabled = false;
                fr6.GetComponent<Image>().enabled = false;
                break;
            case 3:
                fr3.GetComponent<Image>().enabled = true;

                fr1.GetComponent<Image>().enabled = false;
                fr2.GetComponent<Image>().enabled = false;
                fr0.GetComponent<Image>().enabled = false;
                fr4.GetComponent<Image>().enabled = false;
                fr5.GetComponent<Image>().enabled = false;
                fr6.GetComponent<Image>().enabled = false;
                break;
            case 4:
                fr4.GetComponent<Image>().enabled = true;
                fr1.GetComponent<Image>().enabled = false;
                fr2.GetComponent<Image>().enabled = false;
                fr3.GetComponent<Image>().enabled = false;
                fr0.GetComponent<Image>().enabled = false;
                fr5.GetComponent<Image>().enabled = false;
                fr6.GetComponent<Image>().enabled = false;
                break;
            case 5:
                fr5.GetComponent<Image>().enabled = true;
                
                fr1.GetComponent<Image>().enabled = false;
                fr2.GetComponent<Image>().enabled = false;
                fr3.GetComponent<Image>().enabled = false;
                fr4.GetComponent<Image>().enabled = false;
                fr0.GetComponent<Image>().enabled = false;
                fr6.GetComponent<Image>().enabled = false;
                break;
            case 6:
                fr6.GetComponent<Image>().enabled = true;
                fr1.GetComponent<Image>().enabled = false;
                fr2.GetComponent<Image>().enabled = false;
                fr3.GetComponent<Image>().enabled = false;
                fr4.GetComponent<Image>().enabled = false;
                fr5.GetComponent<Image>().enabled = false;
                fr0.GetComponent<Image>().enabled = false;
                break;

        }

    }

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

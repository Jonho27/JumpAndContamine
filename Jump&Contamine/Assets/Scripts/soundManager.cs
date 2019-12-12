using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip boton, impulso, elevacion, propulsion, salto, muerte, positivo, globo, negativo, btnTutorial, cambio;
    public static AudioSource audioSource;
    void Start()
    {
        boton = Resources.Load<AudioClip>("boton");
        btnTutorial = Resources.Load<AudioClip>("btnTutorial");
        impulso = Resources.Load<AudioClip>("impulso");
        elevacion = Resources.Load<AudioClip>("elevacion");
        propulsion = Resources.Load<AudioClip>("propulsion");
        salto = Resources.Load<AudioClip>("salto");
        muerte = Resources.Load<AudioClip>("muerte");
        positivo = Resources.Load<AudioClip>("positivo");
        globo = Resources.Load<AudioClip>("globo");
        negativo = Resources.Load<AudioClip>("negativo");
        cambio = Resources.Load<AudioClip>("cambio");

        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySonido()
    {
        audioSource.PlayOneShot(boton);

    }

    public void PlayTutorial()
    {
        audioSource.PlayOneShot(btnTutorial);

    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "boton":
                audioSource.PlayOneShot(boton);
                break;
            case "cambio":
                audioSource.PlayOneShot(cambio);
                break;
            case "impulso":
                audioSource.PlayOneShot(impulso);
                break;
            case "elevacion":
                audioSource.PlayOneShot(elevacion);
                break;
            case "propulsion":
                audioSource.PlayOneShot(propulsion);
                break;
            case "salto":
                audioSource.PlayOneShot(salto);
                break;
            case "muerte":
                audioSource.PlayOneShot(muerte);
                break;
            case "positivo":
                audioSource.PlayOneShot(positivo);
                break;
            case "globo":
                audioSource.PlayOneShot(globo);
                break;
            case "negativo":
                audioSource.PlayOneShot(negativo);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigScreen : MonoBehaviour
{

    public GameObject[] botonesOpcionesMusica;
    public GameObject[] botonesOpcionesEfectos;

    public AudioSource audioSource;

    private bool musica, efectos;
    public static bool efectosCompartir;

    private void Start()
    {
        musica = true;
        efectos = true;
        efectosCompartir = efectos;
    }

    public void ApagarMusica()
    {
        if (musica)
        {
            botonesOpcionesMusica[0].SetActive(true);
            botonesOpcionesMusica[1].SetActive(false);
            musica = false;
            audioSource.volume = 0;
        }
        else
        {
            botonesOpcionesMusica[1].SetActive(true);
            botonesOpcionesMusica[0].SetActive(false);
            musica = true;
            audioSource.volume = 1;
        }
    }

    public void ApagarSonidos()
    {
        if (efectos)
        {
            botonesOpcionesEfectos[0].SetActive(true);
            botonesOpcionesEfectos[1].SetActive(false);
            efectos = false;
            PlayerPrefs.SetInt("Sounds", 1);
        }
        else
        {
            botonesOpcionesEfectos[1].SetActive(true);
            botonesOpcionesEfectos[0].SetActive(false);
            efectos = true;
            PlayerPrefs.SetInt("Sounds", 0);
        }
        efectosCompartir = efectos;

    }

}

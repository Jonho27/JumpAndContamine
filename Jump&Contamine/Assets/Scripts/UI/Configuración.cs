using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuración : MonoBehaviour
{

    public GameObject[] botonesOpcionesMusica;
    public GameObject[] botonesOpcionesEfectos;

    public AudioSource audioSource;
    public GameObject audioManager;

    private bool musica, efectos;

    private void Start()
    {
        musica = true;
        efectos = true;
    }

    public void ApagarMusica()
    {
        if (musica)
        {
            botonesOpcionesMusica[1].SetActive(true);
            botonesOpcionesMusica[0].SetActive(false);
            musica = false;
            audioSource.volume = 0;
        }
        else
        {
            botonesOpcionesMusica[0].SetActive(true);
            botonesOpcionesMusica[1].SetActive(false);
            musica = true;
            audioSource.volume = 1;
        }
    }

    public void ApagarSonidos()
    {
        if (efectos)
        {
            botonesOpcionesEfectos[1].SetActive(true);
            botonesOpcionesEfectos[0].SetActive(false);
            efectos = false;
            PlayerPrefs.SetInt("Sounds", 1);
        }
        else
        {
            botonesOpcionesEfectos[0].SetActive(true);
            botonesOpcionesEfectos[1].SetActive(false);
            efectos = true;
            PlayerPrefs.SetInt("Sounds", 0);
        }

    }
   
}

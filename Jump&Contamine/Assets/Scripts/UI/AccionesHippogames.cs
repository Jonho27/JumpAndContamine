using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionesHippogames : MonoBehaviour
{

    public GameObject[] acciones1;
    public GameObject[] acciones2;


    public void Siguiente()
    {
        for(int i = 0; i < acciones1.Length; i++)
        {
            acciones1[i].SetActive(false);
        }
        for (int i = 0; i < acciones2.Length; i++)
        {
            acciones2[i].SetActive(true);
        }
    }

    public void Reiniciar()
    {
        for (int i = 0; i < acciones1.Length; i++)
        {
            acciones1[i].SetActive(true);
        }
        for (int i = 0; i < acciones2.Length; i++)
        {
            acciones2[i].SetActive(false);
        }
    }


    public void AbrirTwitter()
    {
        Application.OpenURL("https://twitter.com/hippogamesstu");
    }

    public void Abririnstagram()
    {
        Application.OpenURL("https://www.instagram.com/hippogamesstudio/");
    }
}

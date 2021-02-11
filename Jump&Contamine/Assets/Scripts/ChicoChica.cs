using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicoChica : MonoBehaviour
{
    public static int seleccion;
    public GameObject chico, chica;

    public void Start()
    {
        if(seleccion == 0)
        {
            chico.SetActive(true);
            chica.SetActive(false);
        }
        else
        {
            chico.SetActive(false);
            chica.SetActive(true);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public Button botonSiguiente;
    public GameObject[] imagenesTutoriales;
    public GameObject text1, text2, TutorialGM;
    public Text text;

    private int step;
    private string[] frasesTutorial = new string[]{

        "Las plataformas naranjas contaminan mucho! Pero te impulsarán hacia arriba.",
        "Las platafromas verdes ayudan al planeta. Cuidado que algunas contaminan.",
        "Si la tormenta te pilla, puedes escapar con el jetpack. " +
        "El salvavidas te ayudara si caes al vacio.",
        "La contaminacioón te persigue. Tu decides si contaminar y que acelere.",
            };

    // Start is called before the first frame update
    void Start()
    {
        step = 0;
        
    }

    public void siguiente()
    {
        if (step < frasesTutorial.Length)
        {
            text.text = frasesTutorial[step];
        }
        else
        {
            text.transform.gameObject.SetActive(false);
        }

        if (step == 0)
        {
            imagenesTutoriales[step].SetActive(true);
            text1.SetActive(false);
            text2.SetActive(false);
        }
        else if(step < imagenesTutoriales.Length)
        {
            imagenesTutoriales[step].SetActive(true);
            imagenesTutoriales[step-1].SetActive(false);
        }

        if(step == 4)
        {
            botonSiguiente.GetComponentInChildren<Text>().text = "SALIR";
        }

        if (step == 5)
        {
            TutorialGM.SetActive(false);
        }
        step++;
    }

}

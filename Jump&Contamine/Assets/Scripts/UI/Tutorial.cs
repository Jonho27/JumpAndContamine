using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public Button botonSiguiente, botonSalir;
    public GameObject[] imagenesTutoriales;
    public GameObject text1, text2, TutorialGM;
    public Text text;

    private int step;
    private string[] frasesTutorial = new string[]{

        "Las plataformas naranjas contaminan mucho! Pero te impulsarán hacia arriba.",
        "Las plataformas verdes ayudan al planeta. Cuidado que algunas contaminan.",
        "Si la tormenta te pilla, puedes escapar con el jetpack. " +
        "El salvavidas te ayudara si caes al vacio.",
        "La contaminacioón te persigue. Tu decides si contaminar y que acelere.",
            };

    // Start is called before the first frame update
    void Start()
    {
        step = 0;
        
    }

    public void reiniciarTutorial()
    {
        imagenesTutoriales[imagenesTutoriales.Length-1].SetActive(false);
        step = 0;
        text.text = "CON ESTE VIDEOJUEGO PRETENDEMOS CONCIENCIAR SOBRE EL CÁMBIO CLIMÁTICO. ";
        text1.SetActive(true);
        text2.SetActive(true);
        text.gameObject.SetActive(true);
        botonSiguiente.gameObject.SetActive(true);
        botonSalir.gameObject.SetActive(false);
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
            botonSiguiente.gameObject.SetActive(false);
            botonSalir.gameObject.SetActive(true);

        }
        step++;
    }

}

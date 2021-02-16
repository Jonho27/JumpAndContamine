using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transiciones : MonoBehaviour
{
    public GameObject Configuración, Tutorial, Personajes, Acciones;

    private float timer, limitTimer;
    private bool desactivarConfig, desactivarTutorial, desactivarPersonajes, descativarAcciones;
    public GameObject background;
    public Button botonChico, botonChica;

    private void Start()
    {
        timer = 0f;
        limitTimer = 1f;
        desactivarConfig = false;
        desactivarTutorial = false;
        desactivarPersonajes = false;
        descativarAcciones = false;
    }

    private void Update()
    {
        if (desactivarConfig)
        {
            timer += Time.deltaTime;
            if(timer > limitTimer)
            {
                Configuración.SetActive(false);
                desactivarConfig = false;
                timer = 0;
                background.SetActive(false);
            }
        }

        if(desactivarTutorial)
        {
            timer += Time.deltaTime;
            if (timer > limitTimer)
            {
                Tutorial.SetActive(false);
                desactivarTutorial = false;
                timer = 0;
                background.SetActive(false);
            }
        }

        if (desactivarPersonajes)
        {
            timer += Time.deltaTime;
            if (timer > limitTimer)
            {
                Personajes.SetActive(false);
                desactivarPersonajes = false;
                timer = 0;
                background.SetActive(false);
            }
        }

        if (descativarAcciones)
        {
            timer += Time.deltaTime;
            if (timer > limitTimer)
            {
                Acciones.SetActive(false);
                descativarAcciones = false;
                timer = 0;
                background.SetActive(false);
            }
        }
    }

    public void ActivarConfiguracion()
    {
        Configuración.SetActive(true);
        background.SetActive(true);
    }
    public void DesactivarConfiguracion()
    {
        desactivarConfig = true;
    }

    public void ActivarAcciones()
    {
        Acciones.SetActive(true);
        background.SetActive(true);
    }
    public void DesactivarAcciones()
    {
        descativarAcciones = true;
    }

    public void ActivarTutorial()
    {
        Tutorial.SetActive(true);
        background.SetActive(true);
    }
    public void DesactivarTutorial()
    {
        desactivarTutorial = true;
    }

    public void ActivarPersonajes()
    {
        Personajes.SetActive(true);
        background.SetActive(true);
    }

    public void DesactivarPersonajes()
    {
        desactivarPersonajes = true;
    }

    public void SeleccionPersonajeChico()
    {
        //CHICO = 0
        botonChica.interactable = false;
        
        ChicoChica.seleccion = 0;

    }

    public void SeleccionPersonajeChica()
    {
        //CHICO = 1
        botonChico.interactable = false;
        
        ChicoChica.seleccion = 1;
    }
}
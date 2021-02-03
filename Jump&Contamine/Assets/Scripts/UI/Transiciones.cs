using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transiciones : MonoBehaviour
{
    public GameObject Configuración, Tutorial;

    private float timer, limitTimer;
    private bool desactivarConfig, desactivarTutorial;

    private void Start()
    {
        timer = 0f;
        limitTimer = 1f;
        desactivarConfig = false;
        desactivarTutorial = false;
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
            }
        }
    }

    public void ActivarConfiguracion()
    {
        Configuración.SetActive(true);
    }
    public void DesactivarConfiguracion()
    {
        desactivarConfig = true;
    }

    public void ActivarTutorial()
    {
        Tutorial.SetActive(true);
    }
    public void DesactivarTutorial()
    {
        desactivarTutorial = true;
    }
}
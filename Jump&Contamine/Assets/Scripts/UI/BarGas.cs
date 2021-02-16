using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGas : MonoBehaviour
{

    public GameObject[] gasBar;
    private float gasBarSpeed;
    private int nivel;
    private bool cambio;

    public void Start()
    {
        cambio = false;
        nivel = 0;
        ActualizarBarra(nivel);  
    }

    public void Update()
    {

        gasBarSpeed = playerController.gasbarSpeed;

        CalcularNivel(gasBarSpeed);

        switch (nivel)
        {
            case 0:
                ActualizarBarra(nivel);
                break;
            case 1:
                ActualizarBarra(nivel);
                break;
            case 2:
                ActualizarBarra(nivel);
                break;
            case 3:
                ActualizarBarra(nivel);
                break;
            case 4:
                ActualizarBarra(nivel);
                break;
            case 5:
                ActualizarBarra(nivel);
                break;
            case 6:
                ActualizarBarra(nivel);
                break;
            default:
                ActualizarBarra(nivel);
                break;
        }
    }

    private void CalcularNivel(float gasBarSpeed)
    {
        if (gasBarSpeed <= 2f)
            nivel = 0;
        else if (gasBarSpeed <= 4.7f)
            nivel = 1;
        else if (gasBarSpeed <= 5.2f)
            nivel = 2;
        else if (gasBarSpeed <= 5.5f)
            nivel = 3;
        else if (gasBarSpeed <= 6f)
            nivel = 4;
        else if (gasBarSpeed <=7f)
            nivel = 5;
        else if (gasBarSpeed <= 7.5f)
            nivel = 6;
        else
            nivel = 7;
    }
    private void ActualizarBarra(int x)
    {
        for (int i = 0; i < gasBar.Length; i++)
        {
            if (x == i)
                gasBar[i].SetActive(true);
            else
                gasBar[i].SetActive(false);
        }
    }
}

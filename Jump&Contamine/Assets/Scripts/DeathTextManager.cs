using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathTextManager : MonoBehaviour
{
    public GameObject PantallaFinal, bueno, malo, PantallaTormenta, back;
    public GameObject[] resultados;
    public Text textBueno, HC, KG, TEMP, RESULT;
    public float timer;


    public static bool caso, storm;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        caso = false;
        storm = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (storm)
        {
            back.SetActive(true);
            PantallaTormenta.SetActive(true);
            storm = false;
        }
        if (caso)
        {
            caso = false;
            PantallaFinal.SetActive(true);
            

            if (timer > 100)
            {
                textBueno.text = "ESPERANZA";
                bueno.SetActive(true);
                
                resultados[0].SetActive(true);
                resultados[1].SetActive(true);
                resultados[4].SetActive(true);
                HC.text = "25 HECTÁREAS DESTRUIDAS";
                KG.text = "25 KG DE BASURA ARROJADOS AL MAR";
                TEMP.text = "LA TEMPERATURA EN LA TIERRA A BAJADO";
                RESULT.text = "EL PLANETA PODRÍA SOBREVIVIR";


            }
            else
            {
                textBueno.text = "CATASTROFE";
                malo.SetActive(true);

                resultados[3].SetActive(true);
                resultados[4].SetActive(true);
                resultados[5].SetActive(true);

                HC.text = "100 HECTÁREAS DESTRUIDAS";
                KG.text = "1000 KG DE BASURA ARROJADOS AL MAR";
                TEMP.text = "LA TEMPERATURA EN LA TIERRA A SUBIDO";
                RESULT.text = "EL PLANETA NO SOBREVIVIRÁ";
            }


        }

    }

    public void Salir()
    {
        SceneManager.LoadScene(2);
    }


}

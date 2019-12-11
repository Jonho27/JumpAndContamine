using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTextManager : MonoBehaviour
{
    public Image perder50;
    public Image perder100;
    public Image perder120;
    public Image perder200;
    public Image perder250;
    public Image perder300;
    public Image perder470;
    public Image perder700;

    public static int caso;

    // Start is called before the first frame update
    void Start()
    {
        caso = 0;
    }

    // Update is called once per frame
    void Update()
    {
        activar();
        
    }

    public void activar()
    {

        switch (caso)
        {
            case 50:
                perder50.GetComponent<Image>().enabled = true;
                break;
            case 100:
                perder100.GetComponent<Image>().enabled = true;
                break;
            case 120:
                perder120.GetComponent<Image>().enabled = true;
                break;
            case 200:
                perder200.GetComponent<Image>().enabled = true;
                break;
            case 250:
                perder250.GetComponent<Image>().enabled = true;
                break;
            case 300:
                perder300.GetComponent<Image>().enabled = true;
                break;
            case 470:
                perder470.GetComponent<Image>().enabled = true;
                break;
            case 700:
                perder700.GetComponent<Image>().enabled = true;
                break;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FrasesIniciales : MonoBehaviour
{

    private string[] frasesIniciales = new string[]{

        "La temperatura media ha aumentado un 1.1ºC en los últimos años.",
        "6.000 millones de kilogramos de basura son arrojados al mar.",
        "Groenlandia ya ha peridido más del 30% de su hielo.",
        "Cada año desaparecen 8.8 millones de hectáreas de bosque.",
        "El 20% de las emisiones de efecto invernadero vienen de la deforestación."
            };

    private float timer;
    private int x, anterior;

    public AudioClip CambioFrase;
    
    public Text text;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
        timer = 0;
        x = Random.Range(0, frasesIniciales.Length);
        anterior = x;
        text.text = frasesIniciales[x];

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {

            timer = 0;
            while(x == anterior)
                x = Random.Range(0, frasesIniciales.Length);

            text.text = frasesIniciales[x];
            anterior = x;
            audioSource.PlayOneShot(CambioFrase, 0.7F);

        }
    }
}

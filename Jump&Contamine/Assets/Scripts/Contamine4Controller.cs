using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contamine4Controller : MonoBehaviour
{
    public static bool activo;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        activo = false;
        timer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            timer += Time.deltaTime;
            gameObject.GetComponent<Image>().enabled = true;
            if (timer > 0.65)
            {
                activo = false;
                timer = 0;
                gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }
}

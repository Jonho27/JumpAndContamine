using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contamine4Controller : MonoBehaviour
{
    public static bool activo = false;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pruebas : MonoBehaviour
{

    public Text texto;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            /*
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToViewportPoint(touch.position);
            touchPosition.z = 0;
            transform.position = touchPosition;
            */
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToViewportPoint(touch.position);
            //touchPosition.z = 0;
            //transform.position = touchPosition;

            texto.text = "touchPosition: " + touchPosition;

        }
        //texto.text = "holaaaaaaa";


    }
}

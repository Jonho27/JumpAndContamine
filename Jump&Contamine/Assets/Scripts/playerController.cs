using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{


    private Vector2 position;
    public float distanciaLados;
    public float distanciaAltura;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.x > -1.8) {
                position = new Vector2(transform.position.x - distanciaLados * 50 * Time.deltaTime, transform.position.y + distanciaAltura * 50 * Time.deltaTime);
                transform.position = position;
            }
            
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x < 2)
            {
                position = new Vector2(transform.position.x + distanciaLados * 50 * Time.deltaTime, transform.position.y + distanciaAltura * 50 * Time.deltaTime);
                transform.position = position;
            }
            
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position = new Vector2(transform.position.x, transform.position.y + distanciaAltura * 50 * Time.deltaTime);
            transform.position = position;
        }

        
    }
}

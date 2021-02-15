using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMovement : MonoBehaviour
{
    public float speed;
    private Vector2 move = new Vector2(0, 1);
    private bool salvavidasActivo;
    private float timer;
    private float speedAux;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        timer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (salvavidasActivo)
        {
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                salvavidasActivo = false;
                speed = speedAux;
                timer = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (playerController.empiezaGas)
        {
            transform.Translate(move * speed * Time.deltaTime);
        }
        
    }

    public void salvavidas()
    {
        speedAux = speed;
        speed = -10f;
        salvavidasActivo = true;
        //transform.Translate(transform.position.x, transform.position.y + 10, transform.position.z);
    }

    public void contamine()
    {
        if (!salvavidasActivo)
        {
            if (speed + 1.2f < 3)
            {
                speed += 3f;
            }
            else if (speed + 0.4f <= 10f)
            {
                speed += 0.4f;
            }
            else
            {
                speed = 10f;
            }
        }   
    }

    public void contamine4()
    {
        if (!salvavidasActivo)
        {
            if (speed + 1.2f < 3)
            {
                speed += 3f;
            }
            else if (speed + 0.8f <= 10f)
            {
                speed += 0.8f;
            }
            else
            {
                speed = 10f;
            }
        }  
    }

    public void contamine8()
    {
        if (!salvavidasActivo)
        {
            if (speed + 1.2f < 3)
            {
                speed += 3f;
            }
            else if (speed + 1.2f <= 10f)
            {
                speed += 1.2f;
            }
            else
            {
                speed = 10f;
            }
        }  
    }

    public void recycle()
    {
        if (!salvavidasActivo)
        {
            if (speed - 0.4f >= 1)
            {
                float speedTemporal = Random.Range(0.3f, 0.51f);
                speed -= speedTemporal;
            }
            else
            {
                speed = 1f;
            }
        } 
    }
}

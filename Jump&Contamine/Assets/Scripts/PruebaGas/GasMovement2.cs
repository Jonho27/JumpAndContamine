using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMovement2 : MonoBehaviour
{
    public float speed;
    private Vector2 move = new Vector2(0, 1);
    private bool salvavidasActivo;
    private float timer;

    private bool contamineActive;
    private float limitTime;
    private float contamineSpeed;
    private bool recycleActive;
    private float recycleSpeed;

    private float normalSpeed;

    public bool empiezaGas;
    private bool contadorTerminado;
    private float timerGas;

    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = 6.5f;
        speed = normalSpeed;
        timer = 0f;
        contamineSpeed = 9f;
        recycleSpeed = 4.5f;
        empiezaGas = false;

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
                speed = normalSpeed;
                timer = 0f;
            }
        }

        if (contamineActive)
        {
            timer += Time.deltaTime;
            if (timer >= limitTime)
            {
                contamineActive = false;
                speed = normalSpeed;
                timer = 0f;
            }
        }

        if (recycleActive)
        {
            timer += Time.deltaTime;
            if (timer >= limitTime)
            {
                recycleActive = false;
                speed = normalSpeed;
                timer = 0f;
            }
        }

        if (empiezaGas)
        {
            timerGas += Time.deltaTime;
            if(timerGas >= 7f)
            {
                timerGas = 0;
                empiezaGas = false;
                contadorTerminado = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (contadorTerminado)
        {
            transform.Translate(move * speed * Time.deltaTime);
        }

    }

    public void salvavidas()
    {
        speed = -10f;
        salvavidasActivo = true;
        timer = 0;
        //transform.Translate(transform.position.x, transform.position.y + 10, transform.position.z);
    }

    public void contamine()
    {
        if (!salvavidasActivo)
        {
            contamineActive = true;
            recycleActive = false;
            timer = 0;
            speed = contamineSpeed;
            limitTime = 2f;
        }   
    }

    public void contamine4()
    {
        if (!salvavidasActivo)
        {
            contamineActive = true;
            recycleActive = false;
            timer = 0;
            speed = contamineSpeed;
            limitTime = 4f;
        }  
    }

    public void contamine8()
    {
        if (!salvavidasActivo)
        {
            contamineActive = true;
            recycleActive = false;
            timer = 0;
            speed = contamineSpeed;
            limitTime = 6f;
        }  
    }

    public void recycle()
    {
        if (!salvavidasActivo)
        {
            recycleActive = true;
            contamineActive = false;
            timer = 0;
            speed = recycleSpeed;
            limitTime = 2.5f;
        }  
    }
}

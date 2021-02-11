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
        speed = -6.5f;
        salvavidasActivo = true;
        //transform.Translate(transform.position.x, transform.position.y + 10, transform.position.z);
    }
}

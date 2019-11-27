using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public GameObject player;
    private Vector3 position;
    public float distanciaLados;
    public float distanciaAltura;
    public bool keyHit = false;
    public bool onPlattform = false;
    public bool caida = false;
    public bool propulsado = false;
    private float speed = 10f;
    private Vector2 fall = new Vector2(0, -1);
    private Vector2 up = new Vector2(0, 1);
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
                
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !caida && onPlattform && !propulsado)
        {
            keyHit = true;
            if (transform.position.x > -0.5)
            {
                position = new Vector3(player.transform.position.x - distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);

            }


        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) && !caida && onPlattform && !propulsado)
        {
            keyHit = true;
            if (transform.position.x < 0.5)
            {
                position = new Vector3(player.transform.position.x + distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);

            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && !caida && onPlattform && !propulsado)
        {
            keyHit = true;
            position = new Vector3(player.transform.position.x, player.transform.position.y + distanciaAltura, player.transform.position.z);  
        }
        
        

        if (keyHit)
        {

            player.transform.position = Vector3.Lerp(player.transform.position, position, 0.1f);
            if(player.transform.position == position)
            {
                keyHit = false;

                /*if(onPlattform == false)
                {
                    caida = true;
                }*/
            }
            
        }

        if (propulsado)
        {
            timer += Time.deltaTime;
            if (timer >= 0.85)
            {
                propulsado = false;
                timer = 0f;
                caida = true;
            }
        }


    }

    private void FixedUpdate()
    {
        caer();
        propulsar();
    }


    public void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Plataforma")
        {
            onPlattform = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Plataforma")
        {
            if (caida)
            {
                caida = false;
            }
        }

        if (collider.gameObject.tag == "Vacio")
        {
            if (!caida)
            {
                caida = true;
                keyHit = false;
            }
        }

        if (collider.gameObject.tag == "Jetpack")
        {
            Debug.Log("Propulsado");
            propulsado = true;
            keyHit = false;
            GasMovement.speed += 2;
            collider.gameObject.SetActive(false);
        }

        if (collider.gameObject.tag == "Gas")
        {
            Debug.Log("Muerto");
            
        }

    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Plataforma")
        {
            onPlattform = false;
        }
    }

    private void caer()
    {
        if (caida)
        {
            transform.Translate(fall * speed * Time.deltaTime);
        }
    }

    public void propulsar()
    {
        if (propulsado)
        {
            transform.Translate(up * speed * Time.deltaTime);
        }
    }
}

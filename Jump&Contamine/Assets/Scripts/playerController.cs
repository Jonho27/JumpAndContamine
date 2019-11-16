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
    private float speed = 10f;
    private Vector2 fall = new Vector2(0, -1);

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
                
        if (Input.GetKeyDown(KeyCode.LeftArrow) && caida == false && onPlattform)
        {
            keyHit = true;
            if (transform.position.x > -0.5)
            {
                position = new Vector3(player.transform.position.x - distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);

            }


        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) && caida == false && onPlattform)
        {
            keyHit = true;
            if (transform.position.x < 0.5)
            {
                position = new Vector3(player.transform.position.x + distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);

            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && caida == false && onPlattform)
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

                if(onPlattform == false)
                {
                    caida = true;
                }
            }
            
        }

        
    }

    private void FixedUpdate()
    {
        caer();
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Plataforma")
        {
            onPlattform = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (caida)
        {
            caida = false;
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
}

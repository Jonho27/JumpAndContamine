﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject gameOverWin;
    [HideInInspector] public static bool canMove = true;

    public GameObject player;
    private Vector3 position;
    public float distanciaLados;
    public float distanciaAltura;
    public bool keyHit = false;
    public bool onPlattform = false;
    public bool caida = false;
    public bool propulsado = false;
    public bool globo = false;
    public bool elevado = false;
    private float speed = 10f;
    private Vector2 fall = new Vector2(0, -1);
    private Vector2 up = new Vector2(0, 1);
    private float timer = 0f;
    backgroundMovement background;
    //private float timer2 = 0f;

    public bool impulsoContaminante = false;
    public bool jetpack = false;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        myAnimator = GetComponent<Animator>();
  
    }


    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
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
            //myAnimator.SetTrigger("jump");
            if (timer >= 1.2)
            {
                propulsado = false;
                timer = 0f;
                caida = true;
            }
        }

        if (elevado)
        {
            timer += Time.deltaTime;
            //myAnimator.SetTrigger("jump");
            if (timer >= 1.05)
            {
                elevado = false;
                timer = 0f;
                caida = true;
               
            }
        }

        if (impulsoContaminante)
        {
            timer += Time.deltaTime;
            //myAnimator.SetTrigger("jump");
            if (timer >= 0.85)
            {
                impulsoContaminante = false;
                timer = 0f;
                caida = true;
                GasMovement.speed += 0.8f;
                
            }
        }


    }

    void Move()
    {
        //Touch touch = Input.GetTouch(0);
        //Vector3 touchPosition = Camera.main.ScreenToViewportPoint(touch.position);

        //con teclado
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("salto");
            keyHit = true;
            if (transform.position.x > -0.8)
            {   //backgroundMovement.escenario = true;
                position = new Vector3(player.transform.position.x - distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);
                myAnimator.SetTrigger("jump");

            }


        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("salto");
            keyHit = true;
            if (transform.position.x < 0.8)
            {
                //backgroundMovement.escenario = true;
                position = new Vector3(player.transform.position.x + distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);
                myAnimator.SetTrigger("jump");
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("salto");
            //backgroundMovement.escenario = true;
            keyHit = true;
            position = new Vector3(player.transform.position.x, player.transform.position.y + distanciaAltura, player.transform.position.z);
            myAnimator.SetTrigger("jump");
        }

        /*
        //con movil
        else if ((touchPosition.x <= 0.3f && touchPosition.y > 0.2f && touchPosition.y < 0.5f) //left
            && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("salto");
            keyHit = true;
            if (transform.position.x > -0.8)
            {   //backgroundMovement.escenario = true;
                position = new Vector3(player.transform.position.x - distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);
                myAnimator.SetTrigger("jump");

            }
        }
        else if ((touchPosition.x >= 0.7f && touchPosition.y > 0.2f && touchPosition.y < 0.5f) //right
            && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("salto");
            keyHit = true;
            if (transform.position.x > -0.8)
            {   //backgroundMovement.escenario = true;
                position = new Vector3(player.transform.position.x + distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);
                myAnimator.SetTrigger("jump");

            }
        }
        else if ((touchPosition.x >= 0.4f && touchPosition.x <= 0.6f && touchPosition.y > 0.2f && touchPosition.y < 0.5f) //up
            && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("salto");
            keyHit = true;
            if (transform.position.x > -0.8)
            {   //backgroundMovement.escenario = true;
            position = new Vector3(player.transform.position.x, player.transform.position.y + distanciaAltura, player.transform.position.z);
                myAnimator.SetTrigger("jump");

            }
        }
        */

    }

    private void FixedUpdate()
    {
        caer();
        propulsar();
        elevar();
        contaminar();
    }


    public void OnTriggerStay2D(Collider2D collider)
    {
        if((collider.gameObject.tag == "Plataforma" || collider.gameObject.tag == "Reciclable" || collider.gameObject.tag == "ConPlataforma") && !elevado)
        {
            onPlattform = true;
            
        }

        if (collider.gameObject.tag == "Contaminante" && !propulsado && !elevado)
        {
            //soundManager.PlaySound("impulso");
            impulsoContaminante = true;
            keyHit = false;
            Contamine4Controller.activo = true;

        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Contaminante" && !propulsado && !elevado)
        {
            soundManager.PlaySound("impulso");
        }
        if (collider.gameObject.tag == "End")
        {
            gameOverWin.SetActive(true);
            canMove = false;
        }


        if ((collider.gameObject.tag == "Plataforma" || collider.gameObject.tag == "Reciclable" || collider.gameObject.tag == "ConPlataforma" || collider.gameObject.tag == "Contaminante") && caida)
        {
            transform.position = new Vector3(collider.gameObject.transform.position.x + 0.5f, collider.gameObject.transform.position.y + 1f, transform.position.z);
            caida = false;    
        }

        if (collider.gameObject.tag == "ConPlataforma" && !caida)
        {
            GasMovement.speed += 0.4f;
            ContamineController.activo = true;
        }

        if (collider.gameObject.tag == "ConPlataforma" && !propulsado && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("negativo");
        }

        if (collider.gameObject.tag == "Reciclable" && !caida)
        {
            soundManager.PlaySound("positivo");
            if (GasMovement.speed - 0.4f >= 1)
            {
                GasMovement.speed -= 0.4f;
            }
            else
            {
                GasMovement.speed = 1f;
            }
            RecycleController.activo = true;
        }

        if (collider.gameObject.tag == "Vacio" && !caida && !propulsado && !elevado && !impulsoContaminante)
        {
            if (globo)
            {
                soundManager.PlaySound("elevacion");
                elevado = true;
                keyHit = false;
                globo = false;
            }

            else
            {
                caida = true;
                keyHit = false;
            }
            
        }

        if (collider.gameObject.tag == "Jetpack" && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("globo");
            jetpack = true;
            collider.gameObject.SetActive(false);
        }

        if (collider.gameObject.tag == "Globo" && !propulsado && !impulsoContaminante)
        {
            soundManager.PlaySound("globo");
            globo = true;
            collider.gameObject.SetActive(false);
        }

        if (collider.gameObject.tag == "Gas")
        {
            if (jetpack)
            {
                if (caida)
                {
                    caida = false;
                }
                soundManager.PlaySound("propulsion");
                Debug.Log("Propulsado");
                propulsado = true;
                keyHit = false;
                GasMovement.speed += 1.2f;
                Contamine8Controller.activo = true;
                jetpack = false;
            }

            else
            {
                soundManager.PlaySound("muerte");
                Debug.Log("Muerto");
                myAnimator.SetBool("dead",true);
            }
            
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Plataforma" || collider.gameObject.tag == "Reciclable" || collider.gameObject.tag == "ConPlataforma")
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

    public void elevar()
    {
        if (elevado)
        {
            transform.Translate(up * speed * Time.deltaTime);
        }
    }

    public void contaminar()
    {
        if (impulsoContaminante)
        {
            transform.Translate(up * speed * Time.deltaTime);
        }
    }

}

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
    public bool globo = false;
    public bool elevado = false;
    private float speed = 10f;
    private Vector2 fall = new Vector2(0, -1);
    private Vector2 up = new Vector2(0, 1);
    private float timer = 0f;
    backgroundMovement background;
    //private float timer2 = 0f;

    public bool impulsoContaminante = false;

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
                
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            keyHit = true;
            if (transform.position.x > -0.8)
            {   backgroundMovement.escenario = true;
                position = new Vector3(player.transform.position.x - distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);
                myAnimator.SetTrigger("jump");
                
            }


        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            keyHit = true;
            if (transform.position.x < 0.8)
            {
                backgroundMovement.escenario = true;
                position = new Vector3(player.transform.position.x + distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);
                myAnimator.SetTrigger("jump");
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            backgroundMovement.escenario = true;
            keyHit = true;
            position = new Vector3(player.transform.position.x, player.transform.position.y + distanciaAltura, player.transform.position.z);  
            myAnimator.SetTrigger("jump");
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
            if (timer >= 0.85)
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
            if (timer >= 1.2)
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
                GasMovement.speed += 2;
                

            }
        }


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
        if(collider.gameObject.tag == "Plataforma" || collider.gameObject.tag == "Reciclable")
        {
            onPlattform = true;
            
        }

        if (collider.gameObject.tag == "Contaminante")
        {
            impulsoContaminante = true;
            keyHit = false;
            ContamineController.activo = true;

        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.gameObject.tag == "Plataforma" || collider.gameObject.tag == "Reciclable") && caida)
        {
            transform.position = new Vector3(collider.gameObject.transform.position.x + 0.5f, collider.gameObject.transform.position.y + 1f, transform.position.z);
            caida = false;    
        }

        if (collider.gameObject.tag == "Reciclable" && !caida)
        {
            GasMovement.speed -= 1.5f;
            RecycleController.activo = true;
        }

        if (collider.gameObject.tag == "Vacio" && !caida && !propulsado && !elevado && !impulsoContaminante)
        {
            caida = true;
            keyHit = false;  
        }

        if (collider.gameObject.tag == "Jetpack" && !elevado && !impulsoContaminante)
        {
            Debug.Log("Propulsado");
            propulsado = true;
            keyHit = false;
            GasMovement.speed += 2;
            collider.gameObject.SetActive(false);
            ContamineController.activo = true;
        }

        if (collider.gameObject.tag == "Globo" && !propulsado && !impulsoContaminante)
        {
            globo = true;
            collider.gameObject.SetActive(false);
        }

        if (collider.gameObject.tag == "Gas")
        {
            if (globo)
            {
                elevado = true;
                globo = false;
            }

            else
            {
                Debug.Log("Muerto");
                myAnimator.SetBool("dead",true);
            }
            
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Plataforma" || collider.gameObject.tag == "Reciclable")
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

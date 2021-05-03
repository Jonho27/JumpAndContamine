using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tactilPlayerMovement : MonoBehaviour
{
    [HideInInspector] public static bool canMove;

    public GameObject SalvavidasUI, JetpackUI;
    public bool llegada;
    float fallo;
    public static float gasbarSpeed;
    public float desplazamientoRecolocacion;

    float smoothTime = 0.1f;// Jon lo tenía a 0.01. Controla el tiempo que tarda en llegar a otra plataforma
    private Vector3 velocity = Vector3.zero;

    private Vector3 position;
    public float distanciaLados;
    public float distanciaAltura;
    public bool keyHit;
    public bool onPlattform;
    public bool caida;
    public bool propulsado;
    public bool elevado;
    private float speed = 10f;
    private Vector2 fall = new Vector2(0, -1);
    private Vector2 up = new Vector2(0, 1);
    private float timer;
    backgroundMovement background;

    public bool impulsoContaminante;
    public bool salvavidas;
    public bool jetpack;

    private Animator myAnimator;

    private bool muerto;
    private float timer2;

    CanvasController canvasController;
    GasMovement2 gas;

    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        llegada = false;
        fallo = 0f;
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        myAnimator = GetComponent<Animator>();
        muerto = false;
        keyHit = false;
        onPlattform = false;
        caida = false;
        propulsado = false;
        salvavidas = false;
        elevado = false;
        timer = 0f;
        impulsoContaminante = false;
        jetpack = false;
        canMove = true;
        timer2 = 0f;

        canvasController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CanvasController>();
        gas = GameObject.FindGameObjectWithTag("Gas").GetComponent<GasMovement2>();

        moving = false;

    }



    // Update is called once per frame
    void Update()
    {
        gasbarSpeed = gas.speed;

        /*if (canMove && !muerto)
        {
            Move();
        }*/

        if (moving)
        {
            gas.empiezaGas = true;

            // Define a target position above and behind the target transform

            // Smoothly move the camera towards that target position
            //transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smoothTime);

            if (transform.position == position)
            {
                moving = false;
                if (elevado || impulsoContaminante || caida || muerto)
                {
                    canMove = false;
                }

                else
                {
                    canMove = true;
                }
            }

        }

        else if (!canMove && !moving)
        {
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
                    gas.contamine4();

                }
            }
        }



        if (muerto)
        {
            gas.speed = 0;
            timer2 += Time.deltaTime;
            if (timer2 >= 2f)
            {
                DeathTextManager.storm = true;
                DeathTextManager.caso = true;
            }

        }


    }

    void Move(string movement)
    {
        //Touch touch = Input.GetTouch(0);
        //Vector3 touchPosition = Camera.main.ScreenToViewportPoint(touch.position);

        //con teclado
        if (movement == "Left" && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            if (transform.position.x > -0.8)
            {
                soundManager.PlaySound("salto");
                position = new Vector3(transform.position.x - distanciaLados, transform.position.y + distanciaAltura, transform.position.z);
                myAnimator.SetTrigger("jump");
                canMove = false;
                moving = true;
                movePlayer();

            }
        }

        else if (movement == "Right" && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            if (transform.position.x < 0.8)
            {
                soundManager.PlaySound("salto");
                position = new Vector3(transform.position.x + distanciaLados, transform.position.y + distanciaAltura, transform.position.z);
                myAnimator.SetTrigger("jump");
                canMove = false;
                moving = true;
                movePlayer();
            }
        }

        else if (movement == "Up" && !caida && onPlattform && !propulsado && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("salto");
            keyHit = true;
            position = new Vector3(transform.position.x, transform.position.y + distanciaAltura, transform.position.z);
            myAnimator.SetTrigger("jump");
            canMove = false;
            moving = true;
            movePlayer();
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
        if (!moving)
        {
            if (caida)
            {
                transform.Translate(fall * speed * Time.deltaTime);
            }

            if (propulsado)
            {
                transform.Translate(up * speed * Time.deltaTime);
            }

            if (elevado)
            {
                transform.Translate(up * speed * Time.deltaTime);
            }

            if (impulsoContaminante)
            {
                transform.Translate(up * speed * Time.deltaTime);
            }
        }
    }


    /*public void OnTriggerStay2D(Collider2D collider)
    {
        if ((collider.gameObject.tag == "Plataforma" || collider.gameObject.tag == "Reciclable" || collider.gameObject.tag == "ConPlataforma") && !elevado)
        {
            onPlattform = true;

            if (llegada)
            {
                position = new Vector3(collider.gameObject.transform.position.x + 0.5f, collider.gameObject.transform.position.y + 1, player.transform.position.z);
                llegada = false;
            }
        }

        if (collider.gameObject.tag == "Contaminante" && !propulsado && !elevado)
        {
            impulsoContaminante = true;
            keyHit = false;
            canvasController.activarContaminar4();

        }
    }*/

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Plataforma" || collider.gameObject.tag == "Reciclable" || collider.gameObject.tag == "ConPlataforma")
        {
            onPlattform = true;
        }

        if (collider.gameObject.tag == "Contaminante" && !propulsado && !elevado)
        {
            impulsoContaminante = true;
            soundManager.PlaySound("impulso");
            canvasController.activarContaminar4();
        }
        if (collider.gameObject.tag == "End")
        {

            canMove = false;
        }
        /*if (collider.gameObject.tag == "HaLlegado")
        {
            llegada = true;
        }*/


        if ((collider.gameObject.tag == "Plataforma" || collider.gameObject.tag == "Reciclable" || collider.gameObject.tag == "ConPlataforma" || collider.gameObject.tag == "Contaminante") && caida)
        {
            transform.position = new Vector3(collider.gameObject.transform.position.x + desplazamientoRecolocacion, collider.gameObject.transform.position.y + 1f, transform.position.z);
            caida = false;
            canMove = true;
        }

        if (collider.gameObject.tag == "ConPlataforma" && !propulsado && !elevado && !impulsoContaminante)
        {
            gas.contamine();
            canvasController.activarContaminar();
            soundManager.PlaySound("negativo");
        }

        if (collider.gameObject.tag == "Reciclable" && !caida && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("positivo");
            gas.recycle();
            canvasController.activarRecycle();
        }

        if (collider.gameObject.tag == "Vacio" && !caida && !propulsado && !elevado && !impulsoContaminante)
        {
            if (jetpack)
            {
                soundManager.PlaySound("elevacion");
                elevado = true;
                keyHit = false;
                jetpack = false;
                JetpackUI.SetActive(false);

                gas.contamine8();
                canvasController.activarContaminar8();
            }

            else
            {
                caida = true;
            }

        }

        if (collider.gameObject.tag == "Globo" && !elevado && !propulsado && !impulsoContaminante)//El tag es jetpack y no globo porque decidimos que sus funciones se iban a intercambiar
        {
            if (!salvavidas)
            {
                SalvavidasUI.SetActive(true);
                Debug.Log("power");
                soundManager.PlaySound("globo");
                salvavidas = true;
                collider.gameObject.SetActive(false);
            }

        }

        if (collider.gameObject.tag == "Jetpack" && !propulsado && !elevado && !impulsoContaminante)
        {
            if (!jetpack)
            {
                soundManager.PlaySound("globo");
                jetpack = true;
                JetpackUI.SetActive(true);
                collider.gameObject.SetActive(false);
            }
        }

        if (collider.gameObject.tag == "Gas")
        {
            if (salvavidas)
            {
                soundManager.PlaySound("propulsion");
                Debug.Log("Propulsado");
                gas.salvavidas();
                salvavidas = false;
                SalvavidasUI.SetActive(false);
            }

            else
            {
                canMove = false;
                moving = false;
                iTween.Stop();
                soundManager.PlaySound("muerte");
                Debug.Log("Muerto");
                myAnimator.SetBool("dead", true);
                muerto = true;
                gas.speed = 3f;

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

    private void movePlayer()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", position, "time", 0.2f, "easetype", iTween.EaseType.easeInOutSine));
    }

    public void moveUp()
    {
        if (canMove && !muerto)
        {
            Move("Up");
        }
    }

    public void moveLeft()
    {
        if (canMove && !muerto)
        {
            Move("Left");
        }
    }

    public void moveRight()
    {
        if (canMove && !muerto)
        {
            Move("Right");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [HideInInspector] public static bool canMove;

    public GameObject elPrefab;
    public GameObject[] todasLasPlataformas;
    public GameObject SalvavidasUI, JetpackUI;
    public bool llegada;
    float fallo;
    public static float gasbarSpeed;
    public float desplazamientoRecolocacion;

    float smoothTime = 0.1f;// Jon lo tenía a 0.01. Controla el tiempo que tarda en llegar a otra plataforma
    private Vector3 velocity = Vector3.zero;

    public GameObject player;
    private Vector3 position;
    public float distanciaLados;
    public float distanciaAltura;
    public bool keyHit;
    public bool onPlattform;
    public bool caida;
    public bool propulsado;
    public bool globo;
    public bool elevado;
    private float speed = 10f;
    private Vector2 fall = new Vector2(0, -1);
    private Vector2 up = new Vector2(0, 1);
    private float timer;
    backgroundMovement background;
    //private float timer2 = 0f;

    public bool impulsoContaminante;
    public bool jetpack;

    private Animator myAnimator;

    private bool muerto;
    private float timer2;

    CanvasController canvasController;
    //GasMovement gas;
    GasMovement2 gas;

    // Start is called before the first frame update
    void Start()
    {
        llegada = false;
        fallo = 0f;
        position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        myAnimator = GetComponent<Animator>();
        muerto = false;
        keyHit = false;
        onPlattform = false;
        caida = false;
        propulsado = false;
        globo = false;
        elevado = false;
        timer = 0f;
        impulsoContaminante = false;
        jetpack = false;
        canMove = true;
        timer2 = 0f;

        canvasController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CanvasController>();
        //gas = GameObject.FindGameObjectWithTag("Gas").GetComponent<GasMovement>();
        gas = GameObject.FindGameObjectWithTag("Gas").GetComponent<GasMovement2>();

        /*//Instantiate(elPrefab, prueba.transform);
        todasLasPlataformas = GameObject.FindGameObjectsWithTag("Plataforma");  //returns GameObject[]
        foreach (GameObject objeto in todasLasPlataformas)
        {
            Instantiate(elPrefab, objeto.transform);
        }

        todasLasPlataformas = GameObject.FindGameObjectsWithTag("Reciclable");  //returns GameObject[]
        foreach (GameObject objeto in todasLasPlataformas)
        {
            Instantiate(elPrefab, objeto.transform);
        }

        todasLasPlataformas = GameObject.FindGameObjectsWithTag("ConPlataforma");  //returns GameObject[]
        foreach (GameObject objeto in todasLasPlataformas)
        {
            Instantiate(elPrefab, objeto.transform);
        }

        todasLasPlataformas = GameObject.FindGameObjectsWithTag("Contaminante");  //returns GameObject[]
        foreach (GameObject objeto in todasLasPlataformas)
        {
            Instantiate(elPrefab, objeto.transform);
        }*/

    }



    // Update is called once per frame
    void Update()
    {
        gasbarSpeed = gas.speed;

        if (canMove)
        {
            Move();
        }

        if (keyHit)
        {
            gas.empiezaGas = true;

            // Define a target position above and behind the target transform

            // Smoothly move the camera towards that target position
            transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smoothTime);

            //player.transform.position = Vector3.Lerp(player.transform.position, position, 0.5f);
            if (player.transform.position == position)
            {
                keyHit = false;

                /*
                if(onPlattform == false)
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
                /*if (gas.speed + 1.2f < 6)
                {
                    gas.speed += 3f;
                }
                else if (gas.speed + 0.8f <= 10f)
                {
                    gas.speed += 0.8f;
                }
                else
                {
                    gas.speed = 10f;
                }*/
                gas.contamine4();

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
        /*caer();
        propulsar();
        elevar();
        contaminar();*/



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


    public void OnTriggerStay2D(Collider2D collider)
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
            //soundManager.PlaySound("impulso");
            impulsoContaminante = true;
            keyHit = false;
            canvasController.activarContaminar4();

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

            canMove = false;
        }
        if (collider.gameObject.tag == "HaLlegado")
        {
            llegada = true;
        }


        if ((collider.gameObject.tag == "Plataforma" || collider.gameObject.tag == "Reciclable" || collider.gameObject.tag == "ConPlataforma" || collider.gameObject.tag == "Contaminante") && caida)
        {
            transform.position = new Vector3(collider.gameObject.transform.position.x + desplazamientoRecolocacion, collider.gameObject.transform.position.y + 1f, transform.position.z);
            caida = false;
        }

        if (collider.gameObject.tag == "ConPlataforma" && !caida && !propulsado && !elevado && !impulsoContaminante)
        {

            /*if (gas.speed + 1.2f < 6)
            {
                gas.speed += 3f;
            }
            else if (gas.speed + 0.4f <= 10f)
            {
                gas.speed += 0.4f;
            }
            else
            {
                gas.speed = 10f;
            }*/
            gas.contamine();
            canvasController.activarContaminar();
            soundManager.PlaySound("negativo");
        }

        /*if (collider.gameObject.tag == "ConPlataforma" && !propulsado && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("negativo");
        }*/

        if (collider.gameObject.tag == "Reciclable" && !caida && !elevado && !impulsoContaminante)
        {
            soundManager.PlaySound("positivo");

            /*if (gas.speed - 0.4f >= 1)
            {
                float speedTemporal = Random.Range(0.3f, 0.51f);
                gas.speed -= speedTemporal;
            }
            else
            {
                gas.speed = 1f;
            }*/
            gas.recycle();
            canvasController.activarRecycle();
        }

        if (collider.gameObject.tag == "Vacio" && !caida && !propulsado && !elevado && !impulsoContaminante)
        {
            if (globo)
            {
                soundManager.PlaySound("elevacion");
                elevado = true;
                keyHit = false;
                globo = false;
                JetpackUI.SetActive(false);

                /*if (gas.speed + 1.2f < 6)
                {
                    gas.speed += 3f;
                }
                else if (gas.speed + 1.2f <= 10f)
                {
                    gas.speed += 1.2f;
                }
                else
                {
                    gas.speed = 10f;
                }*/
                gas.contamine8();
                canvasController.activarContaminar8();
            }

            else
            {
                caida = true;
                keyHit = false;
            }

        }

        if (collider.gameObject.tag == "Globo" && !elevado && !propulsado && !impulsoContaminante)//El tag es jetpack y no globo porque decidimos que sus funciones se iban a intercambiar
        {
            if (!jetpack)
            {
                SalvavidasUI.SetActive(true);
                Debug.Log("power");
                soundManager.PlaySound("globo");
                jetpack = true;
                collider.gameObject.SetActive(false);
            }

        }

        if (collider.gameObject.tag == "Jetpack" && !propulsado && !elevado && !impulsoContaminante)
        {
            if (!globo)
            {
                soundManager.PlaySound("globo");
                globo = true;
                JetpackUI.SetActive(true);
                collider.gameObject.SetActive(false);
            }
        }

        if (collider.gameObject.tag == "Gas")
        {
            if (jetpack)
            {
                /*if (caida)
                {
                    caida = false;
                }*/
                soundManager.PlaySound("propulsion");
                Debug.Log("Propulsado");
                //propulsado = true;
                keyHit = false;
                gas.salvavidas();
                /*if (gas.speed + 1.2f <= 6.5)
                {
                    gas.speed += 1.2f;
                }
                else
                {
                    gas.speed = 6.5f;
                }
                canvasController.activarContaminar8();*/
                jetpack = false;
                SalvavidasUI.SetActive(false);
            }

            else
            {
                canMove = false;
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

    /*private void caer()
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
    }*/

}

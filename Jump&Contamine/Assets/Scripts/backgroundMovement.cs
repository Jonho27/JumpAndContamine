using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{
    /*public GameObject player;
    Vector3 desiredPosition;
    float smoothSpeed = 10f;
    public Vector3 offset;
    public Vector3 jump;
    public static bool escenario = false; 

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z) + offset;
    }

    void Update()
    {
        if (escenario)
        {
            desiredPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z) + jump;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
            escenario = false;
        }
    }*/


    private Rigidbody2D rigidbody;
    private float speed = -1.5f;
    private bool stopScrolling;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0, speed);

    }

    void Update()
    {
        if (stopScrolling)
        {
            rigidbody.velocity = Vector2.zero;
        }

        else
        {
            rigidbody.velocity = new Vector2(0, speed);
        }
    }
}

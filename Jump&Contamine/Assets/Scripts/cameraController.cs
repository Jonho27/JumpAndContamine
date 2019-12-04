using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public GameObject player;
    Vector3 desiredPosition;
    float smoothSpeed = 10f;
    public Vector3 offset;

    public Transform background1;
    public Transform background2;
    private float size;

    private Vector3 background1Position = new Vector3();
    private Vector3 background2Position = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z) + offset;
        size = 47.3f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        desiredPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    private void Update()
    {
        if (transform.position.y >= background2.position.y)
        {
            background1.position = SetPosition(background1Position, background1.position.x, background2.position.y + size, background1.position.z);
            SwitchBackground();
        }

        if(transform.position.y < background1.position.y)
        {
            background2.position = SetPosition(background2Position, background2.position.x, background1.position.y - size, background2.position.z);
            SwitchBackground();
        }
    }

    private void SwitchBackground()
    {
        Transform temp = background1;
        background1 = background2;
        background2 = temp;
    }

    private Vector3 SetPosition (Vector3 position, float x, float y, float z)
    {
        position.x = x;
        position.y = y;
        position.z = z;

        return position;
    }
}


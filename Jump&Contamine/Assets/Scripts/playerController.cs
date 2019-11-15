using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public GameObject player;
    private Vector3 position;
    public float distanciaLados;
    public float distanciaAltura;
    private bool keyHit = false;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        

      
        
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                keyHit = true;
                if (transform.position.x > -0.5)
                {
                    position = new Vector3(player.transform.position.x - distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);


                }

            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                keyHit = true;
                if (transform.position.x < 0.5)
                {
                    position = new Vector3(player.transform.position.x + distanciaLados, player.transform.position.y + distanciaAltura, player.transform.position.z);

                }

            }

            else if (Input.GetKeyDown(KeyCode.UpArrow))
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
            }
            
        }

        
    }
}

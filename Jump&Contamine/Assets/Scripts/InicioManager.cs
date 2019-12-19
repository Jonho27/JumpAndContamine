using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InicioManager : MonoBehaviour
{

    public Image image;

    //float speed = 1f;
    float timer;
    // Start is called before the first frame update
    float x = 0;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 1)
        {
            
          var tempColor = image.color;
          tempColor.a = x;
          image.color = tempColor;
          x += 0.03f;
        }

        if(timer >= 3)
        {
            SceneManager.LoadScene(1);
        }

        //image.color = Color.Lerp(image.color, Color.clear, speed * Time.deltaTime);

    }
}

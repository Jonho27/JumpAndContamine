using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject contamine;
    public GameObject contamine4;
    public GameObject contamine8;
    public GameObject recycle;

    private float timerContamine;
    private float timerContamine4;
    private float timerContamine8;
    private float timerRecycle;

    private bool contamineActive;
    private bool contamine4Active;
    private bool contamine8Active;
    private bool recycleActive;
    // Start is called before the first frame update
    void Start()
    {
        contamine.SetActive(false);
        contamine4.SetActive(false);
        contamine8.SetActive(false);
        recycle.SetActive(false);

        timerContamine = 0f;
        timerContamine4 = 0f;
        timerContamine8 = 0f;
        timerRecycle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (contamineActive)
        {
            timerContamine += Time.deltaTime;
            contamine.SetActive(true);
            contamine4.SetActive(false);
            contamine8.SetActive(false);
            recycle.SetActive(false);
            if (timerContamine > 0.65)
            {
                contamineActive = false;
                timerContamine = 0;
                contamine.SetActive(false);
            }
        }

        if (contamine4Active)
        {
            timerContamine4 += Time.deltaTime;
            contamine4.SetActive(true);
            contamine.SetActive(false);
            contamine8.SetActive(false);
            recycle.SetActive(false);
            if (timerContamine4 > 0.65)
            {
                contamine4Active = false;
                timerContamine4 = 0;
                contamine4.SetActive(false);
            }
        }

        if (contamine8Active)
        {
            timerContamine8 += Time.deltaTime;
            contamine8.SetActive(true);
            contamine4.SetActive(false);
            contamine.SetActive(false);
            recycle.SetActive(false);
            if (timerContamine8 > 0.65)
            {
                contamine8Active = false;
                timerContamine8 = 0;
                contamine8.SetActive(false);
            }
        }

        if (recycleActive)
        {
            timerRecycle += Time.deltaTime;
            recycle.SetActive(true);
            contamine4.SetActive(false);
            contamine8.SetActive(false);
            contamine.SetActive(false);
            if (timerRecycle > 0.65)
            {
                recycleActive = false;
                timerRecycle = 0;
                recycle.SetActive(false);
            }
        }
    }

    public void activarContaminar()
    {
        contamineActive = true;
    }

    public void activarContaminar4()
    {
        contamine4Active = true;
    }

    public void activarContaminar8()
    {
        contamine8Active = true;
    }

    public void activarRecycle()
    {
        recycleActive = true;
    }
}

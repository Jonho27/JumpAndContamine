using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundBetweenScenes : MonoBehaviour
{

    private static soundBetweenScenes instance = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static soundBetweenScenes Instance
    {
        get
        {
            return instance;
        }
    }

}

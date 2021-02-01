using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public void ButtonClickSound()
    {
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void ButtonClickSound2()
    {
        FindObjectOfType<AudioManager>().Play("Button");
    }
}

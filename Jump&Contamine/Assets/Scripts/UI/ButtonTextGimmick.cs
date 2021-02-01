using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextGimmick : MonoBehaviour
{
    public float offset;
    private Text text;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    public void Press()
    {
        text.transform.localPosition += Vector3.down * offset;
    }
    public void Release()
    {
        text.transform.localPosition += Vector3.up * offset;
    }

}

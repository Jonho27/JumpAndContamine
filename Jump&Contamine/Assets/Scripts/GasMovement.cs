﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMovement : MonoBehaviour
{
    public static float speed = 1f;
    private Vector2 move = new Vector2(0, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }
}
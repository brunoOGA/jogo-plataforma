﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlataforma : MonoBehaviour
{
    public float count = 0;
    public float velocidade = 2;
    private Vector2 posInicial;
    public float raio = 2;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        count += velocidade * Time.deltaTime;

        float posX = Mathf.Cos(count);
        float posY = Mathf.Sin(count);

        Vector2 posAtual = new Vector2(posX * raio, posY * raio);

        transform.position = posInicial + posAtual;

        if (count >= 2 * Mathf.PI)
            count = 2 * Mathf.PI - count;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptJogo : MonoBehaviour
{
    // Start is called before the first frame update
    public void iniciar()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }


    // Update is called once per frame
    public void sair()
    {
        Application.Quit();
    }

    public void voltar()
    {
        SceneManager.LoadScene(0);
    }
}

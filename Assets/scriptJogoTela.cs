using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptJogoTela : MonoBehaviour
{
    public bool pausado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                pausado = false;
                Time.timeScale = 1;
                SceneManager.UnloadScene(2);
            }
            else
            {
                pausado = true;
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            }
                
        }
    }
}

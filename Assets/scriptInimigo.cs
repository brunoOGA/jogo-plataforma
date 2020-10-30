using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptInimigo : MonoBehaviour
{
    public float velocidade = 5;
    private Rigidbody2D rbd;
    public LayerMask mascara;
    public LayerMask mascaraPC;
    public LayerMask mascaraPlataforma;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2(velocidade, 0);

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.right, 0.7f, mascara);
        if(hit.collider != null)
        {
            velocidade = velocidade * -1;
            rbd.velocity = new Vector2(velocidade, 0);
            transform.Rotate(new Vector2(0, 180));
        }

        RaycastHit2D hit2;
        hit2 = Physics2D.Raycast(transform.position, transform.right, 0.7f, mascaraPlataforma);
        if (hit2.collider != null)
        {
            velocidade = velocidade * -1;
            rbd.velocity = new Vector2(velocidade, 0);
            transform.Rotate(new Vector2(0, 180));
        }

        RaycastHit2D hit3;
        hit3 = Physics2D.Raycast(transform.position, transform.right, 0.9f, mascaraPC);
        if (hit3.collider != null)
        {
            Destroy(hit3.collider.gameObject);
            SceneManager.LoadScene(3);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody2D rdb;
    private Animator anim;
    public float velocidade = 5;
    public float pulo = 300;
    private AudioSource som;
    private bool direita = true;
    private bool chao = true;
    public LayerMask mascara;
    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
        rdb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        chao = true;
        anim.SetBool("ar", false);
        transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        chao = false;
        transform.parent = null;
    }
    
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (x == 0)
            anim.SetBool("parado", true);
        else
            anim.SetBool("parado", false);

        if (direita && x < 0 || !direita && x > 0)
        {
            direita = !direita;
            transform.Rotate(new Vector2(0, 180));
        }

        float velY;
        if (chao)
            velY = 0;
        else
            velY = rdb.velocity.y;

        if(rdb.velocity.y<0)
            rdb.velocity = new Vector2(x * velocidade, rdb.velocity.y - 0.05f);
        else
            rdb.velocity = new Vector2(x * velocidade, rdb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            rdb.AddForce(new Vector2(0, pulo));
            anim.SetBool("ar", true);
            chao = false;
        }

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -transform.up, 0.7f, mascara);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
            som.Play();
        }
    }
}

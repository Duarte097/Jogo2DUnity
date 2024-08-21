using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_2 : MonoBehaviour
{
  
    private int pontoAtual;

    public float speed = 0.3f;
    public LayerMask layer;
    private Rigidbody2D rig;
    private Animator anim;
    private Collider2D attackCollider;
    public Transform rightCol;
    public Transform leftCol;
    public Transform headpoint;
    private bool colliding;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar o jogador
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>(); // Adicionado para o movimento
    }

    void Update()
    {
                // Movimento da Caveira
        rig.velocity = new Vector2(speed, rig.velocity.y);
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding)
        {
            anim.SetBool("walk",true);
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headpoint.position.y;

            if(height > 0)
            { 
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5);
                Destroy(gameObject, 1f);
            }
        }
    }
}

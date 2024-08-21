using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float speed = 0.3f; // Velocidade de perseguição
    public float detectionRange = 2f; // Distância de detecção do jogador
    public LayerMask playerLayer; // Layer do jogador
    private Animator anim;
    private Collider2D attackCollider;
    private bool isAttacking1;
    private bool isAttacking3;
    private Transform player; // Referência ao Transform do jogador
    private bool isChasing = false;

    private Rigidbody2D rig; // Adicionado para o movimento
    public Transform rightCol;
    public Transform leftCol;
    public Transform headpoint;
    private bool colliding;
    public LayerMask layer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar o jogador
        anim = GetComponent<Animator>();
        attackCollider = FindAttackCollider();
        rig = GetComponent<Rigidbody2D>(); // Adicionado para o movimento
    }

    void Update()
    {
       
    if (player != null && player.gameObject != null)
    {
        if (Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
    }
        else
        {
            isChasing = false;
        }

        // Se estiver perseguindo, mova-se em direção ao jogador
        if (isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
            Ataque();
        }

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

    Collider2D FindAttackCollider()
    {
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>(true);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("AttackCollider"))
            {
                collider.enabled = false;
                return collider;
            }
        }

        return null;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if ((isAttacking1) && col.gameObject.CompareTag("Player"))
        {
            Animator playerAnimator = col.gameObject.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                //playerAnimator.SetBool("dead", true);
            }
            //Destroy(col.gameObject, 0.5f);
        }

        if (col.gameObject.tag == " ")
        {
            float height = col.contacts[0].point.y - headpoint.position.y;

            if (height > 0)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                //anim.SetBool("morto", true);
                //Destroy(col.gameObject, 1f); // Isso destruirá o jogador
            }
        }
    }


    void Ataque()
    {
        anim.SetBool("walk",false);
        isAttacking1 = true;
        anim.SetBool("ataque_1", true);
    }

    void EndAnimationATK()
    {
        anim.SetBool("ataque_1", false);
        anim.SetBool("walk", true);

        isAttacking1 = false;
        isAttacking3 = false;

        if (attackCollider != null)
        {
            attackCollider.enabled = true;
        }
    }
}

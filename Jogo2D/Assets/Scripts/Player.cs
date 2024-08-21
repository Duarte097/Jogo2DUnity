using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rig;

    public bool isJumping;
    public bool DoubleJump;

    private Animator anim;
    
     private Collider2D attackCollider; 
    private bool isAttacking1;
    private bool isAttacking3;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attackCollider = FindAttackCollider();
    }

    void Update()
    {
        Move();
        Jump();
        Ataque();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }



    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                DoubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (DoubleJump)
                {
                    rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    DoubleJump = false;
                }
            }
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        Animator enemyAnimator = collision.gameObject.GetComponent<Animator>();
        if ((isAttacking1 || isAttacking3) && collision.gameObject.CompareTag("Inimigo"))
        {
            
            if (enemyAnimator != null)
            {
                enemyAnimator.SetBool("morto", true);
            }
            Destroy(collision.gameObject,0.5f); 
        }

    }

    public float GetSpeed()
    {
        return speed;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    void Ataque()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAttacking1 = true;
            anim.SetBool("ataque_1", true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            isAttacking3 = true;
            anim.SetBool("ataque_2", true);
        }
    }

    void EndAnimationATK()
    {
        anim.SetBool("ataque_1", false);
        anim.SetBool("ataque_2", false);

        isAttacking1 = false;
        isAttacking3 = false;

        if (attackCollider != null)
        {
            attackCollider.enabled = true;

            
        }
    }

}

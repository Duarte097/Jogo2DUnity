using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveira : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed;
    public Transform rightCol;
    public Transform leftCol;

    public Transform headpoint;

    private bool colliding;

    public LayerMask layer;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if(colliding){

            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == " "){
            float height = col.contacts[0].point.y - headpoint.position.y;

            if(height > 0 ){
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                anim.SetBool("morto",true);
                Destroy(gameObject, 1f);
            }
        }
    }
}

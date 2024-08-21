using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{
    public SliderJoint2D slider;
    public JointMotor2D temp;

    public float fallingTime;

    private BoxCollider2D boxColl;
    private TargetJoint2D target;
    void Start()
    {
        temp = slider.motor;
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        if(slider.limitState == JointLimitState2D.LowerLimit){
            temp.motorSpeed = 1;
            slider.motor = temp;
        }
        if(slider.limitState == JointLimitState2D.UpperLimit){
            temp.motorSpeed = -1;
            slider.motor = temp;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       /*if(collision.gameObject.tag == "Player"){
            Invoke("Falling", fallingTime);
        }*/

    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.layer == 9){
            Destroy(gameObject);
        }

    }

    void Falling(){
        if (target != null)
        {
            target.enabled = false;
        }

        boxColl.isTrigger = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    private BoxCollider2D collider;

    private AudioSource audio;
    private float speedDoPlayer;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        audio = GetComponent<AudioSource>();

        if (playerObj != null)
        {
            Player playerScript = playerObj.GetComponent<Player>();

            if (playerScript != null)
            {
                speedDoPlayer = playerScript.GetSpeed();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(speedDoPlayer < 0){
            collider.offset = new Vector2(-0.6f,0);
            
        }
        else if (speedDoPlayer > 0)
        {
            collider.offset = new Vector2(0.6f,0);

        }
    }

}

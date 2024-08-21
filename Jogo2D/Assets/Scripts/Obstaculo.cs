using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public Life heart;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Life>().ReceberDano();
            heart.vidaAtual --;
        }    
    }
}

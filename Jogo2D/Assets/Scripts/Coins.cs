using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    private AudioSource audio;

    public GameObject collected;

    public int Score;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            audio.Play();
            circle.enabled = false;
            collected.SetActive(true);
            GameController.instance.TotalScore += Score;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject, 0.25f);
        }
    }
}

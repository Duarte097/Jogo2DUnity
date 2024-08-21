using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life : MonoBehaviour
{
    public int vidaMaxima;
    public int vidaAtual;
     private AudioSource audio;
    public Image[] coracao;
    public Sprite cheio;
    private Animator anim;
    public Sprite vazio;
    void Start()
    {
        vidaAtual = vidaMaxima;
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
    }

    void HealthLogic()
    {
        for(int i = 0; i < coracao.Length; i++)
        {

            if(vidaAtual > vidaMaxima)
            {
                vidaAtual = vidaMaxima;
            }
            if(i < vidaAtual)
            {
                coracao[i].sprite = cheio;
            }
            else{
                coracao[i].sprite = vazio;
            }
            if(i < vidaMaxima)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }
    }

    public void ReceberDano()
    {
        vidaAtual -= 1;

        if(vidaAtual <= 0)
        {
            anim.SetBool("dead", true);
            audio.Play();
            Destroy(gameObject,1f);
        }
    }
}

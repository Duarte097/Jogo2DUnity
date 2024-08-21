using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndsScene : MonoBehaviour
{
    public string lvlName;
    public Text texto;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = GameController.instance.TotalScore;
        texto.text = "Total de Pontos: " + currentScore;

    }

    public void Continuar()
    {
        SceneManager.LoadScene(lvlName);
    }
}

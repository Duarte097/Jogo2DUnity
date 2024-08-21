using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string lvlName;
    public GameObject painelMenu;
    void Start()
    {
       Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Iniciar(){
        Debug.Log("esta passando por aqui");
        SceneManager.LoadScene(lvlName);
    }

    public void Sair()
    {
        Application.Quit();
    }

}

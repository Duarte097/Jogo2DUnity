using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPause : MonoBehaviour
{
    public string lvlName;

    public string menuPrincipal;
    public GameObject painelPause;

    void Start()
    {
        //Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            painelPause.SetActive(true);
        }
        
        
    }
    public void Restart(){
        SceneManager.LoadScene(lvlName);
        painelPause.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        painelPause.SetActive(false);
    }
    
    public void MenuPrincipal(){
        SceneManager.LoadScene(menuPrincipal);
    }
}

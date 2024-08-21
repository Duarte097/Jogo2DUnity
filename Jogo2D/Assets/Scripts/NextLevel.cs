using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string lvlName;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        int currentScore = GameController.instance.TotalScore;
        if (collision.gameObject.tag == "Player")
        {
            if(currentScore >=100)
            {
                SceneManager.LoadScene(lvlName);
            }
            else
            {
                // Do something else if TotalScore is not greater than 50
                Debug.Log("TotalScore is not greater than 50");
            }
        }
    }
}

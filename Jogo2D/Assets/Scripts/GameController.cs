using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int TotalScore;
    public Text scoreText;

    public GameObject player;
    public GameObject gameOver;
    public static GameController instance;


    public static int PassedScore;

    void Start()
    {
        instance = this;
    }

    private void Update() {
        if (player == null | !player)
        {
            GameController.instance.ShowGameOver();
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = TotalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void Menu(string menu)
    {
        SceneManager.LoadScene(menu);
    }
}

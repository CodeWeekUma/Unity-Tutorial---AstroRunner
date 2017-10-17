using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Lives;
    public GameObject Player;
    private int _lives;

    public GameObject EndPanel;

    private void Awake()
    {
        _lives = Lives.Length;
    }

    public void LifeLost()
    {
        _lives--;
        if (_lives >= 0)
            Lives[_lives].SetActive(false);
        else
            GameOver();
    }

    public void GameOver()
    {
        EndPanel.SetActive(true);
        Player.SetActive(false);
        Time.timeScale = 0; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

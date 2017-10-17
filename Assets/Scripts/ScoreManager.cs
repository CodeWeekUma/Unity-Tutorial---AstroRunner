using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    public Text ScoreText;

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        ScoreText.text = _score.ToString();
    }
}

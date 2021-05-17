using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkaterScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;

    public void AddScore(int points)
    {
        if (points > 0)
        {
            score += points;
            scoreText.text = "SCORE: " + score;
        }
    }

    public int Score
    {
        get { return score; }
    }
}

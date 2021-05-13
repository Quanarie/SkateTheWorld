using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkaterScore : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private int score;

    public void AddScore(int points)
    {
        if (points > 0)
        {
            score += points;
            scoreText.text = "Score: " + score;
        }
    }

    public int Score
    {
        get { return score; }
    }
}

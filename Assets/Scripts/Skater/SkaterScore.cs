using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkaterScore : MonoBehaviour
{
    private int score;

    public void AddScore(int points)
    {
        if (points > 0)
        {
            score += points;
        }
    }

    public int Score
    {
        get { return score; }
    }
}

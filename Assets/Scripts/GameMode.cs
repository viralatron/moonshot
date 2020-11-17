using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public int score, multiplier;

    private void Start()
    {
        score = 0;
        multiplier = 1;
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void AddMultiplier()
    {
        multiplier++;
    }
}

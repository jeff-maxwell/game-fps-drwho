using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{
    public static int currentHealth;
    public static int currentScore;
    public static bool GameIsPaused;
    public static bool IsDead;

    public static int LevelIteration = 1;

    public static void UpdateScore()
    {
        currentScore++;
    }

    public static void AddLevel()
    {
        LevelIteration++;
    }

}

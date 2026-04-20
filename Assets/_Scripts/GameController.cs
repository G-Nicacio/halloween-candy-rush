using System.Collections.Generic;
using UnityEngine;

public static class GameController
{
    public static int candies { get; private set; }
    public static int score { get; private set; }

    public static float globalTimer { get; private set; }
    public static float candyTimer { get; private set; }
    public static float survivalTime { get; private set; }

    public static float globalTimerMax { get; private set; }
    public static float candyTimerMax { get; private set; }

    public static int fee { get; private set; }

    public static bool gameOver { get; private set; }

    public static void Init()
    {
        candies = 0;
        score = 0;
        survivalTime = 0f;

        globalTimerMax = 30f;
        candyTimerMax = 20f;

        globalTimer = globalTimerMax;
        candyTimer = candyTimerMax;

        fee = 3;
        gameOver = false;
    }

    public static void UpdateTimers(float deltaTime)
    {
        if (gameOver) return;

        globalTimer -= deltaTime;
        candyTimer -= deltaTime;
        survivalTime += deltaTime;
    }

    public static bool IsCandyTimeOver()
    {
        return candyTimer <= 0f;
    }

    public static void ResetCandyTimer()
    {
        candyTimer = candyTimerMax;
    }

    public static bool IsGlobalTimeOver()
    {
        return globalTimer <= 0f;
    }

    public static void ProcessGlobalFee()
    {
        if (candies >= fee)
        {
            candies -= fee;
            score += 75;
            globalTimer = globalTimerMax;
        }
        else
        {
            gameOver = true;
        }
    }

    public static void CollectCandy()
    {
        candies += 1;
        score += 10;
    }

    public static void IncreaseDifficulty()
    {
        fee = 3 + (score / 75);

        candyTimerMax = Mathf.Max(8f, 20f - (score / 25f));
    }

    public static void ForceGameOver()
    {
        gameOver = true;
    }

    public static void LoseOneCandy()
    {
        if (candies > 0)
        {
            candies--;
        }
    }

    public static void ReduceCandyTimer(float seconds)
    {
        candyTimer -= seconds;

        if (candyTimer < 0f)
        {
            candyTimer = 0f;
        }
    }

    public static void ReduceGlobalTimer(float seconds)
    {
        globalTimer -= seconds;

        if (globalTimer < 0f)
        {
            globalTimer = 0f;
        }
    }
}
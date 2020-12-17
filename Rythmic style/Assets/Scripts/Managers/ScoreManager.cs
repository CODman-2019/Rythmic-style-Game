using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager score;

    public int multiplier;
    public int maxMultiplier;
    public int combo;
    public int currentScore;
    public int highScore;
    public int highCombo;
    public int[] scoreBoard = new int [10];

    private void Awake()
    {
        if(score == null)
        {
            score = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < scoreBoard.Length; x++)
        {
            scoreBoard[x] = 0;
        }

        currentScore = 0;
        multiplier = 1;
        maxMultiplier = 8;
        combo = 0;
    }

    public void Increase_Score(int addedScore)
    {
        currentScore += addedScore;
    }

    public void Increase_Multiplier()
    {
        multiplier *= 2;
        if (multiplier > maxMultiplier) multiplier = 8;
    }

    public void Increase_Combo()
    {
        combo++;
    }

    public void Check_HiScore()
    {
        if (currentScore > highScore) highScore = currentScore;
        AddScore();
    }

    public void Check_HiCombo()
    {
        if (combo > highCombo) highCombo = combo;
    }


    public void Reset_All()
    {
        Reset_Combo();
        Reset_Score();
        Reset_Multiplier();
    }

    public void Reset_Score()
    {
        currentScore = 0;
    }

    public void Reset_Combo()
    {
        combo = 0;
    }

    public void Reset_Multiplier()
    {
        multiplier = 1;
    }

    //scoreboardMethods
    public void AddScore()
    {
        for(int x = 0; x < scoreBoard.Length; x++)
        {
            if(scoreBoard[x] == 0)
            {
                scoreBoard[x] = currentScore;
                break;
            }
        }
    }

}

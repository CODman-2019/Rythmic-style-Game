using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject TitleScreen;
    public GameObject GameScreen;
    public GameObject PauseScreen;
    public GameObject ScoreBoardScreen;
    public GameObject VictoryScreen;

    public Text ScoreBoard;
    public Text Score;
    
    enum Screen {
        title, game, pause, scoreBoard, victory
    }

    Screen current;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        TitleScreen.SetActive(false);
        GameScreen.SetActive(false);
        PauseScreen.SetActive(false);
        ScoreBoardScreen.SetActive(false);
        VictoryScreen.SetActive(false);

        current = Screen.title;
    }

    void ChangeScreen()
    {
        switch (current)
        {
            case Screen.title:
                Time.timeScale = 1f;
                TitleScreen.SetActive(true);
                GameScreen.SetActive(false);
                PauseScreen.SetActive(false);
                ScoreBoardScreen.SetActive(false);
                VictoryScreen.SetActive(false);
                break;

            case Screen.game:
                Time.timeScale = 1f;
                TitleScreen.SetActive(false);
                GameScreen.SetActive(true);
                PauseScreen.SetActive(false);
                ScoreBoardScreen.SetActive(false);
                VictoryScreen.SetActive(false);
                break;

            case Screen.pause:
                Time.timeScale = 0f;
                TitleScreen.SetActive(false);
                GameScreen.SetActive(false);
                PauseScreen.SetActive(true);
                ScoreBoardScreen.SetActive(false);
                VictoryScreen.SetActive(false);
                break;

            case Screen.scoreBoard:
                Time.timeScale = 1f;
                TitleScreen.SetActive(false);
                GameScreen.SetActive(false);
                PauseScreen.SetActive(false);
                ScoreBoardScreen.SetActive(true);
                VictoryScreen.SetActive(false);
                break;

            case Screen.victory:
                Time.timeScale = 1f;
                TitleScreen.SetActive(false);
                GameScreen.SetActive(false);
                PauseScreen.SetActive(false);
                ScoreBoardScreen.SetActive(false);
                VictoryScreen.SetActive(true);
                break;
        }
    }

    public void ToTitle()
    {
        current = Screen.title;
        ChangeScreen();
    }

    public void ToGame()
    {
        current = Screen.game;
        ChangeScreen();
    }
    
    public void ToScoreBoard()
    {
        current = Screen.scoreBoard;
        ChangeScreen();
    }

    public void ToVictory()
    {
        current = Screen.victory;
        ChangeScreen();
    }

    public void UpdateScore()
    {
        Score.text = ScoreManager.score.currentScore.ToString();
    }

    public void ShowScoreBoard()
    {
        int[] bestScores = ScoreManager.score.scoreBoard;

        string scoreBoard = "SCORES: \n";
        for(int x = 0; x< bestScores.Length; x++)
        {
            scoreBoard += x++.ToString() + " " + bestScores[x] +"\n";
        }

        ScoreBoard.text = scoreBoard;
    }
}

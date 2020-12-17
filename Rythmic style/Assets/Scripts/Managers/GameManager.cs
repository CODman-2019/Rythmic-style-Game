using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager control;

    UIManager screens;
    ScoreManager tracker;
    EnemyManager army;


    public int levelDifficulty;
    public int levelCount;

    private void Awake()
    {
        if(control == null)
        {
            control = this;
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
        screens = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();
        tracker = GameObject.FindGameObjectWithTag("Score Manager").GetComponent<ScoreManager>();
        army = GameObject.FindGameObjectWithTag("Enemy Manager").GetComponent<EnemyManager>();

        screens.ToTitle();
        tracker.Reset_All();
        army.Reset();
    }

    public void SetGameDifficulty()
    {
    }

    void SaveScore()
    {
        tracker.Check_HiScore();
    }
    
    void ResetGame()
    {
        tracker.Reset_All();
        army.Reset();
    }

    void NextLevel()
    {
        army.NextRound();
    }

    void Victory()
    {

    }

}

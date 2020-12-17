using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    public GameObject[] spawnPoints;
    int enemiesAdded;
    public int maxEnemies;
    int startingMaxEnemies;

    public float enemytimerDecrease;
    public float enemyTimerMax;
    public float enemyTimerMin;
    float startingTimerMax;
    float startingTimerMin;

    bool spawnMore;

    // Start is called before the first frame update
    void Start()
    {
        enemiesAdded = 0;
        startingMaxEnemies = maxEnemies;
        startingTimerMax = enemyTimerMax;
        startingTimerMin = enemyTimerMin;
        
    }

    public void Reset()
    {
        maxEnemies = startingMaxEnemies;
        enemyTimerMax = startingTimerMax;
        enemyTimerMin = startingTimerMin;
    }

    public void NextRound()
    {
        enemyTimerMax -= enemytimerDecrease;
        enemyTimerMin -= enemytimerDecrease;
        maxEnemies += 5;
        enemiesAdded = 0;
    }

    public void SpawnEnemy()
    {
        if (spawnMore)
        {
            float timer = Random.Range(enemyTimerMin, enemyTimerMax);
            StartCoroutine(PlaceEnemy(timer));
        }
        
    }

    IEnumerator PlaceEnemy(float time)
    {
        yield return new WaitForSeconds(time);

        int enemyType = Random.Range(0, 1);

        if(enemyType == 0)
        {
            int spawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy1, spawnPoints[spawnPoint].transform);
            enemiesAdded++;
        }
        else if(enemyType == 1)
        {
            int spawnPointA = Random.Range(0, spawnPoints.Length);
            int spawnPointB = Random.Range(0, spawnPoints.Length);
            if(spawnPointB == spawnPointA) spawnPointB = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy2, spawnPoints[spawnPointA].transform);
            Instantiate(enemy2, spawnPoints[spawnPointB].transform);
            enemiesAdded++;
        }

        if (enemiesAdded < maxEnemies) SpawnEnemy();
        else
        {
            Stop();
        }
    }

    public void Stop()
    {
        spawnMore = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    int healthReset = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = healthReset;
    }


    public void ResetHealth()
    {
        health = healthReset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static private ScoreKeeper instance;

    static public ScoreKeeper Instance
    {
        get
        {
            return instance;
        }
    }

    private int currentScore = 0;

    void Awake()
    {
        instance = this;
    }

    public void OnPickup(int points)
    {
        currentScore += points;
    }
}

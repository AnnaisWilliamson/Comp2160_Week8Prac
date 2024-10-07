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

    private int currentScoreP1 = 0;
    public int CurrentScoreP1
    {
        get
        {
            return currentScoreP1;
        }
    }

    private int currentScoreP2 = 0;
    public int CurrentScoreP2
    {
        get
        {
            return currentScoreP2;
        }
    }

    void Awake()
    {
        instance = this;
    }

    public void OnPickup(int points, string player)
    {
        if (player.Contains("1"))
        {
            currentScoreP1 += points;
        }
        else if (player.Contains("2"))
        {
            currentScoreP2 += points;
        }
        
    }

}

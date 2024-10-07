using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    static private UIManager instance;
    static public UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("There is not UIManager in the scene.");
            }
            return instance;
        }
    }


    [SerializeField] private ScoreKeeper scoreKeeper;

    [SerializeField] private TextMeshProUGUI scoreTextP1;
    [SerializeField] private TextMeshProUGUI scoreTextP2;
    [SerializeField] private string scoreFormat = "Score: {0}";

    void Awake() 
    {
        if (instance != null)
        {
            // there is already a UIManager in the scene, destory this one
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        scoreTextP1.text = string.Format("P1 " + scoreFormat, ScoreKeeper.Instance.CurrentScoreP1);               
        scoreTextP2.text = string.Format("P2 " + scoreFormat, ScoreKeeper.Instance.CurrentScoreP2);               
    }
}

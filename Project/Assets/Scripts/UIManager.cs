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

    [SerializeField] private TextMeshProUGUI scoreText;
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
        scoreText.text = string.Format(scoreFormat, ScoreKeeper.Instance.CurrentScore);               
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private float playerLayer = 6;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            Destroy(gameObject);
            ScoreKeeper.Instance.OnPickup(points);
        }
    }
}

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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            Debug.Log("collision with player");
            Destroy(gameObject);
            ScoreKeeper.Instance.OnPickup(points);
        }
    }
}

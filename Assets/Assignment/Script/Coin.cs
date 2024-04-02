using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public static int coinCount;

    public Coin()
    {
        coinCount++;
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // add 1 point to score and destroy object 

        CoinManager.addScore(1);
        Destroy(gameObject);
    }
}

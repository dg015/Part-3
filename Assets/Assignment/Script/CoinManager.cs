using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinManager : MonoBehaviour
{

    [SerializeField]public static int score;
    [SerializeField]public static int MaxScore = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    
    }


    private void update ()
    {
        Debug.Log(score);
        WinGame();
        Debug.Log(Coin.coinCount);
    }
    public static void addScore(int value)
    {
        score+= value;
        Debug.Log(score);
    }

    public static void WinGame()
    {
        if (score >= Coin.coinCount)
        {
            Debug.Log("you won the game");
        }

    }


    public static void resetScore()
    {
        score = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

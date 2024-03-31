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
    [SerializeField] private GameObject scene;
    // Start is called before the first frame update
    void Start()
    {
        
    
    }


    private void Update()
    {
       // Debug.Log(score);
        WinGame();
        ScoreChecker();
        //Debug.Log(Coin.coinCount);
    }
    public static void addScore(int value)
    {
        score+= value;
        Debug.Log(score);
    }

    public static void WinGame()
    {
        if (score == 8)
        {
            Debug.Log("you won the game");
        }

    }

    private void ScoreChecker()
    {
        if (score == 8)
        {
            scene.SendMessage("gameOverScreen");
        }
    
    
    }



    public static void resetScore()
    {
        score = 0;
    }
}

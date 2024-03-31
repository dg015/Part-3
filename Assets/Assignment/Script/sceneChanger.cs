using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Assingment");
    }

    public void gameOverScreen()
    {
        CoinManager.resetScore();
        SceneManager.LoadScene("GameOverScreen");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    [SerializeField] private Timer tm;
    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        //Timer tm = GameObject.Find("TIme manager").GetComponent<Timer>();
        text = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        //Timer tm = gameObject.GetComponent<Timer>();
        showRecord();
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("Assingment");
    }

    public void gameOverScreen()
    {
        PlayerPrefs.SetFloat("currenTtime", tm.time);
        float highestScore = PlayerPrefs.GetFloat("time");
        if (tm.time < highestScore)
        {
            PlayerPrefs.SetFloat("time", tm.time);
        }
        Timer.running = false;
        CoinManager.resetScore();
        SceneManager.LoadScene("GameOverScreen");
    }

    public void showRecord()
    {
        float currentTime = PlayerPrefs.GetFloat("currentTime");
        float time = PlayerPrefs.GetFloat("time");
        text.text ="Time: " + string.Format("{0:0.00}", currentTime) + "<br>Fastest time: " + string.Format("{0:0.00}", time); 


    }

}

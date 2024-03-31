using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Timer : MonoBehaviour
{
    public static bool running = true;
    public float time;
    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer();   
    }

    private void timer()
    {
        if ( running)
        {
            time += Time.deltaTime;
            text.text =  "timer:" + string.Format("{0:0.00}",time);
        }



    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class DisapearingPlataform : Plataforms
{

    
    [SerializeField] private float time;
    [SerializeField] private float maxTime;
    [SerializeField] private bool disapearTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void timer(Boolean TimeUp)
    {
        if (time > maxTime)
        {
            time -= Time.deltaTime;
            TimeUp = true;
            Debug.Log("deducting");
        }
        if (time <= 0)
        {
            time += Time.deltaTime;
            TimeUp = false;
            Debug.Log("adding ");
        }
    }


    private void disapear()
    {
        if (disapearTime == true)
        {
            boxCollider.enabled = false;
            sprite.enabled = false; 
        }
        else if ( disapearTime == false ) 
        {
            boxCollider.enabled = true;
            sprite.enabled = true;

        }


    }


    // Update is called once per frame
    void Update()
    {
        disapear();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        timer(disapearTime);
        sprite.color = Color.red;
    }

  
    public override void OnCollisionExit2D(Collision2D collision)
    {
        time = 0;
        sprite.color = Color.blue;

    }

}

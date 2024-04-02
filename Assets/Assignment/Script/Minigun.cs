using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Minigun : Gun
{
    [SerializeField] private float Overheat;
    [SerializeField] private float coolingdownTime;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private bool readyToFire = true;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //call function to look mouse direction
        lookat();
        //check if plaeyr is pressing the mouse button and can fire
        if (Input.GetMouseButton(0) && readyToFire)
        {
           
            StartCoroutine(shootingCycle());
        }
        else
        {
            coolingDown();
        }
        
    }

    private void overhearting()
    {
        // if player is with the mouse down increment the overheat varaible by the second
        if ( Input.GetMouseButton (0)) 
        {
            Overheat += Time.deltaTime;
        }
        
        else if (Overheat == 2.5)
        {
            // if its 2.5 make it unable to fire
            readyToFire = false;
        }
        if (Overheat < 2.5)
        {
            //if its less then 2.5 make it able to fire
            readyToFire = true;
        }
    }
    private void coolingDown()
    {
        
        if (Overheat > 0)
        {
            //if its higher then 0 deduct overheat by the second
            Overheat -= Time.deltaTime;
        }

    }



    protected override void nockback()
    {
        player.AddForce(-1 * direction * explosionStrenght, ForceMode2D.Force);
    }
    private IEnumerator shootingCycle()
    {
        
        nockback();
        overhearting();
        readyToFire = false;
        if (Overheat >= 2.5)
        {
            yield return new WaitForSeconds(5);
        }

        Debug.Log("I'me here");
        readyToFire = true;


    }

}

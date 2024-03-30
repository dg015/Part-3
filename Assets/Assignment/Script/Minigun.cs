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
        /*
        if (Input.GetMouseButton(0)) 
        {
            overhearting();
            nockback();
        }
        else
        {
            coolingDown();
        }
        */
        lookat();
        
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
        if ( Input.GetMouseButton (0)) 
        {
            Overheat += Time.deltaTime;
        }
        
        else if (Overheat == 6)
        {
            readyToFire = false;
        }
        if (Overheat < 6)
        {
            readyToFire = true;
        }
    }
    private void coolingDown()
    {
        
        if (Overheat > 0)
        {
            Overheat -= Time.deltaTime;
        }

    }



    protected override void nockback()
    {
        player.AddForce(-1 * direction * explosionStrenght, ForceMode2D.Force);
        shooot();
    }
    private IEnumerator shootingCycle()
    {
        
        nockback();
        overhearting();
        readyToFire = false;
        if (Overheat >= 6)
        {
            yield return new WaitForSeconds(5);
        }

        Debug.Log("I'me here");
        readyToFire = true;


    }

}

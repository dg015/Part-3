using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSwitch : MonoBehaviour
{

    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject sniper;
    [SerializeField] private GameObject mingun;
    [SerializeField] private int currentGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Switch();
        holdingGun();
    }

    private void holdingGun()
    {
        //set every gun index to what weapon should be active
        if (currentGun ==1)
        {
            gun.SetActive(true);
            sniper.SetActive(false);
            mingun.SetActive(false);
        }
        else if( currentGun ==2)
        {
            gun.SetActive(false);
            sniper.SetActive(true);
            mingun.SetActive(false);

        }
        else if (currentGun ==3)
        {
            gun.SetActive(false);
            sniper.SetActive(false);
            mingun.SetActive(true);
        }



    }

    private void Switch()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f )
        {
            currentGun ++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentGun++;
        }
        //if it goes out of bounds just loop around
        if( currentGun > 3)
        {
            currentGun = 1;
        }
        if (currentGun <1)
        {
            currentGun = 3;
        }

    }
}

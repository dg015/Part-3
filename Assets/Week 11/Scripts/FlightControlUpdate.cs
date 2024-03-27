using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class FlightControlUpdate : MonoBehaviour
{
    public GameObject missile;
    public float speed = 5;
    public float turningSpeedReduction = 0.75f;
    public bool action;
    public float time;
    public float limit;
    public float ready;

    public bool Running;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (Running)
       {
            timer();
            RunLeg(distance);

       }
    }
    public void MakeTurn(float turn)
    {
        if (action == false)
        {
            time = 0;
            action = true;
            Turn(turn);
        }
        
    }

    public void MoveForwards(float length)
    {
        if (action == false)
        {
            Running = true;
            action = true;
            distance = length;
        }
        
    }

    public void timer()
    {
        time += Time.deltaTime;
 
    }


    public void RunLeg(float legLength)
    {
   
        if  (time < legLength)
        {
            missile.transform.Translate(transform.right * speed * Time.deltaTime);
            
        }
        else
        {
            distance = 0;
        }
        Running = false;
        action = false;
    }

    public void Turn(float turn)
    {
        float interpolation = 0;
        Quaternion currentHeading = missile.transform.rotation;
        Quaternion newHeading = currentHeading * Quaternion.Euler(0, 0, turn);
        if  (interpolation < 1)
        {
            interpolation += Time.deltaTime;
            missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
            missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
            
        }

        action = false;
    }


}

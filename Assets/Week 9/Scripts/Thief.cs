using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject KnifePrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public float dashSpeed = 7;
    public float dashTime = 2;
    Coroutine dashing;

    public override ChestType CanOpen()
    {
        return ChestType.Thief;

    }

    protected override void Attack()
    { 
        if (dashing != null)
        {
            StopCoroutine(dashing); 
        }
      dashing =  StartCoroutine(Dash());
    }
    /*
    void dash()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            isDashing = false;
            Instantiate(KnifePrefab, spawnPoint.position, spawnPoint.rotation);
            Invoke("SecondKnife", 0.5f);

        }

    }
    */

    IEnumerator Dash()
    {
        
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // rb.position = destination;
        speed = 7;
        while (speed > 3)
        {
            yield return null;
        }
        base.Attack();
        yield return new WaitForSeconds(0.1f);
        Instantiate(KnifePrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(KnifePrefab, spawnPoint.position, spawnPoint2.rotation);
        
    }
  
    
    /*
    protected override void Update()
    {
        base.Update();
        if (isDashing)
        {
            dash();
        }    
    }
    */



    public override string ToString()
    {
        return "bob bobson";

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject KnifePrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    

    public override ChestType CanOpen()
    {
        return ChestType.Thief;

    }

    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();
        Instantiate(KnifePrefab, spawnPoint.position, spawnPoint.rotation);
        Invoke("SecondKnife", 0.5f);

        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        
    }
    private void SecondKnife()
    {
        Instantiate(KnifePrefab, spawnPoint.position, spawnPoint2.rotation);


    }

}

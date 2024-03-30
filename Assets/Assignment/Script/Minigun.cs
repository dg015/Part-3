using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookat();
        nockback();
    }

    protected override void nockback()
    {
        if (Input.GetMouseButton(0))
        {
            player.AddForce(-1 * direction * explosionStrenght, ForceMode2D.Force);
            shooot();
        }
    }




}

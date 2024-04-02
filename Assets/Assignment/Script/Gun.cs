using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Transform barrel;
    [SerializeField] protected float explosionStrenght;
    [SerializeField] protected float offset;
    [SerializeField] protected Rigidbody2D player;
    [SerializeField] protected Vector2 direction;
    [SerializeField] protected GameObject projectile;
    

    // Update is called once per frame
    void Update()
    {
        //call functions
        lookat();
        nockback();
    }


    protected void lookat()
    {
        // find the mouse position 
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        //get the mouse direction and find the direction to it usingh the atan method
         direction = new Vector2(mouse.x - transform.position.x, mouse.y - transform.position.y);
        float ang  = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        //subrtract by 90 to make the angle correct
        ang = ang - 90;
        //set the direction as the angle 
        transform.rotation = Quaternion.Euler(0, 0, ang * -1);
    }


    protected virtual void nockback ()
    {
        
        if (Input.GetMouseButtonUp(0)) 
        {
            //apply force on the opossite direction the player is aiming
            player.AddForce(-1 * direction * explosionStrenght, ForceMode2D.Force);
            shooot();
        }
    }

    protected void shooot()
    {
        // insntatiate bulelte

        Instantiate(projectile, barrel.position,barrel.rotation);
    }
}

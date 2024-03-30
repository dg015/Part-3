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
    [SerializeField] protected float damage = 15;
    
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


    protected void lookat()
    {
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);

         direction = new Vector2(mouse.x - transform.position.x, mouse.y - transform.position.y);
        float ang  = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        ang = ang - 90;
        transform.rotation = Quaternion.Euler(0, 0, ang * -1);
    }


    protected virtual void nockback ()
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            player.AddForce(-1 * direction * explosionStrenght, ForceMode2D.Force);
            shooot();
        }
    }

    protected void shooot()
    {
        Instantiate(projectile, barrel.position,barrel.rotation);
    }
}

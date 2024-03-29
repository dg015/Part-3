using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Plataforms : MonoBehaviour
{

    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

 

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        sprite.color = Color.gray;
        

    }
    public virtual void OnCollisionExit2D(Collision2D collision)
    {
        sprite.color = Color.white;
    }


}

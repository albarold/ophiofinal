using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
    public GameObject Ophio;
    public Rigidbody2D RbMineur;
    public float Speed;
    private bool move;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RbMineur.velocity = ((Ophio.transform.position - transform.position)*Speed);
            move = true;
        }

        if (!move)
        {
            Movement();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RbMineur.velocity = Vector2.zero;
        move = false;
    }

    void Movement()
    {
        //deplacement vers ophio
  
        
    }


}

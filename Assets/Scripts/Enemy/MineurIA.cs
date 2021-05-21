using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MineurIA : MonoBehaviour
{
    //public int life;
    public float speed;
    public bool Distance;
    public Rigidbody2D RbMineur;
    public Transform target;
    public float stop;
    public float timeStop;


    // Start is called before the first frame update
    void Start()
    {
        RbMineur = gameObject.GetComponent<Rigidbody2D>();

    }
    
    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;
        Distance = GetComponent<MovementIA>().InDistance;

        if (Distance)
        {
            RbMineur.velocity = ((target.transform.position - transform.position) * speed);
            GetComponent<MovementIA>().enabled = false;
        }
        else
        {
            GetComponent<MovementIA>().enabled = true;
        }   
        if (stop > timeStop)
        {
            Distance = true;
        }

    }

    private void OnCollision2D(Collision collision)
    {
        if (collision.gameObject.tag == "Mur")
        {
            RbMineur.velocity = Vector3.zero;
            Distance = false;
            stop += Time.deltaTime;
        }
        if (collision.gameObject.tag == "Player")
        {
            RbMineur.velocity = Vector3.zero;
            Distance = false;
            stop += Time.deltaTime;

        }
        if (collision.gameObject.tag == "Nectar")
        {
            RbMineur.velocity = Vector3.zero;
            Distance = false;
            stop += Time.deltaTime;
        }
        if (collision.gameObject.tag == "Insecte1")
        {
            RbMineur.velocity = Vector3.zero;
            Distance = false;
            stop += Time.deltaTime;
        }
        if (collision.gameObject.tag == "Insecte2")
        {
            RbMineur.velocity = Vector3.zero;
            Distance = false;
            stop += Time.deltaTime;
        }
        if (collision.gameObject.tag == "Insecte3")
        {
            RbMineur.velocity = Vector3.zero;
            Distance = false;
            stop += Time.deltaTime;
        }
        if (collision.gameObject.tag == "Mort1")
        {
            RbMineur.velocity = Vector3.zero;
            Distance = false;
            stop += Time.deltaTime;
        }
        if (collision.gameObject.tag == "Mort2")
        {
            RbMineur.velocity = Vector3.zero;
            Distance = false;
            stop += Time.deltaTime;
        }
        if (collision.gameObject.tag == "Mort3")
        {
            RbMineur.velocity = Vector3.zero;
            Distance = false;
            stop += Time.deltaTime;
        }

    }
}

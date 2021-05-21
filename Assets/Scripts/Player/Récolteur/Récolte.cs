﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Récolte : MonoBehaviour
{
    public int Degats;
    public bool Zone, Attaque;
    private Vector3 movement;
    public int Elife;
    public int Edegat;
    public GameObject AttackObject;
    public float DureAttaque;
    public float tempsAnim;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        MoveCollider();
        if (Zone)
        {
            if (Input.GetButton("Attaque"))
            {
                Attaque = true;
            }
        }


        if (Attaque && Zone)
        {
            DureAttaque += Time.deltaTime;
            if (DureAttaque >= tempsAnim)
            {
                Edegat = Elife - Degats;
                Attaque = false;
                DureAttaque = 0;
            }
        }
        if (Zone == false && Attaque == true)
        {
            DureAttaque += Time.deltaTime;
            if (DureAttaque >= tempsAnim)
            {
                Edegat = Elife - Degats;
                Attaque = false;
                DureAttaque = 0;
            }
        }


    }

    public void MoveCollider()
    {

        if (movement.x > 0)
        {
            AttackObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (movement.x < 0)
        {
            AttackObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (movement.y > 0)
        {
            AttackObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (movement.y < 0)
        {
            AttackObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Insecte1"))
        {
            Zone = true;
            Elife = collision.GetComponentInChildren<HealthBar_Behavior>().E_Life;
            Edegat = Elife;
        }

        else if (collision.gameObject.CompareTag("Insecte2"))
        {
            Zone = true;
            Elife = collision.GetComponentInChildren<HealthBar_Behavior>().E_Life;
            Edegat = Elife;
        }
        else if (collision.gameObject.CompareTag("Insecte3"))
        {
            Zone = true;
            Elife = collision.GetComponentInChildren<HealthBar_Behavior>().E_Life;
            Edegat = Elife;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Insecte1"))
        {
            collision.GetComponentInChildren<HealthBar_Behavior>().E_Life = Edegat;

        }

        else if (collision.gameObject.CompareTag("Insecte2"))
        {
            collision.GetComponentInChildren<HealthBar_Behavior>().E_Life = Edegat;

        }
        else if (collision.gameObject.CompareTag("Insecte3"))
        {
            collision.GetComponentInChildren<HealthBar_Behavior>().E_Life = Edegat;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Insecte1"))
            Zone = false;
        if (collision.gameObject.CompareTag("Insecte2"))
            Zone = false;
        if (collision.gameObject.CompareTag("Insecte3"))
            Zone = false;
    }
}

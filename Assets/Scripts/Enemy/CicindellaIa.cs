﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CicindellaIa : MonoBehaviour
{ 

    private GameObject Player;
    public float MoveSpeed;
    public float DetectionDistance, ChargeDist;
    public float ChargeSpeed;
    public bool Charge;
    public int Degats, DegatsCharge;
    public float ChargementCharge;

    public float CoolDown;

    public float KnockbackPower, KnockBackDuration;
    private float Timer;
    private float chargement = 0;
    private Vector2 MovementDash;
    private void Start()
    {
        Player= GameObject.FindWithTag("Player");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectionDistance);
        Gizmos.DrawWireSphere(transform.position, ChargeDist);
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (Charge)
        {
            chargement += Time.deltaTime;
            if (chargement < ChargementCharge)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = (MovementDash) * ChargeSpeed;
            }
        }

        if (Vector3.Distance(transform.position, Player.transform.position) <= ChargeDist && Timer>= CoolDown &&!Charge)
        {
            MovementDash = (Player.transform.position - transform.position).normalized;
            Charge = true;
        }
        else if (Vector3.Distance(transform.position, Player.transform.position) <= DetectionDistance && !Charge)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != Player)
        {
            Charge = false;
            Timer = 0;
            chargement = 0;
        }
        else
        {
            
            if (Charge)
            {
                Player.GetComponent<Vie_Hud>().TakeDamage(DegatsCharge);
                StartCoroutine(Movement.instance.KnockBack(KnockBackDuration, KnockbackPower, this.transform));

            }
            else
            {
                Player.GetComponent<Vie_Hud>().TakeDamage(Degats);
                StartCoroutine(Movement.instance.KnockBack(KnockBackDuration, KnockbackPower, this.transform));
            }
            
        }
        
    }
}

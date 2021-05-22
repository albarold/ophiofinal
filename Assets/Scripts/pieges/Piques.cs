using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piques : MonoBehaviour
{
    private GameObject Player;
    public int Degats;
    public float KnockbackDuration, KnockbackPower;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject==Player)
        {
            Player.GetComponent<Vie_Hud>().TakeDamage(Degats);
            StartCoroutine(Movement.instance.KnockBack(KnockbackDuration, KnockbackPower, this.transform));
        }
    }
}

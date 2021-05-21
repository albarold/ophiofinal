using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nectar_Ground : MonoBehaviour
{
    private bool Near_Nectar;
    public Nectar_Manager Nectar_Manager;
    public int Nectar_Amount;
    public int GainVie;
    public GameObject Player;

    void Update()
    {
        if (Near_Nectar)
        {
            Nectar_Manager.Nectar = Nectar_Manager.Nectar + Nectar_Amount;
            Destroy(gameObject);
            Player.GetComponent<Vie_Hud>().TakeDamage(-GainVie);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Near_Nectar = true;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        Near_Nectar = false;
    }
}

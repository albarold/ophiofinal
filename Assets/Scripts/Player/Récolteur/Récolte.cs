using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Récolte : MonoBehaviour
{
    public int Degats;
    public bool Attaque;
    public int Elife;
    public int Edegat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Insecte1"))
        {
            Attaque = true;
            Elife = collision.GetComponentInChildren<HealthBar_Behavior>().E_Life;
            Edegat = Elife;
        }

        else if (collision.gameObject.CompareTag("Insecte2"))
        {
            Attaque = true;
            Elife = collision.GetComponentInChildren<HealthBar_Behavior>().E_Life;
            Edegat = Elife;
        }
        else if (collision.gameObject.CompareTag("Insecte3"))
        {
            Attaque = true;
            Elife = collision.GetComponentInChildren<HealthBar_Behavior>().E_Life;
            Edegat = Elife;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Insecte1"))
        {
            collision.GetComponentInChildren<HealthBar_Behavior>().E_Life = Edegat;
            if (Attaque && Input.GetButton("Attaque"))
            {
                Debug.Log("Oof");
                Edegat = Elife - Degats;
            }


        }

        else if (collision.gameObject.CompareTag("Insecte2"))
        {
            collision.GetComponentInChildren<HealthBar_Behavior>().E_Life = Edegat;
            if (Attaque && Input.GetButton("Attaque"))
            {
                Debug.Log("Oof");
                Edegat = Elife - Degats;
            }
        }
        else if (collision.gameObject.CompareTag("Insecte3"))
        {
            collision.GetComponentInChildren<HealthBar_Behavior>().E_Life = Edegat;
            if (Attaque && Input.GetButton("Attaque"))
            {
                Debug.Log("Oof");
                Edegat = Elife - Degats;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Insecte1"))
            Attaque = false;
        if (collision.gameObject.CompareTag("Insecte2"))
            Attaque = false;
        if (collision.gameObject.CompareTag("Insecte3"))
            Attaque = false;
    }
}

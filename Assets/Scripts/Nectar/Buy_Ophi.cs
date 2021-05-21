using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Ophi : MonoBehaviour
{
    
    private bool Near_Hole;
    public Parasitage Parasitage;
    public Nectar_Manager Nectar_Manager;
    public int Price;
    public int OphiNb;
    public float Para_CoolDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Near_Hole && Input.GetKeyDown(KeyCode.E) && Nectar_Manager.Nectar >= Price)
        {
            Debug.Log("Buy");
            if (OphiNb==1)
            {
                Ophi1();
            }

            if (OphiNb == 2)
            {
                Ophi2();
            }

            if (OphiNb == 3)
            {
                Ophi3();
            }

            Nectar_Manager.Nectar= Nectar_Manager.Nectar-Price;
        }
    }

    void Ophi1()
    {
        Parasitage.TempsCorrupt = Para_CoolDown;//valeur de cooldown de parasitage actuel = celle choisi
    }
    void Ophi2()//REVIVE
    {

    }
    void Ophi3()//+de pv
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Near_Hole = true;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        Near_Hole = false;
    }
}

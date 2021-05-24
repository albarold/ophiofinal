using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Ophi : MonoBehaviour
{

    public bool Available = true;
    public bool Near_Hole;

    public GameObject Light;
    public Parasitage Parasitage;
    public Nectar_Manager Nectar_Manager;
    public Vie_Hud Vie;
    public int Price;
    public int OphiNb;

    public float Para_CoolDown;
    public int ReviveNbPv;
    public int NbCoeurBonus;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Available)
        {
            switch (OphiNb)
            {
                case 1:
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                    break;
                case 2:
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    break;
                case 3:
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(true);
                    break;
            }
        }
        if (Near_Hole && Input.GetButtonDown("Sprint") && Nectar_Manager.Nectar >= Price && Available)
        {
            Light.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);

            Debug.Log("Buy");
            switch (OphiNb)
            {
                case 1:
                    Ophi1();
                    break;
                case 2:
                    Ophi2();
                    break;
                case 3:
                    Ophi3();
                    break;
            }
            Available = false;
            Nectar_Manager.Nectar= Nectar_Manager.Nectar-Price;
        }
    }

    void Ophi1()
    {
        Parasitage.TempsCorrupt = Para_CoolDown;//valeur de cooldown de parasitage actuel = celle choisi
    }
    void Ophi2()//REVIVE
    {
        Vie.ReviveLife = ReviveNbPv;
        Vie.Revive = true;
        
    }
    void Ophi3()//+de pv
    {
        Vie.NumOfHearts += NbCoeurBonus;
        Vie.TakeDamage(-Vie.NumOfHearts);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public GameObject Player, Ophio, Récolteur, Mineur, Catapulteur;
    public int level;
    public static Parasitage type_;


    // Update is called once per frame
    void Update()
    {
        level = Parasitage.instance.Type;
        if (level == 0)
        {
            Player.GetComponent<Parasitage>().enabled = true;
            Player.GetComponent<Récolte>().enabled = false;
            Player.GetComponent<ChargeRework>().enabled = false;
            Player.GetComponent<Catapulteur_mech>().enabled = false;
            Ophio.gameObject.SetActive(true);
            Récolteur.gameObject.SetActive(false);
            Mineur.gameObject.SetActive(false);
            Catapulteur.gameObject.SetActive(false);
        }
        if (level == 1)
        {
            Player.GetComponent<Parasitage>().enabled = false;
            Player.GetComponent<Récolte>().enabled = true;
            Player.GetComponent<ChargeRework>().enabled = false;
            Player.GetComponent<Catapulteur_mech>().enabled = false;
            Ophio.gameObject.SetActive(false);
            Récolteur.gameObject.SetActive(true);
            Mineur.gameObject.SetActive(false);
            Catapulteur.gameObject.SetActive(false);
        }
        if (level == 2)
        {
            Player.GetComponent<Parasitage>().enabled = false;
            Player.GetComponent<Récolte>().enabled = false;
            Player.GetComponent<ChargeRework>().enabled = true;
            Player.GetComponent<Catapulteur_mech>().enabled = false;
            Ophio.gameObject.SetActive(false);
            Récolteur.gameObject.SetActive(false);
            Mineur.gameObject.SetActive(true);
            Catapulteur.gameObject.SetActive(false);
        }
        if (level == 3)
        {
            Player.GetComponent<Parasitage>().enabled = false;
            Player.GetComponent<Récolte>().enabled = false;
            Player.GetComponent<ChargeRework>().enabled = false;
            Player.GetComponent<Catapulteur_mech>().enabled = true;
            Ophio.gameObject.SetActive(false);
            Récolteur.gameObject.SetActive(false);
            Mineur.gameObject.SetActive(false);
            Catapulteur.gameObject.SetActive(true);
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            level = 0;
            Parasitage.instance.Type = 0;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour
{
    public float Plife;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        Plife = Player.GetComponentInChildren<Vie_Hud>().Life;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Insecte1")
        {
            Plife = Plife - 1;
        }
        if (collision.gameObject.tag == "Insecte2")
        {
            Plife = Plife - 1;
        }
        if (collision.gameObject.tag == "Insecte3")
        {
            Plife = Plife - 1;
        }

    }
}

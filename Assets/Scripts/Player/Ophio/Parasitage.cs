using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasitage : MonoBehaviour
{
    public GameObject Player;
    public int Type;
    public float para;
    public int Elife;
    public static Parasitage instance;
    public bool parasiting;
    public int Plife;
    public float TempsCorrupt;
    public float CoeurCorrupt;

    
    // Start is called before the first frame update
    void Start()
    {
        Type = 0;
        Plife = Player.GetComponentInChildren<Vie_Hud>().Life;
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (parasiting)
        {
            if (Input.GetButton("Parasitage"))
            {
                para += Time.deltaTime;                
            }
        }

        if(para >= TempsCorrupt)
        {
            CoeurCorrupt = CoeurCorrupt + 1;
            para = 0;
        }
        if (Input.GetButtonUp("Parasitage") && para < TempsCorrupt)
        {
            para = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
        if (collision.gameObject.CompareTag("Insecte1"))
        {
            parasiting = true;
            CoeurCorrupt = 0;
            if (collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt != CoeurCorrupt && collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt > 0)
                CoeurCorrupt = collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt;

            Elife = collision.GetComponentInChildren<HealthBar_Behavior>().E_Life;

            


        }

        else if (collision.gameObject.CompareTag("Insecte2"))
        {
            parasiting = true;
            CoeurCorrupt = 0;
            if (collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt != CoeurCorrupt && collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt > 0)
                CoeurCorrupt = collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt;
            
            Elife = collision.GetComponentInChildren<HealthBar_Behavior>().E_Life;
            
            
        }
        else if (collision.gameObject.CompareTag("Insecte3"))
        {
            parasiting = true;
            CoeurCorrupt = 0;
            if (collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt != CoeurCorrupt && collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt > 0)
                CoeurCorrupt = collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt;
            
            Elife = collision.GetComponentInChildren<HealthBar_Behavior>().E_Life;


        }
           
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       

        if (collision.gameObject.CompareTag("Insecte1"))
        {
            
            collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt = CoeurCorrupt;
            if (CoeurCorrupt >= Elife)
            {
                Debug.Log("AddLife");
                Type = 1;
                Destroy(collision.gameObject);
                Player.GetComponentInChildren<Vie_Hud>().Life = Plife + Elife; 
            }
        }
            
        else if (collision.gameObject.CompareTag("Insecte2"))
        {
            
            collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt = CoeurCorrupt;
            if (CoeurCorrupt >= Elife)
            {
                Type = 2;
                Destroy(collision.gameObject);
                Player.GetComponentInChildren<Vie_Hud>().Life = Plife + Elife;
            }
        }
           
        else if (collision.gameObject.CompareTag("Insecte3"))
        {
            
            collision.GetComponentInChildren<HealthBar_Behavior>().Corrupt = CoeurCorrupt;
            if (CoeurCorrupt >= Elife)
            {
                Type = 3;
                Destroy(collision.gameObject);
                Player.GetComponentInChildren<Vie_Hud>().Life = Plife + Elife;
            }
        }


        if (collision.gameObject.CompareTag("Mort1"))
        {
            parasiting = true;
            if (Input.GetButton("Parasitage"))
            {
                Type = 1;
                Destroy(collision.gameObject);
            }

        }

        else if (collision.gameObject.CompareTag("Mort2"))
        {
            parasiting = true;
            if (Input.GetButton("Parasitage"))
            {
                Type = 2;
                Destroy(collision.gameObject);
            }

        }

        else if (collision.gameObject.CompareTag("Mort3"))
        {
            parasiting = true;
            if (Input.GetButton("Parasitage"))
            {
                Type = 3;
                Destroy(collision.gameObject);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Insecte1"))
        {
            parasiting = false;
        }
        if (collision.gameObject.CompareTag("Insecte2"))
        {
            parasiting = false;
        }
        if (collision.gameObject.CompareTag("Insecte3"))
        {
            parasiting = false;
        }
        para = 0;
        
    }
    
}




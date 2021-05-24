using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterrupteurMort : MonoBehaviour
{
    public int level;

    public GameObject anim, ouverte;
    public bool Parasité;
    public bool Depara;
    public bool Ouvert;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level = Parasitage.instance.Type;

        if (Depara && Parasité)
        {
            Ouvert = true;
            
        }
        if (Ouvert)
        {
            ouverte.gameObject.SetActive(false);
            anim.gameObject.SetActive(true);
        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (level == 0)
            {
                Depara = true;
            }
            if (level > 0)
            {
                Parasité = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (level == 0)
            {
                Depara = false;
            }
            if (level > 0)
            {
                Parasité = false;
            }
        }
    }
}

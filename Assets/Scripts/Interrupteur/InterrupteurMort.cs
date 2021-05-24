using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterrupteurMort : MonoBehaviour
{
    public int level;


    public bool Parasité;
    public bool Depara;
    public SpriteRenderer Interrupt;
    public bool Ouvert;
    public Animation Fermer;
    // Start is called before the first frame update
    void Start()
    {
        Fermer = gameObject.GetComponent<Animation>();
        Fermer["Anim_Interrupteur"].layer = 123;
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
            Debug.Log("Anim");
            Fermer.Play();
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

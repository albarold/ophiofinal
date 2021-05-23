using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterrupteurMort : MonoBehaviour
{

    public bool Active;
    public bool Rayon;

    public Image Interrupt;
    public Sprite Ouvert;
    public Sprite Fermer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rayon)
            Active = false;


        if(Active == false)
        {
            Interrupt.sprite = Ouvert;
        }
        if (Active)
        {
            Interrupt.sprite = Fermer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rayon = true;
        }

        if (collision.gameObject.CompareTag("Mort1") && !Rayon)
        {
            Active = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Mort2") && !Rayon)
        {
            Active = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Mort3") && !Rayon)
        {
            Active = true;
            Destroy(collision.gameObject);
        }
    }
}

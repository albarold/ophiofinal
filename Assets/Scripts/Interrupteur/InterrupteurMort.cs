using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterrupteurMort : MonoBehaviour
{

    public bool Active;
    public bool Rayon;
    public Transform Mort;
    public SpriteRenderer Interrupt;
    public Sprite Ouvert;
    public Sprite Fermer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Active == false)
        {
            Interrupt.sprite = Ouvert;
        }
        else if (Active)
        {
            Interrupt.sprite = Fermer;
        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rayon = true;
        }
        if (collision.gameObject.CompareTag("Mort1"))
        {
            Debug.Log("Collision");
            Active = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Mort2"))
        {
            Debug.Log("Collision");
            Active = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Mort3"))
        {
            Debug.Log("Collision");
            Active = true;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rayon = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mort1"))
        {
            Debug.Log("Collision");
            Active = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Mort2"))
        {
            Debug.Log("Collision");
            Active = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Mort3"))
        {
            Debug.Log("Collision");
            Active = true;
            Destroy(collision.gameObject);
        }
    }

}

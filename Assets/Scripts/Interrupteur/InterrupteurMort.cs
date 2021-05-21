using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrupteurMort : MonoBehaviour
{

    public bool Active;
    public bool Rayon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rayon)
            Active = false;
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

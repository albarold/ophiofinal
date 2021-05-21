using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InArea_Dead : MonoBehaviour
{
    public bool Enemy_inArea = false;
    public GameObject Cultivateur;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Cultivateurs") || collider.CompareTag("Player"))
        {
            Enemy_inArea = true;
            Cultivateur = collider.gameObject;
            //Cultivateur = collider.GetComponent<Rigidbody2D>();
            //Enemy_life = collider.GetComponent<EnemieHealth>().E_Life;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Enemy_inArea = false;
    }
}

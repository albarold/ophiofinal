using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InArea : MonoBehaviour
{

    public bool Push_Area;
    public bool Enemy_inArea=false;
    public GameObject Cultivateur;
    public GameObject Heavy_ob;

    public static InArea instance;  // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Heavy_Object"))
        {
            Push_Area = true;
            Heavy_ob = collider.gameObject;
            //Cultivateur = collider.GetComponent<Rigidbody2D>();
            //Enemy_life = collider.GetComponent<EnemieHealth>().E_Life;
        }

        if (collider.CompareTag("Cultivateurs"))
        {
            Enemy_inArea = true;
            Cultivateur = collider.gameObject;
            //Cultivateur = collider.GetComponent<Rigidbody2D>();
            //Enemy_life = collider.GetComponent<EnemieHealth>().E_Life;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Push_Area = false;
        Enemy_inArea = false;
    }
}

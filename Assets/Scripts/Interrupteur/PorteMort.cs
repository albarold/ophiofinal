using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteMort : MonoBehaviour

{
    public GameObject Interrupteur;
    public bool Ouvert;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ouvert = Interrupteur.GetComponent<InterrupteurMort>().Active;

        if (Ouvert)
        {
            Debug.Log("PorteOuverte");
        }
    }
}

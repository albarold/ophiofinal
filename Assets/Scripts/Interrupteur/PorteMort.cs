using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PorteMort : MonoBehaviour

{
    public GameObject Interrupteur, VFX, Bloque;
    public bool Ouvert;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ouvert = Interrupteur.GetComponent<InterrupteurMort>().Ouvert;

        if (Ouvert)
        {
            Bloque.gameObject.SetActive(false);
            VFX.gameObject.SetActive(true);
        }
    }
}

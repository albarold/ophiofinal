using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PorteMort : MonoBehaviour

{
    public GameObject Interrupteur;
    public bool Ouvert;

    public Image Porte;
    public Sprite Ouverte;
    public Sprite Fermer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Ouvert)
        {
            Porte.sprite = Ouverte;
        }
        else
        {
            Porte.sprite = Fermer;
        }
        Ouvert = Interrupteur.GetComponent<InterrupteurMort>().Ouvert;

        if (Ouvert)
        {
            Debug.Log("PorteOuverte");
        }
    }
}

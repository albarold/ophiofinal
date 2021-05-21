using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulteur_dead : MonoBehaviour
{
    private Vector2 Throw_Dir = new Vector2(0f, -1f);//REMPLACER LE VECTOR PAR CELUI OU LE JOUEUR DEPARASITE LE CATA

    public GameObject Throw_Collider;
    public GameObject Go_Cultivateur;
    public Rigidbody2D Rb_Cultivateur;
    
    public float Throw_Thrust;

    public bool Activated;
    public bool In_Area;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        In_Area = Throw_Collider.GetComponent<InArea_Dead>().Enemy_inArea;

        if (In_Area && Activated)
        {
            Throwing();
            Activated = false;
            
        }

        if (Activated == false )
        {
            if (Rb_Cultivateur.velocity.magnitude < 0.5f)
            {
                Go_Cultivateur.GetComponent<Movement>().enabled = true; 
            }
        }


    }


    public void Throwing()
    {

        Debug.Log("yoooo");
        Go_Cultivateur = Throw_Collider.GetComponent<InArea_Dead>().Cultivateur; //recup go cultivateur qui entre dans zone
        Rb_Cultivateur = Go_Cultivateur.GetComponent<Rigidbody2D>();
        Go_Cultivateur.GetComponent<Movement>().enabled = false;
        Rb_Cultivateur.AddForce(Throw_Dir * Throw_Thrust, ForceMode2D.Impulse);

    }
}
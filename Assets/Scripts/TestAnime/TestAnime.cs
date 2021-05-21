using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnime : MonoBehaviour
{
    private Vector3 change;
    public GameObject Throw_Collider;
    private Vector2 Throw_Dir;
    private Rigidbody2D ORigidBody;
    public float speed;
    public bool actif;
    public bool desactif;
    void Start()
    {
        ORigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            MoveCharacter();
            MoveCollider();
        }
        

       






   
        
         if (Input.GetKeyUp(KeyCode.Space))
         {
            actif = true;
            //Mettre l'anime d'attaque
            print("attaque");
         }
        

    }

    public void MoveCharacter()
    {
        ORigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public void MoveCollider()
    {

        if (change.x > 0) //droite
        {

            Throw_Dir = new Vector2(1f, 0f);
            Throw_Collider.transform.rotation = Quaternion.Euler(0, 0, 90); //ligne à supprimer pour mettre le bon sprite et l'animation

        }
        if (change.x < 0) //gauche
        {
            Throw_Dir = new Vector2(-1f, 0f);
            Throw_Collider.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (change.y > 0) //haut
        {
            Throw_Dir = new Vector2(0f, 1f);
            Throw_Collider.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (change.y < 0) //bas
        {
            Throw_Dir = new Vector2(0f, -1f);
            Throw_Collider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }


    }

}

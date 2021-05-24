using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementIA : MonoBehaviour
{
    [HideInInspector]public Vector2 Direction;
    public bool InDistance;
    public float speed;
    private float ancienneSpeed;
    public Transform Player;
    public int Degats;
    public GameObject AttackCollider;
    public bool Zone;
    public bool Attaque, IsAtk;
    public float DureAttaque, tempsAttaque;

    public float KnockbackPower, KnockBackDuration;
    public float RayonAttaque;
    public float RayonDetection;
    public int Life;
    void Start()
    {
        ancienneSpeed = speed;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RayonAttaque);
        Gizmos.DrawWireSphere(transform.position, RayonDetection);
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player").transform;
                 
        Move();

        if (Zone)
        {
             speed = 0;
             Attaque = true; 
        }
        else
        {
            
            speed = ancienneSpeed;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Attaque && Zone)
        {
            IsAtk = true;
            speed = 0;
            GetComponent<SpriteRenderer>().color = Color.blue;
            DureAttaque += Time.deltaTime;
            if (DureAttaque >= tempsAttaque)
            {
                IsAtk = false;
                Attaque = false;                
                GetComponent<SpriteRenderer>().color = Color.red;
                Player.GetComponent<Vie_Hud>().TakeDamage(Degats);
                StartCoroutine(Movement.instance.KnockBack(KnockBackDuration, KnockbackPower, this.transform));
                DureAttaque = 0;
                
            }
        }
        else if (Zone == false && Attaque == true)
        {
            IsAtk = true;
            speed = 0;
            DureAttaque += Time.deltaTime;
            if (DureAttaque >= tempsAttaque)
            {
                IsAtk = false;
                Attaque = false;
                GetComponent<SpriteRenderer>().color = Color.red;
                DureAttaque = 0;                
               
            }
        }



    }

    public void Move()
    {
        if (Vector3.Distance(Player.position, transform.position) <= RayonDetection && Vector3.Distance(Player.position, transform.position) > RayonAttaque)
        {
            Direction = Player.transform.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            InDistance = true;
            MoveCollider(transform.position - Player.position);
        }
        else
        {
            InDistance = false;
        }
    }

     public void MoveCollider(Vector2 direction)
    {
        if (Attaque == false)
        {

        
            if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if(direction.x > 0)
                {
               
                    AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (direction.x < 0)
                {
                
                    AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
            {
                if (direction.y > 0)
                {
                
                    AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                if (direction.y < 0)
                {
                
                    AttackCollider.transform.rotation = Quaternion.Euler(0, 0, -90);
                }
            }
        }
    }

}


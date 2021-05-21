using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementIA : MonoBehaviour
{
    
    public bool InDistance;
    public float speed;
    public Transform Player;
    public int Degats;

    public float KnockbackPower, KnockBackDuration;
    public float RayonAttaque;
    public float RayonDetection;
    public int Life;
    void Start()
    {
        
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

       
    }

    public void Move()
    {
        if (Vector3.Distance(Player.position, transform.position) <= RayonDetection && Vector3.Distance(Player.position, transform.position) > RayonAttaque)
        {
            Debug.Log("Distance");
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            InDistance = true;
        }
        if (Vector3.Distance(Player.position, transform.position) <= RayonAttaque)
        {
            Debug.Log("Attaque");
            Player.GetComponent<Vie_Hud>().TakeDamage(Degats);
            StartCoroutine(Movement.instance.KnockBack(KnockBackDuration, KnockbackPower, this.transform));
        }
    }

}


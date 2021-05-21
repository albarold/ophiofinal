using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piques : MonoBehaviour
{
    private GameObject Player;
    private bool IsColliding;
    private float Timer;

    public float Knockback;
    public float ReDoDamageCoolDown;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            IsColliding = true;
            Player = collider.gameObject;
            Timer = ReDoDamageCoolDown;
            //Player.GetComponent<Rigidbody2D>().AddForce((Player.transform.position - transform.position)*Knockback*1000, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            IsColliding = false;
            Player = collider.gameObject;
        }
    }

    private void Update()
    {
        if (IsColliding)
        {
            
            Timer += Time.deltaTime;
            if (Timer>= ReDoDamageCoolDown)
            {
                Debug.Log("he's dead");
                Timer = 0;
                
                //Player.GetComponent<vie>.vie--
            }
            
        }
    }
}

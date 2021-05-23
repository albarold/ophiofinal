using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopChargeDoor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    { 
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<ChargeRework>().enabled == true)
            {
                if (collider.GetComponent<ChargeRework>().charge == true)
                {
                    collider.gameObject.GetComponent<Movement>().enabled = true;
                    Debug.Log("test");
                    collider.GetComponent<ChargeRework>().charge = false;
                    collider.GetComponent<ChargeRework>().DuringDash = 0;
                }
            }
        }
    }
}

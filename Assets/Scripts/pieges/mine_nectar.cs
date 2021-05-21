using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_nectar : MonoBehaviour
{
    public float ChargementAvantActivation;
    private bool Start = false;
    private float timer;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Start = true;
        }

    }


    private void Update()
    {
        if (Start)
        {
            timer += Time.deltaTime;
            if (timer >= ChargementAvantActivation)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                timer = 0;
            }
        }

    }
}

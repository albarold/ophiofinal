using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine_nectar : MonoBehaviour
{
    public GameMain Main;
    public float ChargementAvantActivation;
    public bool Start = false;
    public float timer;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("tqtmonreuf");
        if (collider.CompareTag("Player")&&Main.level!=0)
        {
            Start = true;
        }
        if (collider.CompareTag("Insecte1")|| collider.CompareTag("Insecte2") || collider.CompareTag("Insecte3"))
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

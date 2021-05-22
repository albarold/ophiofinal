using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geyser : MonoBehaviour
{
    public float TempsActif;
    public float TempsInactif;
    private float Timer;
    private bool active =false;
    public void Update()
    {
        Timer += Time.deltaTime;
        if (!active)
        {
            if (Timer>=TempsActif)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                active = true;
                Timer = 0;
            }
        }
        else
        {
            if (Timer>=TempsInactif)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                active = false;
                Timer=0;
            }
        }
    }

}

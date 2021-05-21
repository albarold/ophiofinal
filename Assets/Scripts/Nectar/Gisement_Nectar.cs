using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gisement_Nectar : MonoBehaviour
{
    private bool Near_Gisement;
    public int Nectar_Amount;
    public float Timer;
    public float Temps_Exctraction;
    public Nectar_Manager Nectar_Manager;

    public Vector3 scaleChange = new Vector3(-1f, -1f, -1f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Near_Gisement && Input.GetKey(KeyCode.E))
        {
            Extract();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Timer = 0;
        }

        if (Nectar_Amount <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Near_Gisement = true;    
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        Near_Gisement = false;
    }

    void Extract()
    {
        Timer += Time.deltaTime;
        if (Timer >= Temps_Exctraction)
        {
            Nectar_Amount -= 1;
            Timer = 0;
            Nectar_Manager.Nectar = Nectar_Manager.Nectar + 1;
            gameObject.transform.localScale += scaleChange;
        }
    }
}

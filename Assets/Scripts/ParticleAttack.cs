using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAttack : MonoBehaviour
{
    public ParticleSystem Attack;
    public GameObject Fx;
    
    // Start is called before the first frame update
    void Start()
    {
        Attack.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Fx.SetActive(true);
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fx.SetActive(false);
        }
    }
}

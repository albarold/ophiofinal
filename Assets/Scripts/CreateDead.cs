using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDead : MonoBehaviour
{
    public GameObject PrefabMort;

    public void Dead()
    {
        Instantiate(PrefabMort, transform.position, Quaternion.identity);

    }
}

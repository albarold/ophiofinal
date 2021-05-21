using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veine_Nectar : MonoBehaviour
{
    private GameObject ExtracteurLinked;
    public GameObject[] VeinesAChanger;

    public static SalleVeines salleVeines;
    public void Start()
    {
        salleVeines = SalleVeines.instance;
        ExtracteurLinked = this.gameObject.transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (ExtracteurLinked == null)
        {
            Fill_Nectar();
        }
    }
    public void Fill_Nectar()
    {
        salleVeines.Check();
        for (int i = 0; i < VeinesAChanger.Length; i++)
        {
            VeinesAChanger[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            VeinesAChanger[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        Destroy(gameObject);
    }
}

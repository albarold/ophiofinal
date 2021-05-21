using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SalleVeines : MonoBehaviour
{
    private int counter;

    public GameObject[] Extracteurs;
    public GameObject DoorToOpen;
    public Sprite DoorOpenSprite;
    
    //Cinemachine.CinemachineVirtualCamera c_VirtualCam;
    public GameObject Virtual_Camera;

    public static SalleVeines instance;
    
    public void Awake()
    {
        instance = this;
    }
    public void Check()
    {
        for (int i = 0; i < Extracteurs.Length; i++)
        {
            if (Extracteurs[i]==null)
            {
                counter +=1;
            }
        }
        if (counter == Extracteurs.Length)
        {
            OpenDoor();
        }
        counter = 0;
    }
    public void OpenDoor()
    {
        DoorToOpen.GetComponent<Collider2D>().enabled = false;
        DoorToOpen.GetComponent<SpriteRenderer>().sprite = DoorOpenSprite;
        //Virtual_Camera.GetComponent<CinemachineVirtualCamera>().Follow = transform;
        //c_VirtualCam.m_LookAt = transform;
        //c_VirtualCam.m_Follow = transform;
    }
}

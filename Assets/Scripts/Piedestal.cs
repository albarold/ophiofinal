using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Piedestal : MonoBehaviour
{
    public GameObject Virtual_Camera;
    //public Camera m_OrthographicCamera;
  
    public float CameraSize;
    private float OriginSize;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            OriginSize = Virtual_Camera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize;
            Virtual_Camera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = CameraSize;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Virtual_Camera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = OriginSize;
        }
    }


}

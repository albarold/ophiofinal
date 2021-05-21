using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCamSize : MonoBehaviour
{
    public GameObject Virtual_Camera;
    //public Camera m_OrthographicCamera;
    public float CameraSize;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Virtual_Camera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = CameraSize;
            //m_OrthographicCamera.orthographicSize = CameraSize;
        }
    }
}

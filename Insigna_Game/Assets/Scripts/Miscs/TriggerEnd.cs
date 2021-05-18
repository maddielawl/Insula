using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    public CinemachineVirtualCamera oldCam;
    public CinemachineVirtualCamera newCam;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraManager.Instance.setCameraPrioHigh(newCam);
            CameraManager.Instance.setCameraPrioLow(oldCam);
        }
        Debug.Log("stop movement");
    }
}

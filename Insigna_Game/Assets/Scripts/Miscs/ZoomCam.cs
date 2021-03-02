using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomCam : MonoBehaviour
{
    public CinemachineVirtualCamera oldCam;
    public CinemachineVirtualCamera newCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CameraManager.Instance.setCameraPrioHigh(newCam);
            CameraManager.Instance.setCameraPrioLow(oldCam);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CameraManager.Instance.setCameraPrioHigh(oldCam);
            CameraManager.Instance.setCameraPrioLow(newCam);
        }
    }
}

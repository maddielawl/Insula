using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera oldCam;
    public CinemachineVirtualCamera newCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CameraManager.Instance.setCameraPrioHigh(newCam);
        CameraManager.Instance.setCameraPrioLow(oldCam);
    }
}

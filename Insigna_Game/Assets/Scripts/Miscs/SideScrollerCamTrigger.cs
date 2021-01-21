using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SideScrollerCamTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera oldCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CameraManager.Instance.SideCamPrioHigh();
        CameraManager.Instance.setCameraPrioLow(oldCam);
    }
}

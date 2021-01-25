using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Singlton:Profile

    public static CameraManager Instance;

    void Awake ()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy (gameObject);
    }
    #endregion
    

    public void setCameraPrioLow(CinemachineVirtualCamera cam)
    {
        cam.Priority = 1;
    }
    public void setCameraPrioHigh(CinemachineVirtualCamera cam)
    {
        cam.Priority = 10;
    }
}

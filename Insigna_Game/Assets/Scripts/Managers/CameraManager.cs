using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject StaticCamera;
    public GameObject FollowCamera;

    #region Singlton:Profile

    public static CameraManager Instance;

    void Awake ()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy (gameObject);

        StaticCamera = GameObject.FindGameObjectWithTag("StaticCamera");
        if(StaticCamera == null)
        {
            return;
        }

        FollowCamera = GameObject.FindGameObjectWithTag("FollowCamera");
        if(FollowCamera == null)
        {
            return;
        }
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

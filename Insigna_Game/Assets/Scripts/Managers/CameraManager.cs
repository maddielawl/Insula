using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private GameObject Player;
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


        //trouver joueur
        Player = GameObject.FindGameObjectWithTag("Player");
        //trouver caméra fixe
        StaticCamera = GameObject.FindGameObjectWithTag("StaticCamera");
        if(StaticCamera == null)
        {
            return;
        }

        //trouver caméra follow
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

    public void setFollowCameraOnPlayerPosition(CinemachineVirtualCamera cam)
    {
        cam.transform.position = Player.transform.position;
    }
}

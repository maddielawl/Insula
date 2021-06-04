using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Singlton:Profile

    public static SaveManager Instance;

    void Awake ()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy (gameObject);
    }
    #endregion


    public int LevelIdx;
    public float VolumeFloat;
    public bool FullscreenBool;
    public bool CursorState;
    public int XResolution;
    public int YResolution;



}

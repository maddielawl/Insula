using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    #region Singlton:Profile

    public static UIManager Instance;

    void Awake ()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy (gameObject);
    }
    #endregion

    [Header("Cursors")]
    public Texture2D basicCursor;
    public Texture2D nearCursor;
    public Texture2D farCursor;

    [Header("UIMenus")]
    public GameObject MainMenu;
    public GameObject OptionMenu;
    public GameObject CreditMenu;

    private void Start()
    {
        Cursor.SetCursor(basicCursor, Vector2.zero, CursorMode.Auto);
    }
    

    public void ResetCursor()
    {
        Cursor.SetCursor(basicCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetNearCursor()
    {
        Cursor.SetCursor(nearCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetFarCursor()
    {
        Cursor.SetCursor(farCursor, Vector2.zero, CursorMode.Auto);
    }
    
}

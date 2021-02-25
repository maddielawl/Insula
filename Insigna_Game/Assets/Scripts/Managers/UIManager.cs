using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

[Header("Inventory Buttons")]
    public Image inventoryButton1;
    public Image inventoryButton2;
    public Image inventoryButton3;

    private bool isSlot1Full = false;
    private bool isSlot2Full = false;
    private bool isSlot3Full = false;

    public GameObject objectInSlot1;
    public GameObject objectInSlot2;
    public GameObject objectInSlot3;

    // public GameObject usable;

    
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

    public void GetObjectInInventory(GameObject usable)
    {
        if(isSlot1Full == false)
        {
            inventoryButton1.sprite = usable.GetComponent<SpriteRenderer>().sprite;
            objectInSlot1 = usable;
            isSlot1Full = true;
            return;
        }

        if(isSlot2Full == false)
        {
            inventoryButton1.sprite = usable.GetComponent<SpriteRenderer>().sprite;
            objectInSlot2 = usable;
            isSlot2Full = true;
            return;
        }

        if(isSlot3Full == false)
        {
            inventoryButton1.sprite = usable.GetComponent<SpriteRenderer>().sprite;
            objectInSlot3 = usable;
            isSlot3Full = true;
            return;
        }
    }
    
}

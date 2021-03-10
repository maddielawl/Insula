using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    [Header("Managers")]
    public GameManager gameManager;

    [Header("Cursors")]
    public Texture2D basicCursor;
    public Texture2D nearCursor;
    public Texture2D farCursor;
    public Texture2D interractionCursor;

    [Header("Inventory Buttons")]
    public Image inventoryButton1;
    public Image inventoryButton2;
    public Image inventoryButton3;

    private bool isSlot1Full = false;
    private bool isSlot2Full = false;
    private bool isSlot3Full = false;

    [Header("Objects Stored in slots")]
    public GameObject objectInSlot1;
    public GameObject objectInSlot2;
    public GameObject objectInSlot3;

    [Header("IsEquippedIndicator")]
    public GameObject object1Equipped;
    public GameObject object2Equipped;
    public GameObject object3Equipped;

    [Header("Inventory Slots Active State")]
    public bool isSlot1Active = false;
    public bool isSlot2Active = false;
    public bool isSlot3Active = false;

    public bool oneSlotAtTheTimeSecurity = false;

    [Header("UI")]
    public Slider sanitySlider;
    public Slider madnessSlider;
    public TMP_Text pillCount;
    public GameObject helmetOffIndicator;
    public GameObject helmetOnIndicator;


    private void Start()
    {
        Cursor.SetCursor(basicCursor, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        //slider Madness lié à la value dans le GameManager
        madnessSlider.value = gameManager.playerMadness;
        //slider Sanity lié à la value dans le GameManager
        sanitySlider.value = gameManager.playerSanity;
        //nombre de pills lié à la value dans le GameManager
        pillCount.text = gameManager.playerPillsCount.ToString();
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
    public void SetInterractionCursor()
    {
        Cursor.SetCursor(interractionCursor, Vector2.zero, CursorMode.Auto);
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

    public void ActivateSlot1()
    {
        if(oneSlotAtTheTimeSecurity == false){
        if(isSlot1Active == false)
        {
            oneSlotAtTheTimeSecurity = true;
            isSlot1Active = true;
                FindObjectOfType<AudioManager>().Play("OnClickInventory");
                object1Equipped.SetActive(true);
                return;
        }
        }
        if(isSlot1Active == true){

            oneSlotAtTheTimeSecurity = false;
            isSlot1Active = false;
            FindObjectOfType<AudioManager>().Play("OnClickInventory");
            object1Equipped.SetActive(false);
            return;
        }
        
    }
    public void ActivateSlot2()
    {
        if(oneSlotAtTheTimeSecurity == false){
        if(isSlot2Active == false)
        {
            oneSlotAtTheTimeSecurity = true;
            isSlot2Active = true;
                FindObjectOfType<AudioManager>().Play("OnClickInventory");
                object2Equipped.SetActive(true);
                return;
        }
        }
        if(isSlot2Active == true){

            oneSlotAtTheTimeSecurity = false;
            isSlot2Active = false;
            FindObjectOfType<AudioManager>().Play("OnClickInventory");
            object2Equipped.SetActive(false);
            return;
        }
        
    }
    public void ActivateSlot3()
    {
        if(oneSlotAtTheTimeSecurity == false){
        if(isSlot3Active == false)
        {
            oneSlotAtTheTimeSecurity = true;
            isSlot3Active = true;
                FindObjectOfType<AudioManager>().Play("OnClickInventory");
                object3Equipped.SetActive(true);
                return;
        }
        }
        if(isSlot3Active == true){

            oneSlotAtTheTimeSecurity = false;
            isSlot3Active = false;
            FindObjectOfType<AudioManager>().Play("OnClickInventory");
            object3Equipped.SetActive(false);
            return;
        }
        
    }

    public void GotHelmet()
    {
        helmetOffIndicator.SetActive(true);
    }
    public void HelmetIsOn()
    {
        helmetOffIndicator.SetActive(false);
        helmetOnIndicator.SetActive(true);
    }
    public void HelmetIsOff()
    {
        helmetOffIndicator.SetActive(true);
        helmetOnIndicator.SetActive(false);
    }
    
}

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
    public Sprite basicCursor;
    public Sprite nearCursor;
    public Sprite farCursor;
    public Sprite interractionCursor;

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
    public GameObject[] sanityBars;
    public Slider madnessSlider;
    public TMP_Text pillCount;
    public GameObject helmetOffIndicator;
    public GameObject helmetOnIndicator;


    private void Start()
    {
        // Cursor.SetCursor(basicCursor, Vector2.zero, CursorMode.Auto);
        foreach (GameObject sanityBars in sanityBars)
        {
            sanityBars.SetActive(false);
        }
    }

    private void Update()
    {
        //slider Madness lié à la value dans le GameManager
        madnessSlider.value = gameManager.playerMadness;
        //slider Sanity lié à la value dans le GameManager
        #region Sanity healthbar
        if (gameManager.playerSanity >= 100)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
        }
        if (gameManager.playerSanity < 100 && gameManager.playerSanity > 86.8)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            sanityBars[7].SetActive(false);
        }
        if (gameManager.playerSanity <= 86.8 && gameManager.playerSanity > 74.4)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            sanityBars[7].SetActive(false);
        }
        if (gameManager.playerSanity <= 74.4 && gameManager.playerSanity > 62)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            sanityBars[7].SetActive(false);
            sanityBars[6].SetActive(false);
        }
        if (gameManager.playerSanity <= 62 && gameManager.playerSanity > 49.6)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            sanityBars[7].SetActive(false);
            sanityBars[6].SetActive(false);
            sanityBars[5].SetActive(false);
        }
        if (gameManager.playerSanity <= 49.6 && gameManager.playerSanity > 37.2)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
            sanityBars[0].SetActive(true);
            sanityBars[1].SetActive(true);
            sanityBars[2].SetActive(true);
            sanityBars[3].SetActive(true);
        }
        if (gameManager.playerSanity <= 37.2 && gameManager.playerSanity > 24.8)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
            sanityBars[0].SetActive(true);
            sanityBars[1].SetActive(true);
            sanityBars[2].SetActive(true);
        }
        if (gameManager.playerSanity <= 24.8 && gameManager.playerSanity > 12.4)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
            sanityBars[0].SetActive(true);
            sanityBars[1].SetActive(true);
        }
        if (gameManager.playerSanity <= 12.4 && gameManager.playerSanity > 0)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
            sanityBars[0].SetActive(true);
        }
        if (gameManager.playerSanity <= 0)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
        }
        #endregion
        //nombre de pills lié à la value dans le GameManager
        pillCount.text = gameManager.playerPillsCount.ToString();
    }


    public void ResetCursor()
    {
        // Cursor.SetCursor(basicCursor, Vector2.zero, CursorMode.Auto);
        CursorManager.Instance.rend.sprite = basicCursor;
    }

    public void SetNearCursor()
    {
        // Cursor.SetCursor(nearCursor, Vector2.zero, CursorMode.Auto);
        CursorManager.Instance.rend.sprite = nearCursor;
    }

    public void SetFarCursor()
    {
        // Cursor.SetCursor(farCursor, Vector2.zero, CursorMode.Auto);
        CursorManager.Instance.rend.sprite = farCursor;
    }
    public void SetInterractionCursor()
    {
        // Cursor.SetCursor(interractionCursor, Vector2.zero, CursorMode.Auto);
        CursorManager.Instance.rend.sprite = interractionCursor;
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

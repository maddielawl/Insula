using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{

    #region Singlton:Profile

    public static UIManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Cursor.SetCursor(basicCursor, Vector2.zero, CursorMode.Auto);
        foreach (GameObject sanityBars in sanityBars)
        {
            sanityBars.SetActive(false);
        }
    }
    #endregion


    [Header("Cursors")]
    public Sprite basicCursor;
    public Sprite nearCursor;
    public Sprite farCursor;
    public Sprite interractionCursor;
    public Sprite DoorCursor;

    [Header("Inventory Buttons")]
    public Image inventoryButton1;
    public Image inventoryButton2;
    public Image inventoryButton3;

    public bool isSlot1Full = false;
    public bool isSlot2Full = false;
    public bool isSlot3Full = false;

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
    public Image madnessFill;
    public GameObject pillCountGO;
    public Sprite[] pillCountSpr = new Sprite[4];
    public GameObject helmetOffIndicator;
    public GameObject helmetOnIndicator;
    public GameObject blackScreen;

    [Header("Others")]
    [HideInInspector]
    public GameObject player;
    public RuntimeAnimatorController playerAnimatorController;
    public AnimatorOverrideController playerTvAnimatorController;

    public PlayerData playerData;


    public void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        /*else
        {
            return;
        }*/

        //slider Madness li� � la value dans le GameManager
        madnessFill.fillAmount = GameManager.Instance.playerMadness / 100;
        //slider Sanity li� � la value dans le GameManager
        #region Sanity healthbar
        if (GameManager.Instance.playerSanity >= 100)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
        }
        if (GameManager.Instance.playerSanity < 100 && GameManager.Instance.playerSanity > 86.8)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            sanityBars[7].SetActive(false);
        }
        if (GameManager.Instance.playerSanity <= 86.8 && GameManager.Instance.playerSanity > 74.4)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            sanityBars[7].SetActive(false);
        }
        if (GameManager.Instance.playerSanity <= 74.4 && GameManager.Instance.playerSanity > 62)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            sanityBars[7].SetActive(false);
            sanityBars[6].SetActive(false);
        }
        if (GameManager.Instance.playerSanity <= 62 && GameManager.Instance.playerSanity > 49.6)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            sanityBars[7].SetActive(false);
            sanityBars[6].SetActive(false);
            sanityBars[5].SetActive(false);
        }
        if (GameManager.Instance.playerSanity <= 49.6 && GameManager.Instance.playerSanity > 37.2)
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
        if (GameManager.Instance.playerSanity <= 37.2 && GameManager.Instance.playerSanity > 24.8)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
            sanityBars[0].SetActive(true);
            sanityBars[1].SetActive(true);
            sanityBars[2].SetActive(true);
        }
        if (GameManager.Instance.playerSanity <= 24.8 && GameManager.Instance.playerSanity > 12.4)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
            sanityBars[0].SetActive(true);
            sanityBars[1].SetActive(true);
        }
        if (GameManager.Instance.playerSanity <= 12.4 && GameManager.Instance.playerSanity > 0)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
            sanityBars[0].SetActive(true);
        }
        if (GameManager.Instance.playerSanity <= 0)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
        }
        #endregion
        //nombre de pills li� � la value dans le GameManager
        switch (GameManager.Instance.playerPillsCount)
        {
            case 0:
                pillCountGO.GetComponent<Image>().sprite = pillCountSpr[0];
                break;
            case 1:
                pillCountGO.GetComponent<Image>().sprite = pillCountSpr[1];
                break;
            case 2:
                pillCountGO.GetComponent<Image>().sprite = pillCountSpr[2];
                break;
            case 3:
                pillCountGO.GetComponent<Image>().sprite = pillCountSpr[3];
                break;
        }
    }


    public void ResetCursor()
    {
        // Cursor.SetCursor(basicCursor, Vector2.zero, CursorMode.Auto);
        CursorManager.Instance.rend.sprite = basicCursor;
        CursorManager.Instance.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
    }

    public void SetNearCursor()
    {
        // Cursor.SetCursor(nearCursor, Vector2.zero, CursorMode.Auto);
        CursorManager.Instance.rend.sprite = nearCursor;
        CursorManager.Instance.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
    }

    public void SetFarCursor()
    {
        // Cursor.SetCursor(farCursor, Vector2.zero, CursorMode.Auto);
        CursorManager.Instance.rend.sprite = farCursor;
        CursorManager.Instance.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
    }
    public void SetInterractionCursor()
    {
        // Cursor.SetCursor(interractionCursor, Vector2.zero, CursorMode.Auto);
        CursorManager.Instance.rend.sprite = interractionCursor;
        CursorManager.Instance.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
    }

    public void SetDoorCursor()
    {
        CursorManager.Instance.rend.sprite = DoorCursor;
        CursorManager.Instance.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
    }




    public void GetObjectInInventory(GameObject usable)
    {
        if (isSlot1Full == false)
        {
            inventoryButton1.sprite = usable.GetComponent<SpriteRenderer>().sprite;
            inventoryButton1.GetComponent<Image>().enabled = true;
            objectInSlot1 = usable;
            isSlot1Full = true;
            return;
        }

        if (isSlot2Full == false)
        {
            inventoryButton2.sprite = usable.GetComponent<SpriteRenderer>().sprite;
            inventoryButton2.GetComponent<Image>().enabled = true;
            objectInSlot2 = usable;
            isSlot2Full = true;
            return;
        }

        if (isSlot3Full == false)
        {
            inventoryButton3.sprite = usable.GetComponent<SpriteRenderer>().sprite;
            inventoryButton3.GetComponent<Image>().enabled = true;
            objectInSlot3 = usable;
            isSlot3Full = true;
            return;
        }
    }

    public void ActivateSlot1()
    {
        if (oneSlotAtTheTimeSecurity == false)
        {
            if (isSlot1Active == false)
            {
                oneSlotAtTheTimeSecurity = true;
                isSlot1Active = true;
                FindObjectOfType<AudioManager>().Play("OnClickInventory");
                object1Equipped.SetActive(true);
                return;
            }
        }
        if (isSlot1Active == true)
        {

            oneSlotAtTheTimeSecurity = false;
            isSlot1Active = false;
            FindObjectOfType<AudioManager>().Play("OnClickInventory");
            object1Equipped.SetActive(false);
            return;
        }

    }
    public void ActivateSlot2()
    {
        if (oneSlotAtTheTimeSecurity == false)
        {
            if (isSlot2Active == false)
            {
                oneSlotAtTheTimeSecurity = true;
                isSlot2Active = true;
                FindObjectOfType<AudioManager>().Play("OnClickInventory");
                object2Equipped.SetActive(true);
                return;
            }
        }
        if (isSlot2Active == true)
        {

            oneSlotAtTheTimeSecurity = false;
            isSlot2Active = false;
            FindObjectOfType<AudioManager>().Play("OnClickInventory");
            object2Equipped.SetActive(false);
            return;
        }

    }
    public void ActivateSlot3()
    {
        if (oneSlotAtTheTimeSecurity == false)
        {
            if (isSlot3Active == false)
            {
                oneSlotAtTheTimeSecurity = true;
                isSlot3Active = true;
                FindObjectOfType<AudioManager>().Play("OnClickInventory");
                object3Equipped.SetActive(true);
                return;
            }
        }
        if (isSlot3Active == true)
        {

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
        if (playerData.ladderTaken == false)
        {
            helmetOffIndicator.SetActive(false);
            helmetOnIndicator.SetActive(true);
            GameManager.Instance.hasHelmetEquipped = true;
            //player.GetComponent<Animator>().runtimeAnimatorController = playerTvAnimatorController;
        }
    }
    public void HelmetIsOff()
    {
        if (playerData.ladderTaken == false)
        {
            helmetOffIndicator.SetActive(true);
            helmetOnIndicator.SetActive(false);
            GameManager.Instance.hasHelmetEquipped = false;
            //player.GetComponent<Animator>().runtimeAnimatorController = playerAnimatorController;
        }
    }
    public IEnumerator FadeToBlackTP(GameObject player, Transform spawnPoint, bool fadeToBlack, float fadeSpeed = 1f)
    {
        Color objectColor = UIManager.Instance.blackScreen.GetComponent<Image>().color;
        float fadeAmount;

        player.GetComponent<PlayerInput>().currentActionMap.Disable();
        while (UIManager.Instance.blackScreen.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            UIManager.Instance.blackScreen.GetComponent<Image>().color = objectColor;
            yield return null;
        }

        Debug.Log("teleport");
        player.transform.position = spawnPoint.position;
        StartCoroutine(FadeToTransparent(player, fadeSpeed));
    }

    public IEnumerator FadeToTransparent(GameObject player, float fadeSpeedB)
    {
        Color objectColor = UIManager.Instance.blackScreen.GetComponent<Image>().color;
        float fadeAmountB;
        yield return new WaitForSeconds(2.5f);
        while (UIManager.Instance.blackScreen.GetComponent<Image>().color.a > 0)
        {
            fadeAmountB = objectColor.a - (fadeSpeedB * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmountB);
            UIManager.Instance.blackScreen.GetComponent<Image>().color = objectColor;
            yield return null;
        }
        Debug.Log("movementEnabled");
        player.GetComponent<PlayerInput>().currentActionMap.Enable();
    }
}

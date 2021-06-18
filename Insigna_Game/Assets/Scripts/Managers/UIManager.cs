using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

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
    public Sprite popUpCursor;

    [Header("Inventory Buttons")]
    public Image inventoryButton1;
    public Image inventoryButton2;
    public Image inventoryButton3;

    public bool isSlot1Full = false;
    public bool isSlot2Full = false;
    public bool isSlot3Full = false;

    public Sprite normalInventorySpr;

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
    public GameObject helmetButton;
    public GameObject blackScreen;

    [Header("Others")]
    [HideInInspector]
    public GameObject player;
    public RuntimeAnimatorController playerAnimatorController;
    public AnimatorOverrideController playerTvAnimatorController;

    public PlayerData playerData;

    [Header("Portraits")]
    public GameObject pom;
    public GameObject gentleman;
    public GameObject celeste;
    public GameObject oublie;

    public Volume v_Tv;

    public GameObject IndicibleWarning;

    public string descriptionString1;
    public string descriptionString2;
    public string descriptionString3;

    public GameObject rappeltext;

    public bool vincenttufaitchier = false;

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
        Vector3 madnessFillEmpty = new Vector3(-1035, madnessFill.rectTransform.anchoredPosition.y, madnessFill.transform.position.z);
        Vector3 madnessFillFull = new Vector3(-743, madnessFill.rectTransform.anchoredPosition.y, madnessFill.transform.position.z);
        madnessFill.rectTransform.anchoredPosition = Vector3.Lerp(madnessFillEmpty, madnessFillFull, GameManager.Instance.playerMadness / 100);

        //slider Sanity li� � la value dans le GameManager
        #region Sanity healthbar
        if (GameManager.Instance.playerSanity < 100 && GameManager.Instance.playerSanity > 86.8)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            /*sanityBars[7].GetComponent<Animator>().SetBool("Blinking", true);
            sanityBars[6].GetComponent<Animator>().SetBool("Blinking", false);*/
        }
        if (GameManager.Instance.playerSanity <= 86.8 && GameManager.Instance.playerSanity > 74.4)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            sanityBars[7].SetActive(false);
            /*sanityBars[6].GetComponent<Animator>().SetBool("Blinking", true);
            sanityBars[5].GetComponent<Animator>().SetBool("Blinking", false);
            sanityBars[7].GetComponent<Animator>().SetBool("Blinking", false);*/
        }
        if (GameManager.Instance.playerSanity <= 74.4 && GameManager.Instance.playerSanity > 62)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(true);
            }
            sanityBars[7].SetActive(false);
            sanityBars[6].SetActive(false);
            /*sanityBars[5].GetComponent<Animator>().SetBool("Blinking", true);
            sanityBars[4].GetComponent<Animator>().SetBool("Blinking", false);
            sanityBars[6].GetComponent<Animator>().SetBool("Blinking", false);*/
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
           /* sanityBars[4].GetComponent<Animator>().SetBool("Blinking", true);
            sanityBars[3].GetComponent<Animator>().SetBool("Blinking", false);
            sanityBars[5].GetComponent<Animator>().SetBool("Blinking", false);*/
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
            /*sanityBars[3].GetComponent<Animator>().SetBool("Blinking", true);
            sanityBars[2].GetComponent<Animator>().SetBool("Blinking", false);
            sanityBars[4].GetComponent<Animator>().SetBool("Blinking", false);*/
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
            /*sanityBars[2].GetComponent<Animator>().SetBool("Blinking", true);
            sanityBars[1].GetComponent<Animator>().SetBool("Blinking", false);
            sanityBars[3].GetComponent<Animator>().SetBool("Blinking", false);*/
        }
        if (GameManager.Instance.playerSanity <= 24.8 && GameManager.Instance.playerSanity > 12.4)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
            sanityBars[0].SetActive(true);
            sanityBars[1].SetActive(true);
            /*sanityBars[1].GetComponent<Animator>().SetBool("Blinking", true);
            sanityBars[0].GetComponent<Animator>().SetBool("Blinking", false);
            sanityBars[2].GetComponent<Animator>().SetBool("Blinking", false);*/
        }
        if (GameManager.Instance.playerSanity <= 12.4 && GameManager.Instance.playerSanity > 0)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
            sanityBars[0].SetActive(true);
            Debug.Log("bruh");
            /*sanityBars[0].GetComponent<Animator>().SetBool("Blinking", true);
            sanityBars[1].GetComponent<Animator>().SetBool("Blinking", false);*/
        }
        if (GameManager.Instance.playerSanity <= 0)
        {
            foreach (GameObject sanityBars in sanityBars)
            {
                sanityBars.SetActive(false);
            }
            //sanityBars[0].GetComponent<Animator>().SetBool("Blinking", false);
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

    public void SetPopUpCursor()
    {
        CursorManager.Instance.rend.sprite = popUpCursor;
        CursorManager.Instance.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
    }




    public void GetObjectInInventory(GameObject usable)
    {
        if (isSlot1Full == false)
        {
            inventoryButton1.sprite = usable.GetComponent<SpriteRenderer>().sprite;
            inventoryButton1.GetComponent<Image>().enabled = true;
            if (vincenttufaitchier == true)
            {
                descriptionString1 = usable.GetComponent<Items>().objectrappel;
            }
            else
            {
                descriptionString1 = usable.GetComponent<BarreauItem>().objectrappel;
                vincenttufaitchier = true;
            }
            objectInSlot1 = usable;
            isSlot1Full = true;
            return;
        }

        if (isSlot2Full == false)
        {
            inventoryButton2.sprite = usable.GetComponent<SpriteRenderer>().sprite;
            inventoryButton2.GetComponent<Image>().enabled = true;
            descriptionString2 = usable.GetComponent<Items>().objectrappel;
            objectInSlot2 = usable;
            isSlot2Full = true;
            return;
        }

        if (isSlot3Full == false)
        {
            inventoryButton3.sprite = usable.GetComponent<SpriteRenderer>().sprite;
            inventoryButton3.GetComponent<Image>().enabled = true;
            descriptionString3 = usable.GetComponent<Items>().objectrappel;
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
                rappeltext.SetActive(true);
                rappeltext.GetComponent<TextMeshProUGUI>().text = descriptionString1;
                DisplayPortrait(0);
                Invoke("HideDescriptionText", 3f);
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
                rappeltext.SetActive(true);
                rappeltext.GetComponent<TextMeshProUGUI>().text = descriptionString2;
                DisplayPortrait(0);
                Invoke("HideDescriptionText", 3f);
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
                rappeltext.SetActive(true);
                rappeltext.GetComponent<TextMeshProUGUI>().text = descriptionString3;
                DisplayPortrait(0);
                Invoke("HideDescriptionText", 3f);
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
        helmetButton.SetActive(true);
    }
    public void HelmetIsOn()
    {
        helmetOffIndicator.SetActive(false);
        helmetOnIndicator.SetActive(true);
        v_Tv.weight = 1;
        GameManager.Instance.hasHelmetEquipped = true;
        player.GetComponent<Animator>().runtimeAnimatorController = playerTvAnimatorController;
    }
    public void HelmetIsOff()
    {
        helmetOffIndicator.SetActive(true);
        helmetOnIndicator.SetActive(false);
        v_Tv.weight = 0;
        GameManager.Instance.hasHelmetEquipped = false;
        player.GetComponent<Animator>().runtimeAnimatorController = playerAnimatorController;
    }

    public void ChangeHelmetState()
    {
        if (GameManager.Instance.canEquipHelmet == true)
        {
            if (GameManager.Instance.isHelmetEquipped == true)
            {
                GameManager.Instance.isHelmetEquipped = false;
                UIManager.Instance.HelmetIsOff();
                FindObjectOfType<AudioManager>().Play("HelmetOff");
                return;
            }

            if (GameManager.Instance.isHelmetEquipped == false && playerData.ladderTaken == false && playerData.isInVent == false)
            {
                GameManager.Instance.isHelmetEquipped = true;
                UIManager.Instance.HelmetIsOn();
                FindObjectOfType<AudioManager>().Play("HelmetOn");
                return;
            }
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
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player Sounds/Level Transition");
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

    public void DisplayPortrait(int protraitIdx)
    {
        if (pom != null && gentleman != null && celeste != null && oublie != null)
        {
            switch (protraitIdx)
            {
                default:
                    pom.SetActive(true);
                    gentleman.SetActive(false);
                    celeste.SetActive(false);
                    oublie.SetActive(false);
                    break;
                case 0:
                    pom.SetActive(true);
                    gentleman.SetActive(false);
                    celeste.SetActive(false);
                    oublie.SetActive(false);
                    break;
                case 1:
                    pom.SetActive(false);
                    gentleman.SetActive(true);
                    celeste.SetActive(false);
                    oublie.SetActive(false);
                    break;
                case 2:
                    pom.SetActive(false);
                    gentleman.SetActive(false);
                    celeste.SetActive(true);
                    oublie.SetActive(false);
                    break;
                case 3:
                    pom.SetActive(false);
                    gentleman.SetActive(false);
                    celeste.SetActive(false);
                    oublie.SetActive(true);
                    break;
            }
        }
    }

    public void HidePortraits()
    {
        if (pom != null && gentleman != null && celeste != null && oublie != null)
        {
            pom.SetActive(false);
            gentleman.SetActive(false);
            celeste.SetActive(false);
            oublie.SetActive(false);
        }
    }

    public void DisplayWarning()
    {
        LeanTween.value(IndicibleWarning, SetSpriteAlpha, 0f, 1f, 1f);
        Invoke("HideWarning", 5f);
    }

    public void HideWarning()
    {
        LeanTween.value(IndicibleWarning, SetSpriteAlpha, 1f, 0f, 1f);
    }

    public void SetSpriteAlpha(float val)
    {
        IndicibleWarning.GetComponent<Image>().color = new Color(1f, 1f, 1f, val);

    }

    public void HideDescriptionText()
    {
        rappeltext.SetActive(false);
        HidePortraits();
    }
}

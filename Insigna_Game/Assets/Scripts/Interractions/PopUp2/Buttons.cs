using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public Image baseSlotSprite;
    public GameObject emptySlot;

    public string objectToInterractWith;

    public Button button1;
    public Button button2;

    public Image buttonimage1;
    public Image buttonimage2;

    private bool InteractionOff;

    public bool buttonOneDone;
    public bool buttonTwoDone;

    public GameObject allScotch;
    public GameObject scotchRight;
    public GameObject scotchLeft;

    private InterractableWithInventory parent;


    public void InterractionButtonOne()
    {
        if (UIManager.Instance.isSlot1Active == true)
        {
            if (UIManager.Instance.objectInSlot1.name.Contains(objectToInterractWith))
            {
                if(buttonTwoDone == false)
                {
                    buttonimage1.sprite = emptySlot.GetComponent<Image>().sprite;
                    button1.enabled = false;
                    scotchLeft.SetActive(true);
                }
                else
                {
                    buttonimage1.sprite = emptySlot.GetComponent<Image>().sprite;
                    button1.enabled = false;
                    allScotch.SetActive(true);
                }
                UIManager.Instance.inventoryButton1.sprite = baseSlotSprite.sprite;
                UIManager.Instance.inventoryButton1.GetComponent<Image>().enabled = false;
                UIManager.Instance.objectInSlot1 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot1Active = false;
                UIManager.Instance.isSlot1Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object1Equipped.SetActive(false);
                InteractionOff = true;
                Destroy(button1);
                buttonOneDone = true;
            }
        }

        if (UIManager.Instance.isSlot2Active == true)
        {
            if (UIManager.Instance.objectInSlot2.name.Contains(objectToInterractWith))
            {
                if (buttonTwoDone == false)
                {
                    buttonimage1.sprite = emptySlot.GetComponent<Image>().sprite;
                    button1.enabled = false;
                    scotchLeft.SetActive(true);
                }
                else
                {
                    buttonimage1.sprite = emptySlot.GetComponent<Image>().sprite;
                    button1.enabled = false;
                    allScotch.SetActive(true);
                }
                UIManager.Instance.inventoryButton2.sprite = baseSlotSprite.sprite;
                UIManager.Instance.inventoryButton2.GetComponent<Image>().enabled = false;
                UIManager.Instance.objectInSlot2 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot2Active = false;
                UIManager.Instance.isSlot2Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object2Equipped.SetActive(false);
                InteractionOff = true;
                Destroy(button1);
                buttonOneDone = true;
            }
        }

        if (UIManager.Instance.isSlot3Active == true)
        {
            if (UIManager.Instance.objectInSlot3.name.Contains(objectToInterractWith))
            {
                if (buttonTwoDone == false)
                {
                    buttonimage1.sprite = emptySlot.GetComponent<Image>().sprite;
                    button1.enabled = false;
                    scotchLeft.SetActive(true);
                }
                else
                {
                    buttonimage1.sprite = emptySlot.GetComponent<Image>().sprite;
                    button1.enabled = false;
                    allScotch.SetActive(true);
                }
                UIManager.Instance.inventoryButton3.sprite = baseSlotSprite.sprite;
                UIManager.Instance.inventoryButton3.GetComponent<Image>().enabled = false;
                UIManager.Instance.objectInSlot3 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot3Active = false;
                UIManager.Instance.isSlot3Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object3Equipped.SetActive(false);
                InteractionOff = true;
                Destroy(button1);
                buttonOneDone = true;
            }
        }
    }

    public void InterractionButtonTwo()
    {
        if (UIManager.Instance.isSlot1Active == true)
        {
            if (UIManager.Instance.objectInSlot1.name.Contains(objectToInterractWith))
            {
                if (buttonOneDone == false)
                {
                    buttonimage2.sprite = emptySlot.GetComponent<Image>().sprite;
                    button2.enabled = false;
                    scotchRight.SetActive(true);
                }
                else
                {
                    buttonimage2.sprite = emptySlot.GetComponent<Image>().sprite;
                    button2.enabled = false;
                    allScotch.SetActive(true);
                }
                UIManager.Instance.inventoryButton1.sprite = baseSlotSprite.sprite;
                UIManager.Instance.inventoryButton1.GetComponent<Image>().enabled = false;
                UIManager.Instance.objectInSlot1 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot1Active = false;
                UIManager.Instance.isSlot1Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object1Equipped.SetActive(false);
                InteractionOff = true;
                Destroy(button2);
                buttonTwoDone = true;
            }
        }

        if (UIManager.Instance.isSlot2Active == true)
        {
            if (UIManager.Instance.objectInSlot2.name.Contains(objectToInterractWith))
            {
                if (buttonOneDone == false)
                {
                    buttonimage2.sprite = emptySlot.GetComponent<Image>().sprite;
                    button2.enabled = false;
                    scotchRight.SetActive(true);
                }
                else
                {
                    buttonimage2.sprite = emptySlot.GetComponent<Image>().sprite;
                    button2.enabled = false;
                    allScotch.SetActive(true);
                }
                UIManager.Instance.inventoryButton2.sprite = baseSlotSprite.sprite;
                UIManager.Instance.inventoryButton2.GetComponent<Image>().enabled = false;
                UIManager.Instance.objectInSlot2 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot2Active = false;
                UIManager.Instance.isSlot2Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object2Equipped.SetActive(false);
                InteractionOff = true;
                Destroy(button2);
                buttonTwoDone = true;
            }
        }

        if (UIManager.Instance.isSlot3Active == true)
        {
            if (UIManager.Instance.objectInSlot3.name.Contains(objectToInterractWith))
            {
                if (buttonOneDone == false)
                {
                    buttonimage2.sprite = emptySlot.GetComponent<Image>().sprite;
                    button2.enabled = false;
                    scotchRight.SetActive(true);
                }
                else
                {
                    buttonimage2.sprite = emptySlot.GetComponent<Image>().sprite;
                    button2.enabled = false;
                    allScotch.SetActive(true);
                }
                UIManager.Instance.inventoryButton3.sprite = baseSlotSprite.sprite;
                UIManager.Instance.inventoryButton3.GetComponent<Image>().enabled = false;
                UIManager.Instance.objectInSlot3 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot3Active = false;
                UIManager.Instance.isSlot3Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object3Equipped.SetActive(false);
                InteractionOff = true;
                Destroy(button2);
                buttonTwoDone = true;
            }
        }
    }

    private void Update()
    {
        if(buttonOneDone == true && buttonTwoDone == true)
        {
            GameManager.Instance.N03T02energy = true;
            transform.parent.GetComponent<QuitPopUp>().QuitInterraction();
            Destroy(GameObject.Find(transform.parent.GetComponent<QuitPopUp>().popUpName));
        }
    }

}

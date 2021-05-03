using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public Image baseSlotSprite;
    public GameObject emptySlot;

    public Button button1;
    public Button button2;

    public Image buttonimage1;
    public Image buttonimage2;

    private bool InteractionOff;

    private InterractableWithInventory parent;


    public void InterractionButtonOne()
    {
        if (UIManager.Instance.isSlot1Active == true)
        {
            if (UIManager.Instance.objectInSlot1.name.Contains(parent.objectToInterractWith))
            {
                buttonimage1.sprite = UIManager.Instance.inventoryButton1.sprite;
                UIManager.Instance.inventoryButton1.sprite = baseSlotSprite.sprite;
                UIManager.Instance.inventoryButton1.GetComponent<Image>().enabled = false;
                UIManager.Instance.objectInSlot1 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot1Active = false;
                UIManager.Instance.isSlot1Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object1Equipped.SetActive(false);
                InteractionOff = true;
                Destroy(button1);
            }
        }

        if (UIManager.Instance.isSlot2Active == true)
        {
            if (UIManager.Instance.objectInSlot2.name.Contains(parent.objectToInterractWith))
            {
                buttonimage1.sprite = UIManager.Instance.inventoryButton2.sprite;
                UIManager.Instance.inventoryButton2.sprite = baseSlotSprite.sprite;
                UIManager.Instance.objectInSlot2 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot2Active = false;
                UIManager.Instance.isSlot2Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object2Equipped.SetActive(false);
                InteractionOff = true;
            }
        }

        if (UIManager.Instance.isSlot3Active == true)
        {
            if (UIManager.Instance.objectInSlot3.name.Contains(parent.objectToInterractWith))
            {
                buttonimage1.sprite = UIManager.Instance.inventoryButton3.sprite;
                UIManager.Instance.inventoryButton3.sprite = baseSlotSprite.sprite;
                UIManager.Instance.objectInSlot3 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot3Active = false;
                UIManager.Instance.isSlot3Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object3Equipped.SetActive(false);
                InteractionOff = true;
            }
        }
    }

    public void InterractionButtonTwo()
    {
        if (UIManager.Instance.isSlot1Active == true)
        {
            if (UIManager.Instance.objectInSlot1.name.Contains(parent.objectToInterractWith))
            {
                buttonimage2.sprite = UIManager.Instance.inventoryButton1.sprite;
                UIManager.Instance.inventoryButton1.sprite = baseSlotSprite.sprite;
                UIManager.Instance.inventoryButton1.GetComponent<Image>().enabled = false;
                UIManager.Instance.objectInSlot1 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot1Active = false;
                UIManager.Instance.isSlot1Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object1Equipped.SetActive(false);
                InteractionOff = true;
            }
        }

        if (UIManager.Instance.isSlot2Active == true)
        {
            if (UIManager.Instance.objectInSlot2.name.Contains(parent.objectToInterractWith))
            {
                buttonimage2.sprite = UIManager.Instance.inventoryButton2.sprite;
                UIManager.Instance.inventoryButton2.sprite = baseSlotSprite.sprite;
                UIManager.Instance.objectInSlot2 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot2Active = false;
                UIManager.Instance.isSlot2Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object2Equipped.SetActive(false);
                InteractionOff = true;
            }
        }

        if (UIManager.Instance.isSlot3Active == true)
        {
            if (UIManager.Instance.objectInSlot3.name.Contains(parent.objectToInterractWith))
            {
                buttonimage2.sprite = UIManager.Instance.inventoryButton3.sprite;
                UIManager.Instance.inventoryButton3.sprite = baseSlotSprite.sprite;
                UIManager.Instance.objectInSlot3 = GameObject.Find("Empty Slot");
                UIManager.Instance.isSlot3Active = false;
                UIManager.Instance.isSlot3Full = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object3Equipped.SetActive(false);
                InteractionOff = true;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N01T02Door : MonoBehaviour
{
    public Image baseSlotSprite;
    public GameObject emptySlot;
    public GameObject door;
    public Animator doorAnimator;


    private InterractableWithInventory parent;
    public string doorOpenedNearText;
    public string doorOpenedFarText;

    void Start()
    {
        parent = transform.parent.GetComponent<InterractableWithInventory>();
    }

    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;
            if (UIManager.Instance.isSlot1Active == true)
            {
                if (UIManager.Instance.objectInSlot1.name.Contains(parent.objectToInterractWith))
                {
                    UIManager.Instance.inventoryButton1.sprite = baseSlotSprite.sprite;
                    UIManager.Instance.inventoryButton1.GetComponent<Image>().enabled = false;
                    UIManager.Instance.objectInSlot1 = GameObject.Find("Empty Slot");
                    UIManager.Instance.isSlot1Active = false;
                    UIManager.Instance.object1Equipped.SetActive(false);
                    FindObjectOfType<AudioManager>().Play("UseKey");
                    doorAnimator.SetTrigger("Opened");
                    door.SetActive(true);
                    GameManager.Instance.globalInterractionSecurity = false;
                    
                    transform.parent.GetComponent<InterractableWithInventory>().nearPhrase = doorOpenedNearText;
                    transform.parent.GetComponent<InterractableWithInventory>().farPhrase = doorOpenedFarText;

                    transform.parent.GetComponent<BoxCollider2D>().enabled = false;

                }
            }

            else if (UIManager.Instance.isSlot2Active == true)
            {
                if (UIManager.Instance.objectInSlot2.name.Contains(parent.objectToInterractWith))
                {
                    UIManager.Instance.inventoryButton2.sprite = baseSlotSprite.sprite;
                    UIManager.Instance.objectInSlot2 = GameObject.Find("Empty Slot");
                    UIManager.Instance.isSlot2Active = false;
                    UIManager.Instance.object2Equipped.SetActive(false);
                    FindObjectOfType<AudioManager>().Play("UseKey");
                    doorAnimator.SetTrigger("Opened");
                    door.SetActive(true);
                    GameManager.Instance.globalInterractionSecurity = false;

                    transform.parent.GetComponent<BoxCollider2D>().enabled = false;
                }
            }

            else if (UIManager.Instance.isSlot3Active == true)
            {
                if (UIManager.Instance.objectInSlot3.name.Contains(parent.objectToInterractWith))
                {
                    UIManager.Instance.inventoryButton3.sprite = baseSlotSprite.sprite;
                    UIManager.Instance.objectInSlot3 = GameObject.Find("Empty Slot");
                    UIManager.Instance.isSlot3Active = false;
                    UIManager.Instance.object3Equipped.SetActive(false);
                    FindObjectOfType<AudioManager>().Play("UseKey");
                    doorAnimator.SetTrigger("Opened");
                    door.SetActive(true);
                    GameManager.Instance.globalInterractionSecurity = false;
                    transform.parent.GetComponent<BoxCollider2D>().enabled = false;
                }
            }

        }

    }
}


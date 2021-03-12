using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    public Image baseSlotSprite;
    public GameObject emptySlot;
    public GameObject door;


    private InterractableWithInventory parent;

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
                    UIManager.Instance.objectInSlot1 = emptySlot;
                    UIManager.Instance.isSlot1Active = false;
                    UIManager.Instance.object1Equipped.SetActive(false);
                    FindObjectOfType<AudioManager>().Play("UseLever");
                    door.GetComponent<N01T01Door>().isLeverOn = true;
                    
                }
            }

            if (UIManager.Instance.isSlot2Active == true)
            {
                if (UIManager.Instance.objectInSlot2.name.Contains(parent.objectToInterractWith))
                {
                    UIManager.Instance.inventoryButton2.sprite = baseSlotSprite.sprite;
                    UIManager.Instance.objectInSlot2 = emptySlot;
                    UIManager.Instance.isSlot2Active = false;
                    UIManager.Instance.object2Equipped.SetActive(false);
                    FindObjectOfType<AudioManager>().Play("UseLever");
                    door.GetComponent<N01T01Door>().isLeverOn = true;
                }
            }

            if (UIManager.Instance.isSlot3Active == true)
            {
                if (UIManager.Instance.objectInSlot3.name.Contains(parent.objectToInterractWith))
                {
                    UIManager.Instance.inventoryButton3.sprite = baseSlotSprite.sprite;
                    UIManager.Instance.objectInSlot3 = emptySlot;
                    UIManager.Instance.isSlot3Active = false;
                    UIManager.Instance.object3Equipped.SetActive(false);
                    FindObjectOfType<AudioManager>().Play("UseLever");
                    door.GetComponent<N01T01Door>().isLeverOn = true;
                }
            }

        }

    }
}
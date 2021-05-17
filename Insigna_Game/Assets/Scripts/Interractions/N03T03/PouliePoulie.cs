using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PouliePoulie : MonoBehaviour
{

    public InterractableWithInventory parent;
    public Image baseSlotSprite;
    public GameObject emptySlot;

    public GameObject pouliedubas;

    void Start()
    {
        parent = transform.parent.GetComponent<InterractableWithInventory>();
    }

    void Update()
    {

        parent.interractionSecurity = true;
        if (UIManager.Instance.isSlot1Active == true)
        {
            if (UIManager.Instance.objectInSlot1.name.Contains(parent.objectToInterractWith))
            {
                UIManager.Instance.isSlot1Active = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object1Equipped.SetActive(false);
                pouliedubas.SetActive(true);
                Destroy(this.transform.parent.gameObject);
            }
        }

        if (UIManager.Instance.isSlot2Active == true)
        {
            if (UIManager.Instance.objectInSlot2.name.Contains(parent.objectToInterractWith))
            {
                UIManager.Instance.isSlot2Active = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object2Equipped.SetActive(false);
                pouliedubas.SetActive(true);
                Destroy(this.transform.parent.gameObject);
            }
        }

        if (UIManager.Instance.isSlot3Active == true)
        {
            if (UIManager.Instance.objectInSlot3.name.Contains(parent.objectToInterractWith))
            {
                UIManager.Instance.isSlot3Active = false;
                UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                UIManager.Instance.object3Equipped.SetActive(false);
                pouliedubas.SetActive(true);
                Destroy(this.transform.parent.gameObject);
            }
        }

    }

}





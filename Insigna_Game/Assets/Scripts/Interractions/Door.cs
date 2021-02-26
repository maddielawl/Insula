using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Image baseSlotSprite;
    public GameObject emptySlot;

    private Interractable parent;

    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
    }

    void Update()
    {
        if(parent.interractionSecurity == false)
        {
            if(UIManager.Instance.isSlot1Active == true)
            {
                if(UIManager.Instance.objectInSlot1.name.Contains("Key"))
                {
                Destroy(transform.parent.gameObject);
                }
            }

            if(UIManager.Instance.isSlot2Active == true)
            {
                if(UIManager.Instance.objectInSlot2.name.Contains("Key"))
                {
                Destroy(transform.parent.gameObject);
                }
            }

            if(UIManager.Instance.isSlot3Active == true)
            {
                if(UIManager.Instance.objectInSlot3.name.Contains("Key"))
                {
                Destroy(transform.parent.gameObject);
                }
            }
            
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    public string gridSfx = "event:/SFX/Environment Sounds/Grid Open";

    public Image baseSlotSprite;
    public GameObject emptySlot;
    public GameObject door;

    public GameObject leverStickSprite;
    public Animator leverAnimator;
    public Animator GrilleAnimator;

    private bool InteractionOff;


    private InterractableWithInventory parent;

    public Interractable doorInteractScript;
    public string leverAxtivatedText;
    public TMPro.TextMeshProUGUI leverText;

    void Start()
    {
        parent = transform.parent.GetComponent<InterractableWithInventory>();
        leverStickSprite.SetActive(false);
    }

    void Update()
    {
        if (parent.interractionSecurity == false && InteractionOff == false)
        {
            parent.interractionSecurity = true;
            if (UIManager.Instance.isSlot1Active == true)
            {
                if (UIManager.Instance.objectInSlot1.name.Contains(parent.objectToInterractWith))
                {
                    FMODUnity.RuntimeManager.PlayOneShot(gridSfx);
                    leverText.text = leverAxtivatedText;
                    UIManager.Instance.inventoryButton1.sprite = baseSlotSprite.sprite;
                    UIManager.Instance.inventoryButton1.GetComponent<Image>().enabled = false;
                    UIManager.Instance.objectInSlot1 = emptySlot;
                    UIManager.Instance.isSlot1Active = false;
                    UIManager.Instance.isSlot1Full = false;
                    UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                    UIManager.Instance.object1Equipped.SetActive(false);
                    FindObjectOfType<AudioManager>().Play("UseLever");
                    door.GetComponent<N01T01Door>().isLeverOn = true;

                    leverStickSprite.SetActive(true);
                    leverAnimator.SetTrigger("LeverActivated");
                    GrilleAnimator.SetTrigger("Open");
                    parent.GetComponent<BoxCollider2D>().enabled = false;

                    InteractionOff = true;
                }
            }

            if (UIManager.Instance.isSlot2Active == true)
            {
                if (UIManager.Instance.objectInSlot2.name.Contains(parent.objectToInterractWith))
                {
                    //transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshPro>().text = doorOpenedText;
                    UIManager.Instance.inventoryButton2.sprite = baseSlotSprite.sprite;
                    UIManager.Instance.objectInSlot2 = emptySlot;
                    UIManager.Instance.isSlot2Active = false;
                    UIManager.Instance.isSlot2Full = false;
                    UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                    UIManager.Instance.object2Equipped.SetActive(false);
                    FindObjectOfType<AudioManager>().Play("UseLever");
                    door.GetComponent<N01T01Door>().isLeverOn = true;
                    leverStickSprite.SetActive(true);
                    leverAnimator.SetTrigger("LeverActivated");
                    GrilleAnimator.SetTrigger("Open");
                    parent.GetComponent<BoxCollider2D>().enabled = false;
                    InteractionOff = true;
                }
            }

            if (UIManager.Instance.isSlot3Active == true)
            {
                if (UIManager.Instance.objectInSlot3.name.Contains(parent.objectToInterractWith))
                {
                    //transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshPro>().text = doorOpenedText;
                    UIManager.Instance.inventoryButton3.sprite = baseSlotSprite.sprite;
                    UIManager.Instance.objectInSlot3 = emptySlot;
                    UIManager.Instance.isSlot3Active = false;
                    UIManager.Instance.isSlot3Full = false;
                    UIManager.Instance.oneSlotAtTheTimeSecurity = false;
                    UIManager.Instance.object3Equipped.SetActive(false);
                    FindObjectOfType<AudioManager>().Play("UseLever");
                    door.GetComponent<N01T01Door>().isLeverOn = true;

                    leverStickSprite.SetActive(true);
                    leverAnimator.SetTrigger("LeverActivated");
                    GrilleAnimator.SetTrigger("Open");
                    parent.GetComponent<BoxCollider2D>().enabled = false;
                    InteractionOff = true;
                }
            }

        }

    }
}

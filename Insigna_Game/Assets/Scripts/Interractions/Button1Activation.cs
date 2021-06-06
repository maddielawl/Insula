using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Activation : MonoBehaviour
{
    private Interractable parent;
    private ButtonL02 button;

    public GameObject ladder;
    public GameObject bloqueur;
    public GameObject ladderInteraction;
    public Animator LadderAnimator;
    public GameObject ladderButtonOff;
    public GameObject ladderButtonOn;
    [Space(10)]

    public BoxCollider2D buttonBC;
    public BoxCollider2D lever1BC;
    public BoxCollider2D lever2BC;
    public BoxCollider2D lever3BC;
    public BoxCollider2D lever4BC;

    private bool oneTime = false;

    private void Start()
    {
        button = transform.parent.GetComponent<ButtonL02>();
        parent = transform.parent.GetComponent<Interractable>();
        ladderInteraction.SetActive(false);
        ladderButtonOff.SetActive(true);
        ladderButtonOn.SetActive(false);
    }

    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;
            if (button.lever1 == 2 && button.lever2 == 1 && button.lever3 == 0 && button.lever4 == 2 && oneTime == false)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Environment Sounds/Ladder fall");
                LadderAnimator.SetTrigger("Fall");
                bloqueur.SetActive(false);
                ladderInteraction.SetActive(true);
                ladder.SetActive(true);
                ladderButtonOff.SetActive(false);
                ladderButtonOn.SetActive(true);
                buttonBC.enabled = false;
                lever1BC.enabled = false;
                lever2BC.enabled = false;
                lever3BC.enabled = false;
                lever4BC.enabled = false;
                oneTime = true;
            }
        }
    }
}

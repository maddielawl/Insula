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

    private bool oneTime = false;

    private void Start()
    {
        button = transform.parent.GetComponent<ButtonL02>();
        parent = transform.parent.GetComponent<Interractable>();
        ladderInteraction.SetActive(false);

    }

    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;
            if (button.lever1 == 2 && button.lever2 == 1 && button.lever3 == 0 && button.lever4 == 2 && oneTime == false)
            {
                LadderAnimator.SetTrigger("Fall");
                bloqueur.SetActive(false);
                ladderInteraction.SetActive(true);
                ladder.SetActive(true);
                oneTime = true;
            }
        }
    }
}

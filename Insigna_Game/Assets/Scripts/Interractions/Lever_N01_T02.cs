using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever_N01_T02 : MonoBehaviour
{
    public Animator leverAnimator;
    public GameObject Grille;

    private bool InteractionOff;


    private Interractable parent;

    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
    }

    void Update()
    {
        if (parent.interractionSecurity == false && InteractionOff == false)
        {
            parent.interractionSecurity = true;
            FindObjectOfType<AudioManager>().Play("UseLever");

            leverAnimator.SetTrigger("LeverActivated");
            Grille.SetActive(false);
            parent.GetComponent<BoxCollider2D>().enabled = false;
            InteractionOff = true;
        }

    }
}

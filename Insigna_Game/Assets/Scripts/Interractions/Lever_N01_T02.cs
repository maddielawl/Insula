using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever_N01_T02 : MonoBehaviour
{
    public GameObject grilleGO;
    public Animator leverAnimator;
    public Animator Grille;

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
            Grille.SetTrigger("Opened");
            parent.GetComponent<BoxCollider2D>().enabled = false;
            InteractionOff = true;
            StartCoroutine(DestroyGrille());
        }

    }

    IEnumerator DestroyGrille()
    {
        yield return new WaitForSeconds(1f);
        Destroy(grilleGO);
    }
}

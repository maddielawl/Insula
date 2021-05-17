using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vents : MonoBehaviour
{
    public GameObject inside;
    public GameObject outside;

    public bool isInside = false;

    public Animator playerAnim;
    public RuntimeAnimatorController characterBasicAC;
    public AnimatorOverrideController characterVentAOC;

    private void Start()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }


    public void GetInside(GameObject thenear)
    {
        Debug.Log("InsideVent");
        outside.SetActive(false);
        inside.SetActive(true);
        playerAnim.runtimeAnimatorController = characterVentAOC;
    }

    public void GetOutside(GameObject thenear)
    {
        Debug.Log("OutsideVent");
        inside.SetActive(false);
        outside.SetActive(true);
        playerAnim.runtimeAnimatorController = characterBasicAC;
    }

}

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


    public void GetInside(GameObject thenear) 
    {
        outside.SetActive(false);
        inside.SetActive(true);
        playerAnim.runtimeAnimatorController = characterVentAOC;
    }

    public void GetOutside(GameObject thenear)
    {
        inside.SetActive(false);
        outside.SetActive(true);
        playerAnim.runtimeAnimatorController = characterBasicAC;
    }

}

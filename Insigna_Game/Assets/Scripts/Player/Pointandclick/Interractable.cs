using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interractable : MonoBehaviour
{
    public PlayerInput playerInputs;

    public bool isNear = false;

    private GameObject nearInt0;
    private GameObject farInt1;

    private GameObject nearIndic;

    private GameObject farIndic;

    private GameObject farNearIndic;

    private bool security = false;
    private bool isInterractableOn = false;

    private bool cursorOn = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RangeNear"))
        {
            isNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("RangeNear"))
        {
            isNear = false;
        }
    }

    private void Start()
    {
        
        nearInt0 = transform.GetChild(0).gameObject;
        nearInt0.SetActive(false);
        farInt1 = transform.GetChild(1).gameObject;
        farInt1.SetActive(false);
        nearIndic = transform.GetChild(2).gameObject;
        nearIndic.SetActive(false);
        farIndic = transform.GetChild(3).gameObject;
        farIndic.SetActive(false);
        farNearIndic = transform.GetChild(4).gameObject;
        farNearIndic.SetActive(false);
    }

    private void Update()
    {
        if (isNear == true && isInterractableOn == true)
        {
            UIManager.Instance.SetNearCursor();
        }
        if (isNear == false && isInterractableOn == true)
        {
            UIManager.Instance.SetFarCursor();
        }

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (security == false)
            {
            if(cursorOn == true)
            {
                StartCoroutine(FarInterraction());
                security = true;
            }
            }
        }
    }

    public void OnUse(InputAction.CallbackContext context)
    {
            if(context.started)
        {
            if (security == false){
            if(cursorOn == true)
            {
                if(isNear == true)
                {
                    StartCoroutine(NearInterraction());
                    security = true;
                }
            }
            }
        }
    }

    private void OnMouseEnter()
    {
        if (isNear == true)
        {
            UIManager.Instance.SetNearCursor();
            farNearIndic.SetActive(true);
            nearIndic.SetActive(true);
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
        if (isNear == false)
        {
            UIManager.Instance.SetFarCursor();
            farIndic.SetActive(true);
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
    }

    private void OnMouseExit()
    {
        UIManager.Instance.ResetCursor();
        nearIndic.SetActive(false);
        farIndic.SetActive(false);
        farNearIndic.SetActive(false);
        isInterractableOn = false;
        cursorOn = false;
    }

    private IEnumerator NearInterraction()
    {
        nearInt0.SetActive(true);
        
        yield return new WaitForSeconds(5f);
        
        nearInt0.SetActive(false);
        security = false;

        yield return 0;
    }
    private IEnumerator FarInterraction()
    {
        farInt1.SetActive(true);

        yield return new WaitForSeconds(5f);
        
        farInt1.SetActive(false);
        security = false;
        
        yield return 0;

    }
}

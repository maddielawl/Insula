using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthPack : MonoBehaviour
{


    // Déclaration du joueur et du playerinput pour gérer l'interraction depuis les inputs du joueur.
    private PlayerInput playerInputs;
    private GameObject player;

    // Bool qui indique si le joueur est proche de l'objet ou non
    public bool isNear = false;
    private GameObject farInt0;

    // Les interractions si on est proche ou loin etc, elles sont déclarées dans un ordre précis
    private GameObject nearIndic1;

    private GameObject farIndic2;

    private GameObject farNearIndic3;

    // Bool si l'intéraction est possible et une sécurité pour ne pas afficher deux fois l'interraction.
    private bool security = false;
    private bool isInterractableOn = false;

    // Un bool qui indique si le curseur est devant l'objet.
    private bool cursorOn = false;

    // Sécurise les interractions pour qu'elles ne se lancent pas au moment de l'interaction.
    private bool interractionSecurity = true;
    
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
        player = GameObject.FindGameObjectWithTag("Player");
        playerInputs = player.GetComponent<PlayerInput>();
        farInt0 = transform.GetChild(0).gameObject;
        farInt0.SetActive(false);
        nearIndic1 = transform.GetChild(1).gameObject;
        nearIndic1.SetActive(false);
        farIndic2 = transform.GetChild(2).gameObject;
        farIndic2.SetActive(false);
        farNearIndic3 = transform.GetChild(3).gameObject;
        farNearIndic3.SetActive(false);
        interractionSecurity = false;
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
                    StartCoroutine(AddPackInInventory());
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
            farNearIndic3.SetActive(true);
            nearIndic1.SetActive(true);
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
        if (isNear == false)
        {
            UIManager.Instance.SetFarCursor();
            farIndic2.SetActive(true);
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
    }

    private void OnMouseExit()
    {
        UIManager.Instance.ResetCursor();
        nearIndic1.SetActive(false);
        farIndic2.SetActive(false);
        farNearIndic3.SetActive(false);
        isInterractableOn = false;
        cursorOn = false;
    }

    private IEnumerator AddPackInInventory()
    {
        GameManager.Instance.playerPillsCount++;
        Destroy(this.gameObject);
        Debug.Log("HP Count" + GameManager.Instance.playerPillsCount);

        yield return 0;
    }
    private IEnumerator FarInterraction()
    {
        farInt0.SetActive(true);

        yield return new WaitForSeconds(5f);
        
        farInt0.SetActive(false);
        security = false;
        
        yield return 0;

    }
}

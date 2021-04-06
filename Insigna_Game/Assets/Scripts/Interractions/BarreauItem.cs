using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class BarreauItem : MonoBehaviour
{
    // Déclaration du joueur et du playerinput pour gérer l'interraction depuis les inputs du joueur.
    private PlayerInput playerInputs;
    private GameObject player;

    // Bool qui indique si le joueur est proche de l'objet ou non
    public bool isNear = false;
    private GameObject farInt0;



    // Bool si l'intéraction est possible et une sécurité pour ne pas afficher deux fois l'interraction.
    private bool security = false;
    private bool isInterractableOn = false;

    // Un bool qui indique si le curseur est devant l'objet.
    private bool cursorOn = false;

    // Sécurise les interractions pour qu'elles ne se lancent pas au moment de l'interaction.
    private bool interractionSecurity = true;

    // Store L'object que l'on as besoin et le bool de sécurité pour celui ci
    private bool itemSecurity = false;

    public GameObject vfx;
    public GameObject barreau;

    [Header("Phrase a dire")]
    public string farPhrase;
    public string nearPhrase;

    private TextMeshProUGUI observationText;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RangeNear"))
        {
            isNear = true;
        }
        if (cursorOn == true)
        {
            UIManager.Instance.SetNearCursor();
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("RangeNear"))
        {
            isNear = false;
        }
        if (cursorOn == true)
        {
            UIManager.Instance.SetFarCursor();
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInputs = player.GetComponent<PlayerInput>();
        playerInputs.actions.FindAction("Look").started += OnLook;
        playerInputs.actions.FindAction("Use").started += OnUse;
        farInt0 = transform.GetChild(0).gameObject;
        observationText = farInt0.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        farInt0.SetActive(false);
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
            if (!GameManager.Instance.globalInterractionSecurity)
            {
                if (security == false)
                {
                    if (cursorOn == true)
                    {
                        if (isNear == false)
                        {
                            StartCoroutine(FarInterraction());
                            security = true;
                            GameManager.Instance.globalInterractionSecurity = true;
                            return;
                        }
                        if (isNear == true)
                        {
                            StartCoroutine(FarNearInterraction());
                            security = true;
                            GameManager.Instance.globalInterractionSecurity = true;
                            return;
                        }
                    }
                }
            }
        }
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!GameManager.Instance.globalInterractionSecurity)
            {
                if (security == false)
                {

                    if (cursorOn == true)
                    {

                        if (isNear == true)
                        {
                            GameManager.Instance.globalInterractionSecurity = true;
                            barreau.SetActive(false);
                            StartCoroutine(StoreItem());
                            FindObjectOfType<AudioManager>().Play("TakeObject");
                            GameObject currentVfx = Instantiate(vfx, transform.position, transform.rotation);
                            currentVfx.transform.parent = null;
                            Destroy(currentVfx, 3f);
                            security = true;
                            
                        }
                    }
                }
            }
        }
    }


      private IEnumerator StoreItem()
    {
        GameManager.Instance.globalInterractionSecurity = false;
        UIManager.Instance.GetObjectInInventory(this.gameObject);
        this.gameObject.SetActive(false);

        yield return 0;
    }

    private void OnMouseEnter()
    {
        if (isNear == true)
        {
            UIManager.Instance.SetNearCursor();
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
        if (isNear == false)
        {
            UIManager.Instance.SetFarCursor();
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
        
    }

    private void OnMouseExit()
    {
        UIManager.Instance.ResetCursor();
        isInterractableOn = false;
        cursorOn = false;
    }

    private IEnumerator AddPackInInventory()
    {
        GameManager.Instance.canEquipHelmet = true;
        GameManager.Instance.globalInterractionSecurity = false;
        Destroy(this.gameObject);

        yield return 0;
    }
    private IEnumerator FarInterraction()
    {
        farInt0.SetActive(true);
        observationText.text = farPhrase;

        yield return new WaitForSeconds(5f);
        
        farInt0.SetActive(false);
        security = false;
        GameManager.Instance.globalInterractionSecurity = false;

        yield return 0;

    }
    private IEnumerator FarNearInterraction()
    {
        farInt0.SetActive(true);
        observationText.text = nearPhrase;

        yield return new WaitForSeconds(5f);

        farInt0.SetActive(false);
        security = false;
        GameManager.Instance.globalInterractionSecurity = false;

        yield return 0;

    }
}
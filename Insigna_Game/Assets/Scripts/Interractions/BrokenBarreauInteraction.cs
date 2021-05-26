using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BrokenBarreauInteraction : MonoBehaviour
{

    public string barreauSfx = "event:/SFX/Environment Sounds/Metal Bar";

    // Déclaration du joueur et du playerinput pour gérer l'interraction depuis les inputs du joueur.
    private PlayerInput playerInputs;
    private GameObject player;

    // Bool qui indique si le joueur est proche de l'objet ou non
    public bool isNear = false;

    // Les gameobjects qui défissent l'interraction elles sont délcarrées dans un ordre précis
    private GameObject nearInt0;
    private GameObject farInt1;

    // Bool si l'intéraction est possible et une sécurité pour ne pas afficher deux fois l'interraction.
    private bool security = false;
    private bool isInterractableOn = false;

    // Un bool qui indique si le curseur est devant l'objet.
    private bool cursorOn = false;

    // Sécurise les interractions pour qu'elles ne se lancent pas au moment de l'interaction.
    private bool interractionSecurity = true;
    public SpriteRenderer spriteHighlight;

    public GameObject vfx;

    public GameObject barreauBroken;
    public GameObject barreauInteraction;

    [Header("Phrase a dire")]
    public string farPhrase;
    public string nearPhrase;

    private TextMeshProUGUI observationText;

    public int portraitIdx = 0;
    public bool isInterractionTalkative = false;

    private TextMeshProUGUI[] interactionsTexts;


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
        nearInt0 = transform.GetChild(0).gameObject;
        nearInt0.SetActive(false);
        farInt1 = transform.GetChild(1).gameObject;
        observationText = farInt1.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        farInt1.SetActive(false);
        interractionSecurity = false;
        spriteHighlight.enabled = false;

        barreauInteraction.SetActive(false);
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (cursorOn == true && gameObject.activeSelf == true)
            {

                interactionsTexts = FindObjectsOfType<TextMeshProUGUI>();
                for (int i = 0; i < interactionsTexts.Length; i++)
                {
                    if (interactionsTexts[i] != null)
                    {
                        interactionsTexts[i].text = null;
                    }
                }

                if (isNear == false)
                {
                    if (GameManager.Instance.globalInterractionSecurity == true)
                    {
                        if (GameManager.Instance.isNear == true)
                        {
                            UIManager.Instance.HidePortraits();
                            GameObject.FindGameObjectWithTag("NearInt").SetActive(false);
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                        }
                        else
                        {
                            UIManager.Instance.HidePortraits();
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            GameObject.FindGameObjectWithTag("FarInt").SetActive(false);
                        }
                    }
                    UIManager.Instance.DisplayPortrait(portraitIdx);
                    StartCoroutine(FarInterraction());
                    security = true;
                    GameManager.Instance.globalInterractionSecurity = true;
                    return;
                }
                if (isNear == true)
                {
                    if (GameManager.Instance.globalInterractionSecurity == true)
                    {
                        if (GameManager.Instance.isNear == true)
                        {
                            UIManager.Instance.HidePortraits();
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            GameObject.FindGameObjectWithTag("NearInt").SetActive(false);
                        }
                        else
                        {
                            UIManager.Instance.HidePortraits();
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            GameObject.FindGameObjectWithTag("FarInt").SetActive(false);
                        }
                    }
                    UIManager.Instance.DisplayPortrait(portraitIdx);
                    StartCoroutine(FarNearInterraction());
                    security = true;
                    GameManager.Instance.globalInterractionSecurity = true;
                    return;
                }
            }
        }
    }



    public void OnUse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (cursorOn == true && gameObject.activeSelf == true)
            {

                interactionsTexts = FindObjectsOfType<TextMeshProUGUI>();
                for (int i = 0; i < interactionsTexts.Length; i++)
                {
                    if (interactionsTexts[i] != null)
                    {
                        interactionsTexts[i].text = null;
                    }
                }

                if (isNear == true)
                {
                    if (GameManager.Instance.globalInterractionSecurity == true)
                    {
                        if (GameManager.Instance.isNear == true)
                        {
                            UIManager.Instance.HidePortraits();
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            GameObject.FindGameObjectWithTag("NearInt").SetActive(false);
                        }
                        else
                        {
                            UIManager.Instance.HidePortraits();
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            GameObject.FindGameObjectWithTag("FarInt").SetActive(false);
                        }
                    }
                    FMODUnity.RuntimeManager.PlayOneShot(barreauSfx);
                    StartCoroutine(NearInterraction());
                    GameManager.Instance.globalInterractionSecurity = true;
                    spriteHighlight.enabled = false;
                    FindObjectOfType<AudioManager>().Play("OnClickInventory");
                    GameObject currentVfx = Instantiate(vfx, transform.position, transform.rotation);
                    currentVfx.transform.parent = null;
                    Destroy(currentVfx, 3f);
                    security = true;

                }
            }
        }
    }



    private void OnMouseEnter()
    {
        if (isNear == true)
        {
            spriteHighlight.enabled = true;
            UIManager.Instance.SetNearCursor();
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
        if (isNear == false)
        {
            spriteHighlight.enabled = true;
            UIManager.Instance.SetFarCursor();
            cursorOn = true;
            return;
        }
    }

    private void OnMouseExit()
    {
        spriteHighlight.enabled = false;
        UIManager.Instance.ResetCursor();
        isInterractableOn = false;
        cursorOn = false;
    }

    private IEnumerator NearInterraction()
    {
        transform.GetComponent<BoxCollider2D>().enabled = false;
        nearInt0.SetActive(true);
        GameManager.Instance.isNear = true;
        barreauBroken.GetComponent<Animator>().SetTrigger("Fall");
        Invoke("activateOtherInteraction", 1f);

        yield return new WaitForSeconds(5f);

        nearInt0.SetActive(false);
        security = false;
        interractionSecurity = false;
        GameManager.Instance.globalInterractionSecurity = false;
        UIManager.Instance.HidePortraits();

        yield return 0;
    }
    private IEnumerator FarInterraction()
    {
        farInt1.SetActive(true);
        observationText.text = farPhrase;
        GameManager.Instance.isNear = false;

        yield return new WaitForSeconds(5f);

        farInt1.SetActive(false);
        security = false;
        GameManager.Instance.globalInterractionSecurity = false;
        UIManager.Instance.HidePortraits();

        yield return 0;

    }
    private IEnumerator FarNearInterraction()
    {
        farInt1.SetActive(true);
        observationText.text = nearPhrase;
        GameManager.Instance.isNear = false;

        yield return new WaitForSeconds(5f);

        farInt1.SetActive(false);
        security = false;
        GameManager.Instance.globalInterractionSecurity = false;
        UIManager.Instance.HidePortraits();

        yield return 0;

    }

    public void activateOtherInteraction()
    {
        barreauInteraction.SetActive(true);
    }

    public void OnEnable()
    {
        if (playerInputs != null)
        {
            playerInputs.actions.FindAction("Look").started += OnLook;
            playerInputs.actions.FindAction("Use").started += OnUse;
        }
    }

    public void OnDisable()
    {
        if (playerInputs != null)
        {
            playerInputs.actions.FindAction("Look").started -= OnLook;
            playerInputs.actions.FindAction("Use").started -= OnUse;
        }
    }
}

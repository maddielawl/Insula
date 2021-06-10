using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class HealthPack : MonoBehaviour
{
    public string pillsSfx = "event:/SFX/UI/Pills";

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

    public Sprite highlight;
    private Sprite normalSpr;

    public GameObject vfx;

    [Header("Phrase a dire")]
    public string farPhrase;
    public string nearPhrase;

    private TextMeshProUGUI observationText;

    public int portraitIdx = 0;

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
        farInt0 = transform.GetChild(0).gameObject;
        observationText = farInt0.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        farInt0.SetActive(false);
        interractionSecurity = false;
        normalSpr = transform.GetComponent<SpriteRenderer>().sprite;
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (cursorOn == true && gameObject.activeSelf == true)
            {
                if (GameManager.Instance.hasInteracted)
                {
                    /*interactionsTexts = FindObjectsOfType<TextMeshProUGUI>();
                    for (int i = 0; i < interactionsTexts.Length; i++)
                    {
                        if (interactionsTexts[i] != null)
                        {
                            interactionsTexts[i].text = null;
                        }
                    }*/

                    GameManager.Instance.StopHidePortaitFonction();
                    GameManager.Instance.StopFarTextFonction();
                    GameManager.Instance.StopNearTextFonction();

                    if (GameManager.Instance.far_Text != null)
                    {
                        GameManager.Instance.far_Text.SetActive(false);
                    }
                    if (GameManager.Instance.near_Text != null)
                    {
                        GameManager.Instance.near_Text.SetActive(false);
                    }

                    UIManager.Instance.HidePortraits();
                    GameManager.Instance.hasInteracted = false;
                }

                if (GameManager.Instance.hasInteracted == false)
                {
                    GameManager.Instance.far_Text = farInt0;
                    GameManager.Instance.hasInteracted = true;
                    GameManager.Instance.StartHidePortaitFonction();
                    GameManager.Instance.StartFarTextFonction();
                }


                if (isNear == false)
                {
                    if (GameManager.Instance.globalInterractionSecurity == true)
                    {
                        if (GameManager.Instance.isNear == true)
                        {
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            if (GameObject.FindGameObjectWithTag("NearInt") != null)
                            {
                                GameObject.FindGameObjectWithTag("NearInt").SetActive(false);
                            }
                        }
                        else
                        {
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            if (GameObject.FindGameObjectWithTag("FarInt") != null)
                            {
                                GameObject.FindGameObjectWithTag("FarInt").SetActive(false);
                            }
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
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            if (GameObject.FindGameObjectWithTag("NearInt") != null)
                            {
                                GameObject.FindGameObjectWithTag("NearInt").SetActive(false);
                            }
                        }
                        else
                        {
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            if (GameObject.FindGameObjectWithTag("FarInt") != null)
                            {
                                GameObject.FindGameObjectWithTag("FarInt").SetActive(false);
                            }
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
        if (context.performed)
        {
            if (cursorOn == true && gameObject.activeSelf == true)
            {
                /*interactionsTexts = FindObjectsOfType<TextMeshProUGUI>();
                for (int i = 0; i < interactionsTexts.Length; i++)
                {
                    if (interactionsTexts[i] != null)
                    {
                        interactionsTexts[i].text = null;
                    }
                }*/

                if (isNear == true)
                {
                    if (GameManager.Instance.globalInterractionSecurity == true)
                    {
                        if (GameManager.Instance.isNear == true)
                        {
                            UIManager.Instance.HidePortraits();
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            if (GameObject.FindGameObjectWithTag("NearInt") != null)
                            {
                                GameObject.FindGameObjectWithTag("NearInt").SetActive(false);
                            }
                        }
                        else
                        {
                            UIManager.Instance.HidePortraits();
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            if (GameObject.FindGameObjectWithTag("FarInt") != null)
                            {
                                GameObject.FindGameObjectWithTag("FarInt").SetActive(false);
                            }
                        }
                    }
                    UIManager.Instance.HidePortraits();
                    StartCoroutine(AddPackInInventory());
                    FindObjectOfType<AudioManager>().Play("TakeObject");
                    GameObject currentVfx = Instantiate(vfx, transform.position, transform.rotation);
                    currentVfx.transform.parent = null;
                    Destroy(currentVfx, 3f);
                    security = true;
                    GameManager.Instance.globalInterractionSecurity = true;
                    Destroy(this.gameObject);
                }
            }
        }
    }



    private void OnMouseEnter()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI/Cursor Over");
        if (isNear == true)
        {
            transform.GetComponent<SpriteRenderer>().sprite = highlight;
            UIManager.Instance.SetNearCursor();
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
        if (isNear == false)
        {
            transform.GetComponent<SpriteRenderer>().sprite = highlight;
            UIManager.Instance.SetFarCursor();
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
    }

    private void OnMouseExit()
    {
        transform.GetComponent<SpriteRenderer>().sprite = normalSpr;
        UIManager.Instance.ResetCursor();
        isInterractableOn = false;
        cursorOn = false;
    }

    private IEnumerator AddPackInInventory()
    {
        FMODUnity.RuntimeManager.PlayOneShot(pillsSfx);
        GameManager.Instance.isNear = true;
        GameManager.Instance.playerPillsCount++;
        GameManager.Instance.globalInterractionSecurity = false;

        yield return 0;
    }
    private IEnumerator FarInterraction()
    {
        observationText.text = farPhrase;
        GameManager.Instance.isNear = false;

        yield return new WaitForSeconds(2.5f);

        security = false;
        GameManager.Instance.globalInterractionSecurity = false;

        yield return 0;

    }
    private IEnumerator FarNearInterraction()
    {
        observationText.text = nearPhrase;
        GameManager.Instance.isNear = false;

        yield return new WaitForSeconds(2.5f);

        security = false;
        GameManager.Instance.globalInterractionSecurity = false;

        StopCoroutine(FarNearInterraction());
        yield return 0;

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

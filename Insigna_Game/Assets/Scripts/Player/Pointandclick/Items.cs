using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class Items : MonoBehaviour
{
    // Déclaration du joueur et du playerinput pour gérer l'interraction depuis les inputs du joueur.
    private PlayerInput playerInputs;
    private GameObject player;

    // Bool qui indique si le joueur est proche de l'objet ou non
    public bool isNear = false;
    public GameObject nearInt0;
    public GameObject farInt0;



    // Bool si l'intéraction est possible et une sécurité pour ne pas afficher deux fois l'interraction.
    private bool security = false;
    private bool isInterractableOn = false;

    // Un bool qui indique si le curseur est devant l'objet.
    private bool cursorOn = false;

    // Sécurise les interractions pour qu'elles ne se lancent pas au moment de l'interaction.
    public bool interractionSecurity = false;

    // Store L'object que l'on as besoin et le bool de sécurité pour celui ci
    private bool itemSecurity = false;
    private Sprite spriteNormal;
    public Sprite spriteHighlight;
    public SpriteRenderer objectSpriteRenderer;

    public GameObject vfx;

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
        farInt0 = transform.GetChild(1).gameObject;
        observationText = farInt0.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        farInt0.SetActive(false);
        interractionSecurity = false;
        //objectSpriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteNormal = objectSpriteRenderer.sprite;
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
                    if (isInterractionTalkative)
                    {
                        if (GameManager.Instance.hasInteracted)
                        {
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
                            if (nearInt0 != null)
                            {
                                GameManager.Instance.near_Text = nearInt0;
                            }
                            GameManager.Instance.hasInteracted = true;
                            GameManager.Instance.StartHidePortaitFonction();
                            GameManager.Instance.StartNearTextFonction();
                        }
                    }

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
                    if (isInterractionTalkative == true)
                    {
                        UIManager.Instance.DisplayPortrait(portraitIdx);
                    }
                    else
                    {
                        UIManager.Instance.HidePortraits();
                    }
                    objectSpriteRenderer.sprite = spriteNormal;
                    StartCoroutine(NearInterraction());
                    GameManager.Instance.globalInterractionSecurity = true;
                    StartCoroutine(StoreItem());
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player Sounds/Collect Object");
                    FindObjectOfType<AudioManager>().Play("TakeObject");
                    GameObject currentVfx = Instantiate(vfx, transform.position, transform.rotation);
                    currentVfx.transform.parent = null;
                    Destroy(currentVfx, 3f);
                    security = true;
                    Destroy(gameObject.GetComponent<SpriteRenderer>());
                    Destroy(gameObject.GetComponent<BoxCollider2D>());
                }
            }
        }
    }




    private IEnumerator StoreItem()
    {
        GameManager.Instance.globalInterractionSecurity = false;
        UIManager.Instance.GetObjectInInventory(this.gameObject);

        yield return 0;
    }

    private void OnMouseEnter()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI/Cursor Over");
        if (isNear == true)
        {
            objectSpriteRenderer.sprite = spriteHighlight;
            UIManager.Instance.SetNearCursor();
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
        if (isNear == false)
        {
            objectSpriteRenderer.sprite = spriteHighlight;
            UIManager.Instance.SetFarCursor();
            isInterractableOn = true;
            cursorOn = true;
            return;
        }

    }

    private void OnMouseExit()
    {
        objectSpriteRenderer.sprite = spriteNormal;
        UIManager.Instance.ResetCursor();
        isInterractableOn = false;
        cursorOn = false;
    }

    private IEnumerator NearInterraction()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        objectSpriteRenderer.enabled = false;
        GameManager.Instance.isNear = true;

        yield return new WaitForSeconds(5f);

        security = false;
        interractionSecurity = false;
        GameManager.Instance.globalInterractionSecurity = false;

        yield return 0;
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
        observationText.text = farPhrase;
        GameManager.Instance.isNear = false;

        yield return new WaitForSeconds(5f);

        security = false;
        GameManager.Instance.globalInterractionSecurity = false;

        yield return 0;

    }
    private IEnumerator FarNearInterraction()
    {
        observationText.text = nearPhrase;
        GameManager.Instance.isNear = false;

        yield return new WaitForSeconds(5f);

        security = false;
        GameManager.Instance.globalInterractionSecurity = false;

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

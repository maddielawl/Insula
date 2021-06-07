using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Interractable : MonoBehaviour
{
    public string sfxToPlay;

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
    public bool interractionSecurity = true;
    public SpriteRenderer spriteHighlight;

    public GameObject vfx;

    [Header("Phrase a dire")]
    public string farPhrase;
    public string nearPhrase;

    [HideInInspector]
    public TextMeshProUGUI observationText;

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
            if (cursorOn == true)
            {
                UIManager.Instance.SetFarCursor();

            }
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInputs = player.GetComponent<PlayerInput>();
        playerInputs.actions.FindAction("Look").started += OnLook;
        playerInputs.actions.FindAction("Use").started += OnUse;
        if (transform.GetChild(0).gameObject.tag == "NearInt")
        {
            nearInt0 = transform.GetChild(0).gameObject;
            nearInt0.SetActive(false);
        }
        farInt1 = transform.GetChild(1).gameObject;
        observationText = farInt1.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        farInt1.SetActive(false);
        interractionSecurity = false;
        if (spriteHighlight != null)
        {
            spriteHighlight.enabled = false;
        }
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (cursorOn == true && gameObject.activeSelf == true)
            {

                GameManager.Instance.far_Text = farInt1;
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
                    GameManager.Instance.hasInteracted = true;
                    GameManager.Instance.StartHidePortaitFonction();
                    GameManager.Instance.StartFarTextFonction();
                }

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
                    if (nearInt0 != null)
                    {
                        GameManager.Instance.near_Text = nearInt0;
                    }
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
                        GameManager.Instance.hasInteracted = true;
                        GameManager.Instance.StartHidePortaitFonction();
                        GameManager.Instance.StartNearTextFonction();
                    }

                    if (sfxToPlay != null)
                    {
                        FMODUnity.RuntimeManager.PlayOneShot(sfxToPlay);
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
                    StartCoroutine(NearInterraction());
                    security = true;
                    GameManager.Instance.globalInterractionSecurity = true;
                }
            }
        }
    }



    private void OnMouseEnter()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI/Cursor Over");
        if (isNear == true)
        {
            if (spriteHighlight != null)
            {
                spriteHighlight.enabled = true;
            }
            UIManager.Instance.SetNearCursor();
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
        if (isNear == false)
        {
            if (spriteHighlight != null)
            {
                spriteHighlight.enabled = true;
            }
            UIManager.Instance.SetFarCursor();
            cursorOn = true;
            return;
        }
    }

    private void OnMouseExit()
    {
        if (spriteHighlight != null)
        {
            spriteHighlight.enabled = false;
        }
        UIManager.Instance.ResetCursor();
        isInterractableOn = false;
        cursorOn = false;
    }

    private IEnumerator NearInterraction()
    {
        GameManager.Instance.isNear = true;
        FindObjectOfType<AudioManager>().Play("OnClickInventory");
        if (vfx != null)
        {
            GameObject currentVfx = Instantiate(vfx, transform.position, transform.rotation);
            currentVfx.transform.parent = null;
            Destroy(currentVfx, 3f);
        }

        yield return new WaitForSeconds(0.5f);

        security = false;
        interractionSecurity = false;
        GameManager.Instance.globalInterractionSecurity = false;


        yield return 0;
    }
    private IEnumerator FarInterraction()
    {
        observationText.text = farPhrase;
        GameManager.Instance.isNear = false;

        yield return new WaitForSeconds(0.5f);

        security = false;
        GameManager.Instance.globalInterractionSecurity = false;


        yield return 0;

    }
    private IEnumerator FarNearInterraction()
    {
        observationText.text = nearPhrase;
        GameManager.Instance.isNear = false;

        yield return new WaitForSeconds(0.5f);

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

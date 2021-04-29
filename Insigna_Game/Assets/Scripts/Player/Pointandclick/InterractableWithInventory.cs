using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InterractableWithInventory : MonoBehaviour
{


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

    public SpriteRenderer[] objectSprite;
    private Sprite[] spriteNormal;
    public Sprite[] spriteHighlight;


    public string objectToInterractWith;

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
        nearInt0 = transform.GetChild(0).gameObject;
        nearInt0.SetActive(false);
        farInt1 = transform.GetChild(1).gameObject;
        observationText = farInt1.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        farInt1.SetActive(false);
        interractionSecurity = false;
        spriteNormal = new Sprite[objectSprite.Length];
        for (int i = 0; i < objectSprite.Length; i++)
        {
            spriteNormal[i] = objectSprite[i].sprite;
        }
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.started)
        {
                    if (cursorOn == true)
                    {
                        if (isNear == false)
                        {
                    if (GameManager.Instance.globalInterractionSecurity == true)
                    {
                        if (GameManager.Instance.isNear == true)
                        {
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            GameObject.FindGameObjectWithTag("NearInt").SetActive(false);
                        }
                        else
                        {
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            GameObject.FindGameObjectWithTag("FarInt").SetActive(false);
                        }
                    }
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
                            GameObject.FindGameObjectWithTag("NearInt").SetActive(false);
                        }
                        else
                        {
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            GameObject.FindGameObjectWithTag("FarInt").SetActive(false);
                        }
                    }
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
                    if (cursorOn)
                    {
                if (isNear == true)
                        {
                    if (GameManager.Instance.globalInterractionSecurity == true)
                    {
                        if (GameManager.Instance.isNear == true)
                        {
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            GameObject.FindGameObjectWithTag("NearInt").SetActive(false);
                        }
                        else
                        {
                            security = false;
                            GameManager.Instance.globalInterractionSecurity = false;
                            GameObject.FindGameObjectWithTag("FarInt").SetActive(false);
                        }
                    }
                    StartCoroutine(NearInterraction());
                            FindObjectOfType<AudioManager>().Play("OnClickInventory");
                            // GameObject currentVfx = Instantiate(vfx, transform.position, transform.rotation);
                            // currentVfx.transform.parent = null;
                            // Destroy(currentVfx, 3f);
                            security = true;
                            GameManager.Instance.globalInterractionSecurity = true;

                        }
                    }
                }
            }
        
    

    private void OnMouseEnter()
    {
        if (isNear == true)
        {
            for (int i = 0; i < objectSprite.Length; i++)
            {
                objectSprite[i].sprite = spriteHighlight[i];
            }


            if (UIManager.Instance.objectInSlot1.name.Contains(objectToInterractWith) && UIManager.Instance.isSlot1Active == true)
            {
                UIManager.Instance.SetInterractionCursor();
            }
            if (UIManager.Instance.objectInSlot2.name.Contains(objectToInterractWith) && UIManager.Instance.isSlot2Active == true)
            {
                UIManager.Instance.SetInterractionCursor();
            }
            if (UIManager.Instance.objectInSlot3.name.Contains(objectToInterractWith) && UIManager.Instance.isSlot3Active == true)
            {
                UIManager.Instance.SetInterractionCursor();
            }
            if (UIManager.Instance.isSlot3Active == false && UIManager.Instance.isSlot2Active == false && UIManager.Instance.isSlot1Active == false)
            {
                UIManager.Instance.SetNearCursor();
            }
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
        if (isNear == false)
        {
            for (int i = 0; i < objectSprite.Length; i++)
            {
                objectSprite[i].sprite = spriteHighlight[i];
            }
            UIManager.Instance.SetFarCursor();
            isInterractableOn = true;
            cursorOn = true;
            return;
        }
    }

    private void OnMouseExit()
    {
        for (int i = 0; i < objectSprite.Length; i++)
        {
            objectSprite[i].sprite = spriteNormal[i];
        }

        UIManager.Instance.ResetCursor();
        isInterractableOn = false;
        cursorOn = false;
    }

    private IEnumerator NearInterraction()
    {
        nearInt0.SetActive(true);
        GameManager.Instance.isNear = true;

        yield return new WaitForSeconds(5f);

        nearInt0.SetActive(false);
        security = false;
        interractionSecurity = false;
        GameManager.Instance.globalInterractionSecurity = false;

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

        yield return 0;

    }
}

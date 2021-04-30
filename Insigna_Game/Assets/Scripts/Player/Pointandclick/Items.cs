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
    private GameObject nearInt0;
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
    private Sprite spriteNormal;
    public Sprite spriteHighlight;
    private SpriteRenderer objectSpriteRenderer;

    public GameObject vfx;

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
        farInt0 = transform.GetChild(0).gameObject;
        observationText = farInt0.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        farInt0.SetActive(false);
        interractionSecurity = false;
        objectSpriteRenderer = transform.GetComponent<SpriteRenderer>();
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

                    if (cursorOn == true)
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
                            GameManager.Instance.globalInterractionSecurity = true;
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
        nearInt0.SetActive(true);
        GameManager.Instance.isNear = true;

        yield return new WaitForSeconds(5f);

        nearInt0.SetActive(false);
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
        farInt0.SetActive(true);
        observationText.text = farPhrase;
        GameManager.Instance.isNear = false;

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
        GameManager.Instance.isNear = false;

        yield return new WaitForSeconds(5f);

        farInt0.SetActive(false);
        security = false;
        GameManager.Instance.globalInterractionSecurity = false;

        yield return 0;

    }
}

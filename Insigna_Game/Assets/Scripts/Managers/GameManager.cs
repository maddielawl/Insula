using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    #region Singlton:Profile

    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        playerInput = new PlayerInputs();
    }
    #endregion

    [Header("Player Stats")]
    public float playerMadness;
    public int playerSanity;
    public int playerPillsCount;
    public int healAmmount = 30;
    public PlayerInputs playerInput;

    [Space(5)]
    [Header("Helmet")]
    public bool isHelmetEquipped = false;
    public bool canEquipHelmet = false;

    [Space(5)]
    [Header("Status Check")]
    public bool isScared;

    [Space(5)]
    [Header("MadnessZone")]
    public GameObject madnessZone;
    public GameObject sanityZone;
    [SerializeField]
    private bool dimensionSwapNormal;
    [SerializeField]
    private bool dimensionSwapMadness;

    public MadnessAppear indicible;
    public bool once;

    public bool globalInterractionSecurity = false;



    #region Madness Functions

    private void Start()
    {
        StartCoroutine("SanityDecrement");
        playerPillsCount = 0;
        dimensionSwapNormal = true;
    }




    public IEnumerator InsideMadnessZone(int sanityDmg, int madnessGain)
    {
        if (isScared == true)
        {
            if (isHelmetEquipped == true)
            {
                playerSanity = Mathf.Clamp(playerSanity, 0, 100);
                playerSanity++;
                playerSanity = Mathf.Clamp(playerSanity, 0, 100);
            }

            if (isHelmetEquipped == false)
            {
                playerSanity = Mathf.Clamp(playerSanity, 0, 100);
                playerSanity = playerSanity + sanityDmg;
                if (playerSanity >= 100)
                {
                    DeactivateInGameActions();
                    MenusManager.instance.GameOver();
                }
                playerSanity = Mathf.Clamp(playerSanity, 0, 100);
                playerMadness = Mathf.Clamp(playerMadness, 0, 100);
                playerMadness = playerMadness + madnessGain;
                if (playerMadness >= 80 && dimensionSwapMadness == true)
                {
                    indicible.SetAppear();
                    madnessZone.SetActive(true);
                    sanityZone.SetActive(false);
                    globalInterractionSecurity = false;
                    dimensionSwapMadness = false;
                    dimensionSwapNormal = true;

                }
                playerMadness = Mathf.Clamp(playerMadness, 0, 100);

            }
            yield return new WaitForSeconds(0.5f);
            if (isScared == true)
            {
                StartCoroutine(InsideMadnessZone(sanityDmg, madnessGain));
            }
        }

        yield return 0;
    }

    public IEnumerator SanityDecrement()
    {
        if (isScared == false)
        {
            if (isHelmetEquipped == false)
            {

                playerMadness = Mathf.Clamp(playerMadness, 0, 100);
                playerMadness = playerMadness - 1;
                if (playerMadness <= 50 && dimensionSwapNormal == true)
                {
                    if (once == true)
                    {
                        indicible.SetDisAppear();
                    }
                    if (once == false)
                    {
                        once = true;
                    }
                    madnessZone.SetActive(false);
                    sanityZone.SetActive(true);
                    globalInterractionSecurity = false;
                    dimensionSwapNormal = false;
                    dimensionSwapMadness = true;

                }
                playerMadness = Mathf.Clamp(playerMadness, 0, 100);

            }
            yield return new WaitForSeconds(0.5f);
            if (isScared == false)
            {
                StartCoroutine("SanityDecrement");
            }
        }

        yield return 0;
    }



    #endregion

    #region HP Fuctions


    public void GetHPBack()
    {
        playerSanity = Mathf.Clamp(playerSanity, 0, 100);
        playerSanity = playerSanity - healAmmount;
        playerSanity = Mathf.Clamp(playerSanity, 0, 100);
        playerPillsCount--;
    }

    #endregion

    public void ActivateInGameActions()
    {
        playerInput.Gameplay.Enable();
    }
    public void DeactivateInGameActions()
    {
        playerInput.Gameplay.Disable();
    }

}

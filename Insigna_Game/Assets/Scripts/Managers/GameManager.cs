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

    void Awake ()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy (gameObject);
        playerInput = new PlayerInput();
    }
    #endregion

    [Header("Player Stats")]
    public int playerMadness;
    public int playerSanity;
    public int playerPillsCount;
    public int healAmmount = 30 ;
    public PlayerInput playerInput;

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


    #region Madness Functions

    private void Start()
    {
        StartCoroutine("SanityDecrement");
    }


    public IEnumerator InsideMadnessZone(int sanityDmg)
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
                if(playerSanity >= 100)
                {
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                }
                playerSanity = Mathf.Clamp(playerSanity, 0, 100);
                playerMadness = Mathf.Clamp(playerMadness, 0, 100);
                playerMadness = playerMadness + 7;
                if (playerMadness >= 80)
                {
                    madnessZone.SetActive(true);
                }
                playerMadness = Mathf.Clamp(playerMadness, 0, 100);

            }
            yield return new WaitForSeconds(0.5f);
            if (isScared == true)
            {
                StartCoroutine(InsideMadnessZone(sanityDmg));
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
                playerMadness = playerMadness - 3;
                if(playerMadness <= 50)
                {
                    madnessZone.SetActive(false);
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
        playerInput.ActivateInput();
    }
    public void DeactivateInGameActions()
    {
        playerInput.DeactivateInput();
    }
    
}

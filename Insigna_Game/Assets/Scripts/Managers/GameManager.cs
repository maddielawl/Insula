using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }
    #endregion

    [Header("Player Stats")]
    public int playerSanity;
    public int playerMadness;
    public int playerPillsCount;
    public int healAmmount = 30 ;

    [Space(5)]
    [Header("Helmet")]
    public bool isHelmetEquipped = false;
    public bool canEquipHelmet = false;

    [Space(5)] 
    [Header("Status Check")] 
    public bool isScared;


    #region Madness Functions
    
    public IEnumerator InsideMadnessZone()
    {
        if (isScared == true)
        {
            if (isHelmetEquipped == true)
            {
                playerMadness = Mathf.Clamp(playerMadness, 0, 100);
                playerMadness++;
                playerMadness = Mathf.Clamp(playerMadness, 0, 100);
            }

            if (isHelmetEquipped == false)
            {
                playerMadness = Mathf.Clamp(playerMadness, 0, 100);
                playerMadness = playerMadness + 3;
                playerMadness = Mathf.Clamp(playerMadness, 0, 100);
                playerSanity = Mathf.Clamp(playerSanity, 0, 100);
                playerSanity = playerSanity + 7;
                playerSanity = Mathf.Clamp(playerSanity, 0, 100);

            }
            yield return new WaitForSeconds(0.5f);
            if (isScared == true)
            {
                StartCoroutine("InsideMadnessZone");
            }
        }
        
        Debug.Log("PlayerSanity" + playerSanity);
        Debug.Log(("playerMadness" + playerMadness));

        yield return 0;
    }
    
    #endregion

    #region HP Fuctions
    

    public void GetHPBack()
    {
        playerMadness = Mathf.Clamp(playerMadness, 0, 100);
        playerMadness = playerMadness - healAmmount;
        playerMadness = Mathf.Clamp(playerMadness, 0, 100);
        playerPillsCount--;
    }
    
    #endregion
    
}

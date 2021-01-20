using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Space(5)]
    [Header("Helmet")]
    public bool isHelmetEquipped = false;
    public bool canEquipHelmet = false;

    [Space(5)] 
    [Header("Status Check")] 
    public bool isScared;

    private void Start()
    {
        Mathf.Clamp(playerMadness, 0, 100);
        Mathf.Clamp(playerSanity, 0, 100);
    }

    public IEnumerator InsideMadnessZone()
    {
        if (isScared == true)
        {
            if (isHelmetEquipped == true)
            {
                Mathf.Clamp(playerMadness, 0, 100);
                playerMadness++;
                Mathf.Clamp(playerMadness, 0, 100);
            }

            if (isHelmetEquipped == false)
            {
                Mathf.Clamp(playerMadness, 0, 100);
                playerMadness = playerMadness + 3;
                Mathf.Clamp(playerMadness, 0, 100);
                Mathf.Clamp(playerSanity, 0, 100);
                playerSanity = playerSanity + 7;
                Mathf.Clamp(playerSanity, 0, 100);

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
}

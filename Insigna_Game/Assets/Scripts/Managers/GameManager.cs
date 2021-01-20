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
    public int playerHealth;
    public int playerSanity;
    public int playerMadness;
    public int playerPillsCount;

    [Space(5)]
    [Header("Helmet")]
    public bool isHelmetEquipped = false;
    public bool canEquipHelmet = false;
}

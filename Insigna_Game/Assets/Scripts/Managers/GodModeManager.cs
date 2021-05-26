using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GodModeManager : MonoBehaviour
{

    public GameObject player;
    public int sceneIndex;

    public GameObject ingameMainUI;
    public GameObject ingameGameOverUI;
    public GameObject godmodetext;

    public bool cheatsenabled = false;

    void Update()
    {
        if (cheatsenabled == false)
        {
            if (Input.GetKey(KeyCode.V) && Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.C))
            {
                cheatsenabled = true;
                UIManager.Instance.GotHelmet();
                GameManager.Instance.canEquipHelmet = true;
                DisplayText();
                Debug.Log("Cheats Enabled");
            }
        }

        if (cheatsenabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                sceneIndex = 0;
                reset();
                ltransition();
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                sceneIndex = 1;
                reset();
                ltransition();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                sceneIndex = 2;
                reset();
                ltransition();
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                sceneIndex = 3;
                reset();
                ltransition();
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                sceneIndex = 4;
                reset();
                ltransition();
            }
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                GameManager.Instance.playerMadness = 0;
            }
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                GameManager.Instance.playerMadness = 50;
            }
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                GameManager.Instance.playerMadness = 100;
                GameManager.Instance.ForceMadness();
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                GameManager.Instance.playerSanity = 50;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                GameManager.Instance.playerPillsCount++;
            }
        }
    }


    void reset()
    {
        ingameMainUI.SetActive(true);
        ingameGameOverUI.SetActive(false);
        GameManager.Instance.isScared = false;
        GameManager.Instance.playerMadness = 0;
        GameManager.Instance.playerSanity = 0;

        UIManager.Instance.isSlot1Full = false;
        UIManager.Instance.isSlot2Full = false;
        UIManager.Instance.isSlot3Full = false;

        UIManager.Instance.objectInSlot1 = GameObject.Find("Empty Slot");
        UIManager.Instance.objectInSlot2 = GameObject.Find("Empty Slot");
        UIManager.Instance.objectInSlot3 = GameObject.Find("Empty Slot");

        UIManager.Instance.inventoryButton1.GetComponent<Image>().enabled = false;
        UIManager.Instance.inventoryButton2.GetComponent<Image>().enabled = false;
        UIManager.Instance.inventoryButton3.GetComponent<Image>().enabled = false;

        UIManager.Instance.inventoryButton1.sprite = UIManager.Instance.normalInventorySpr;
        UIManager.Instance.inventoryButton2.sprite = UIManager.Instance.normalInventorySpr;
        UIManager.Instance.inventoryButton3.sprite = UIManager.Instance.normalInventorySpr;

        GameManager.Instance.playerPillsCount = 0;

        GameManager.Instance.dimensionSwapMadness = true;

    }

    void ltransition()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player Sounds/Level Transition");
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().StateMachine.CurrentState.Exit();
        MenusManager.instance.level2loaded = true;
        SceneManager.LoadScene(sceneIndex);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Level", sceneIndex);

    }

    void DisplayText()
    {
        godmodetext.SetActive(true);
        Invoke("HideText", 2f);
    }
    void HideText()
    {
        godmodetext.SetActive(false);
    }
    
}

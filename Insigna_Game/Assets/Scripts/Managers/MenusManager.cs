﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenusManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;
    public GameObject cursorManger;

    public GameObject MainMenuCamera;


    private GameInputs menusActions;
    private AsyncOperation asyncOp;

    public delegate void OnPressBack();
    private OnPressBack OnPressEscape;


    [Header("MAIN UI SECTIONS")]
    public GameObject menuBackground;
    public GameObject loadingScreen;
    public GameObject gameLogoImage;
    public GameObject splashScreen;
    public GameObject mainMenuScreen;
    public GameObject midOptionsScreen;
    public GameObject optionsScreen;
    public GameObject creditsScreen;
    public GameObject ingameMainUI;
    public GameObject ingamePauseMenu;
    public GameObject ingameGameOverUI;
    public GameObject endgameThanksScreen;
    public GameObject inGameOptions;
    public GameObject Cinematic;
    public GameObject PopUp;
    public GameObject GuideMenu;

    public GameObject interaction1;
    [Header("Diary Entries")]
    public GameObject diary;
    [Space(10)]
    public GameObject backButton;
    public GameObject nextButton;
    [Space(10)]
    public GameObject entry0;
    public GameObject entry1;
    public GameObject entry2;
    public GameObject entry3;
    public GameObject entry4;
    public GameObject entry5;
    public GameObject entry6;
    public GameObject entry7;

    [Space(10)]
    public GameObject page0_1;
    public GameObject page2_3;
    public GameObject page4_5;
    public GameObject page6_7;



    [Header("UI ELEMENTS")]
    public Slider musicVolumeSlider;

    [Header("UI TEXTS")]
    public GameObject loadingText;
    public GameObject validateLoadingText;

    [Header("OPTIONS")]
    private AudioSource mainMenuAudioSource;
    public Toggle cursorStateToggle;

    [Header("Pause Menu")]
    public bool isPaused;

    public bool inGame;

    public bool isFullScreen = true;

    public static MenusManager instance;

    [HideInInspector]
    public bool level2loaded = false;
    public bool level1loaded = false;

    private GameObject[] allInteractableColliders;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        menusActions = new GameInputs();
        mainMenuAudioSource = GetComponent<AudioSource>();
        transform.gameObject.SetActive(true);

        UnloadAllScenesExcept("MainMenu 20032021");
    }


    private void Start()
    {
        page0_1.SetActive(true);
        page2_3.SetActive(false);
        page4_5.SetActive(false);
        page6_7.SetActive(false);

        entry0.SetActive(true);
        entry1.SetActive(false);
        entry2.SetActive(false);
        entry3.SetActive(false);
        entry4.SetActive(false);
        entry5.SetActive(false);
        entry6.SetActive(false);
        entry7.SetActive(false);
    }


    void Update()
    {
        if (asyncOp != null && !validateLoadingText.activeSelf)
        {
            if (asyncOp.progress >= 0.9f)
            {
                Animator loadingScreenAnimator = loadingScreen.GetComponentInChildren<Animator>();
                loadingScreenAnimator.SetTrigger("LoadingStop");
                DisplayValidateLoadingText();
            }
        }

        if (SceneManager.sceneCount > 1)
        {
            if (SceneManager.GetSceneAt(1).isLoaded)
            {
                if (SceneManager.GetSceneAt(1) == SceneManager.GetSceneByBuildIndex(1) && level1loaded)
                {
                    PlayCinematic(true);
                    level1loaded = false;
                }
            }

            if (SceneManager.GetSceneAt(1) == SceneManager.GetSceneByBuildIndex(2) && level2loaded)
            {
                interaction1.SetActive(true);
                interaction1.SetActive(false);
                level2loaded = false;
            }

        }

        //enlever bouton "précédent" quand on ets sur la première page ou bouton "suivant" quand on est sur la dernière
        if (page0_1.activeSelf == true)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
        }

        if (page6_7.activeSelf == true)
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
    }

    private void OnEnable()
    {
        if (inGame == false)
        {
            menusActions.Enable();
            menusActions.MainMenuActions.ValidateSplashScreen.started += OnValidateSplashscreen;
        }

    }

    private void DeactivateMainMenuActions()
    {
        menusActions.Disable();
    }

    private void ReactivateMainMenuActions()
    {
        menusActions.Enable();
        menusActions.MainMenuActions.ValidateSplashScreen.started += OnValidateSplashscreen;
    }

    public void OnPressCancel(InputAction.CallbackContext context)
    {
        OnPressEscape();
    }

    public void OnValidateSplashscreen(InputAction.CallbackContext context)

    {
        if (inGame == false)
        {
            splashScreen.SetActive(false);
            mainMenuScreen.SetActive(true);
            menusActions.MainMenuActions.ValidateSplashScreen.started -= OnValidateSplashscreen;
        }
    }

    public void OnValidatePlay()
    {
        if (inGame == false)
        {
            mainMenuScreen.SetActive(false);
            menuBackground.SetActive(false);
            loadingScreen.SetActive(true);
            asyncOp = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            asyncOp.allowSceneActivation = false;
            inGame = true;
            menusActions.MainMenuActions.Pause.started += PauseGame;

        }
    }

    public void OnValidateOptions()
    {
        if (inGame == false)
        {
            // midOptionsScreen.SetActive(false);
            optionsScreen.SetActive(true);
            OnPressEscape = OnBackFromSettings;
        }
    }

    public void OnValidateMidOptions()
    {
        if (inGame == false)
        {
            menusActions.MainMenuActions.Cancel.started += OnPressCancel;
            mainMenuScreen.SetActive(false);
            midOptionsScreen.SetActive(true);
            OnPressEscape = OnBackFromMidOptions;
        }
    }

    public void OnValidateCredits()
    {
        if (inGame == false)
        {
            midOptionsScreen.SetActive(false);
            creditsScreen.SetActive(true);
            OnPressEscape = OnBackFromCredits;
        }
    }

    public void OnValidateExitYes()
    {
        Debug.Log("Exit !");
        Application.Quit();
    }

    public void OnBackFromSettings()
    {
        if (inGame == false)
        {
            optionsScreen.SetActive(false);
            // midOptionsScreen.SetActive(true);
            mainMenuScreen.SetActive(true);
            // OnPressEscape = OnBackFromMidOptions;
        }
    }

    public void OnBackFromCredits()
    {
        if (inGame == false)
        {
            creditsScreen.SetActive(false);
            mainMenuScreen.SetActive(true);
            OnPressEscape = OnBackFromMidOptions;
        }
    }

    public void OnBackFromMidOptions()
    {
        if (inGame == false)
        {
            midOptionsScreen.SetActive(false);
            mainMenuScreen.SetActive(true);
            menusActions.MainMenuActions.Cancel.started -= OnPressCancel;
        }
    }

    public void DisplayValidateLoadingText()
    {
        loadingText.SetActive(false);
        validateLoadingText.SetActive(true);
        menusActions.MainMenuActions.ValidateLoadScene.started += HideLoadingScreen;
    }

    public void PauseMenu()
    {
        if (inGame == true)
        {
            if (isPaused == true)
            {
                Time.timeScale = 1;
                ingamePauseMenu.SetActive(false);
                inGameOptions.SetActive(false);
                isPaused = false;
                return;
            }
            else
            {
                ingamePauseMenu.SetActive(true);
                inGameOptions.SetActive(false);
                Time.timeScale = 0;
                isPaused = true;
                return;
            }
        }
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (inGame == true)
        {
            if (isPaused == true)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                Time.timeScale = 1;
                ingamePauseMenu.SetActive(false);
                inGameOptions.SetActive(false);
                //GameManager.Instance.ActivateInGameActions();
                player.GetComponent<PlayerInput>().enabled = true;
                isPaused = false;

                allInteractableColliders = GameObject.FindGameObjectsWithTag("Interractable");
                for (int i = 0; i < allInteractableColliders.Length; i++)
                {
                    if (allInteractableColliders[i].GetComponent<BoxCollider2D>() != null)
                    {
                        allInteractableColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                    }
                }

                return;
            }
            else
            {
                player = GameObject.FindGameObjectWithTag("Player");
                ingamePauseMenu.SetActive(true);
                inGameOptions.SetActive(false);
                Time.timeScale = 0;
                //GameManager.Instance.DeactivateInGameActions();
                player.GetComponent<PlayerInput>().enabled = false;
                isPaused = true;

                allInteractableColliders = GameObject.FindGameObjectsWithTag("Interractable");
                for (int i = 0; i < allInteractableColliders.Length; i++)
                {
                    if (allInteractableColliders[i].GetComponent<BoxCollider2D>() != null)
                    {
                        allInteractableColliders[i].GetComponent<BoxCollider2D>().enabled = false;
                    }
                }

                return;
            }
        }
    }

    public void ReturnGame()
    {
        if (inGame == true)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Time.timeScale = 1;
            ingamePauseMenu.SetActive(false);
            player.GetComponent<PlayerInput>().enabled = true;
            isPaused = false;
            allInteractableColliders = GameObject.FindGameObjectsWithTag("Interractable");
            for (int i = 0; i < allInteractableColliders.Length; i++)
            {
                if (allInteractableColliders[i].GetComponent<BoxCollider2D>() != null)
                {
                    allInteractableColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                }
            }
            return;
        }
    }

    public void QuitToMenu()
    {
        inGame = false;
        Time.timeScale = 1;
        menuBackground.SetActive(true);
        loadingScreen.SetActive(false);
        splashScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        midOptionsScreen.SetActive(false);
        optionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        ingameMainUI.SetActive(false);
        ingamePauseMenu.SetActive(false);
        ingameGameOverUI.SetActive(false);
        endgameThanksScreen.SetActive(false);
        inGameOptions.SetActive(false);
        menusActions = new GameInputs();
        ReactivateMainMenuActions();
        Destroy(this.transform.parent.gameObject);
    }
    private void OnDestroy()
    {
        asyncOp = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        UnloadAllScenesExcept("MainMenuCamera 20032021");
    }

    public void OptionScreenInGame()
    {
        inGameOptions.SetActive(true);
        ingamePauseMenu.SetActive(false);
    }

    public void QuitOptionsScreenInGame()
    {
        inGameOptions.SetActive(false);
        ingamePauseMenu.SetActive(true);
    }

    public void HideLoadingScreen(InputAction.CallbackContext context)
    {
        asyncOp.allowSceneActivation = true;
        asyncOp = null;
        validateLoadingText.SetActive(false);
        loadingScreen.SetActive(false);
        MainMenuCamera.SetActive(false);
        menusActions.MainMenuActions.ValidateLoadScene.started -= HideLoadingScreen;
        DeactivateMainMenuActions();
        //GameManager.Instance.ActivateInGameActions();
        inGame = true;
        level1loaded = true;
        Invoke("ActivateInGameUI", 0.2f);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        ingameGameOverUI.SetActive(true);
        ingameMainUI.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        if (SceneManager.GetSceneAt(1) == SceneManager.GetSceneByBuildIndex(1))
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(1).name);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
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
    }

    #region Journal

    public void Diary()
    {
        diary.SetActive(true);
    }

    public void HideDiary()
    {
        diary.SetActive(false);
    }

    public void BackDiaryPage()
    {
        if (page2_3.activeSelf == true)
        {
            page2_3.SetActive(false);
            page0_1.SetActive(true);
        }
        if (page4_5.activeSelf == true)
        {
            page4_5.SetActive(false);
            page2_3.SetActive(true);
        }
        if (page6_7.activeSelf == true)
        {
            page6_7.SetActive(false);
            page4_5.SetActive(true);
        }
    }

    public void NextDiaryPage()
    {
        if (page4_5.activeSelf == true)
        {
            page4_5.SetActive(false);
            page6_7.SetActive(true);
        }
        if (page2_3.activeSelf == true)
        {
            page2_3.SetActive(false);
            page4_5.SetActive(true);
        }
        if (page0_1.activeSelf == true)
        {
            page0_1.SetActive(false);
            page2_3.SetActive(true);
        }
    }


    #endregion

    #region OPTIONS

    public void UpdateMenuSettings()
    {
        // musicVolumeSlider.value = SaveManager.Instance.myGameSettings.musicVolume;
        mainMenuAudioSource.volume = musicVolumeSlider.value;
    }

    //Called by Music slider
    public void UpdateAudioVolume(float sliderValue)
    {
        mainMenuAudioSource.volume = sliderValue;
        // SaveManager.Instance.myGameSettings.musicVolume = mainMenuAudioSource.volume;
        // SaveManager.Instance.SaveMenuSettings();
    }

    public void SetResolution(int dropIdx)
    {
        switch (dropIdx)
        {
            case 0:
                Screen.SetResolution(1920, 1080, isFullScreen);
                break;
            case 1:
                Screen.SetResolution(1600, 900, isFullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 800, isFullScreen);
                break;
        }
    }

    public void SetFullScreen(bool fullScreen)
    {
        if (fullScreen == false)
        {


            isFullScreen = false;
            Screen.fullScreen = false;
        }

        if (fullScreen == true)
        {


            isFullScreen = true;
            Screen.fullScreen = true;
        }
    }

    public void SetCursorState()
    {
        if (cursorStateToggle.isOn == true)
        {
            CursorManager.Instance.cursorState = true;
        }
        if (cursorStateToggle.isOn == false)
        {
            CursorManager.Instance.cursorState = false;
        }
    }

    #endregion


    public void UnloadAllScenesExcept(string sceneName)
    {
        int c = SceneManager.sceneCount;
        for (int i = 0; i < c; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != sceneName)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
    }

    public void PlayCinematic(bool active)
    {
        if (active)
        {
            CursorManager.Instance.keepCursor = true;
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerInput>().enabled = false;
            Cinematic.SetActive(true);
            Cinematic.GetComponent<Animator>().SetTrigger("PlayCinematic");
            active = !active;
        }
    }

    private void ActivateInGameUI()
    {
        ingameMainUI.SetActive(true);
    }

    public void OpenGuideMenu()
    {
        ingamePauseMenu.SetActive(false);
        GuideMenu.SetActive(true);
    }

    public void CloseGuideMenu()
    {
        ingamePauseMenu.SetActive(true);
        GuideMenu.SetActive(false);
    }

}

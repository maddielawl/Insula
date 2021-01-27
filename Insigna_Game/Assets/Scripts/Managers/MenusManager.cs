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

    [Header("UI ELEMENTS")]
    public Slider musicVolumeSlider;

    [Header("UI TEXTS")]
    public GameObject loadingText;
    public GameObject validateLoadingText;

    [Header("OPTIONS")]
    private AudioSource mainMenuAudioSource;

    public static MenusManager s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
        menusActions = new GameInputs();
        mainMenuAudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (asyncOp != null && !validateLoadingText.activeSelf)
        {
            if (asyncOp.progress >= 0.9f)
            {
                DisplayValidateLoadingText();
            }
        }
    }

    private void OnEnable()
    {
        menusActions.Enable();
        menusActions.MainMenuActions.ValidateSplashScreen.started += OnValidateSplashscreen;
        
    }

    private void DeactivateMainMenuActions ()
    {
        menusActions.Disable();
    }

    public void OnPressCancel (InputAction.CallbackContext context)
    {
        OnPressEscape();
    }

    public void OnValidateSplashscreen (InputAction.CallbackContext context)
    {
        splashScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        menusActions.MainMenuActions.ValidateSplashScreen.started -= OnValidateSplashscreen;
    }

    public void OnValidatePlay()
    {
        mainMenuScreen.SetActive(false);
        menuBackground.SetActive(false);
        gameLogoImage.SetActive(false);
        loadingScreen.SetActive(true);
        asyncOp = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        asyncOp.allowSceneActivation = false;
    }

    public void OnValidateOptions()
    {
        midOptionsScreen.SetActive(false);
        optionsScreen.SetActive(true);
        OnPressEscape = OnBackFromSettings;
    }

    public void OnValidateMidOptions ()
    {
        menusActions.MainMenuActions.Cancel.started += OnPressCancel;
        mainMenuScreen.SetActive(false);
        midOptionsScreen.SetActive(true);
        OnPressEscape = OnBackFromMidOptions;
    }

    public void OnValidateCredits()
    {
        midOptionsScreen.SetActive(false);
        creditsScreen.SetActive(true);
        OnPressEscape = OnBackFromCredits;
    }

    public void OnValidateExitYes ()
    {
        Debug.Log("Exit !");
        Application.Quit();
    }

    public void OnBackFromSettings ()
    {
        optionsScreen.SetActive(false);
        midOptionsScreen.SetActive(true);
        OnPressEscape = OnBackFromMidOptions;
    }

    public void OnBackFromCredits()
    {
        creditsScreen.SetActive(false);
        midOptionsScreen.SetActive(true);
        OnPressEscape = OnBackFromMidOptions;
    }

    public void OnBackFromMidOptions()
    {
        midOptionsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        menusActions.MainMenuActions.Cancel.started -= OnPressCancel;
    }

    public void DisplayValidateLoadingText()
    {
        loadingText.SetActive(false);
        validateLoadingText.SetActive(true);
        menusActions.MainMenuActions.ValidateLoadScene.started += HideLoadingScreen;
    }

    public void HideLoadingScreen (InputAction.CallbackContext context)
    {
        asyncOp.allowSceneActivation = true;
        loadingScreen.SetActive(false);
        menusActions.MainMenuActions.ValidateLoadScene.started -= HideLoadingScreen;
        DeactivateMainMenuActions();
        GameManager.Instance.ActivateInGameActions();
    }

    #region OPTIONS

    public void UpdateMenuSettings ()
    {
        // musicVolumeSlider.value = SaveManager.Instance.myGameSettings.musicVolume;
        mainMenuAudioSource.volume = musicVolumeSlider.value;
    }

    //Called by Music slider
    public void UpdateAudioVolume (float sliderValue)
    {
        mainMenuAudioSource.volume = sliderValue;
        // SaveManager.Instance.myGameSettings.musicVolume = mainMenuAudioSource.volume;
        // SaveManager.Instance.SaveMenuSettings();
    }

    public void SetResolution (int dropIdx)
    {
        switch (dropIdx)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 1:
                Screen.SetResolution(1600, 900, true);
                break;
            case 2:
                Screen.SetResolution(1280, 800, true);
                break;
        }
    }

    #endregion
}

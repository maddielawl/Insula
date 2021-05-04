using System;
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

    public GameObject interaction1;
    [Header("Diary Entries")]
    public GameObject diary;
    public GameObject selectscreen;
    [Space(10)]
    public GameObject entrytext0;
    public GameObject entrytext1;
    public GameObject entrytext2;
    public GameObject entrytext3;
    public GameObject entrytext4;
    public GameObject entrytext5;
    public GameObject entrytext6;
    public GameObject entrytext7;
    public GameObject entrytext8;
    public GameObject entrytext9;
    [Space(10)]
    public GameObject entries;
    public GameObject returntoselectbutton;
    public GameObject entry0;
    public GameObject entry1;
    public GameObject entry2;
    public GameObject entry3;
    public GameObject entry4;
    public GameObject entry5;
    public GameObject entry6;
    public GameObject entry7;
    public GameObject entry8;
    public GameObject entry9;



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
                Time.timeScale = 1;
                ingamePauseMenu.SetActive(false);
                inGameOptions.SetActive(false);
                //GameManager.Instance.ActivateInGameActions();
                isPaused = false;
                return;
            }
            else
            {
                ingamePauseMenu.SetActive(true);
                inGameOptions.SetActive(false);
                Time.timeScale = 0;
                //GameManager.Instance.DeactivateInGameActions();
                isPaused = true;
                return;
            }
        }
    }

    public void ReturnGame()
    {
        if (inGame == true)
        {
            Time.timeScale = 1;
            ingamePauseMenu.SetActive(false);
            isPaused = false;
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
        ingameMainUI.SetActive(true);
        MainMenuCamera.SetActive(false);
        menusActions.MainMenuActions.ValidateLoadScene.started -= HideLoadingScreen;
        DeactivateMainMenuActions();
        //GameManager.Instance.ActivateInGameActions();
        PopUp.SetActive(true);
        inGame = true;
        level1loaded = true;
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
        SceneManager.LoadScene(SceneManager.GetSceneAt(1).name);
        ingameMainUI.SetActive(true);
        ingameGameOverUI.SetActive(false);
        GameManager.Instance.isScared = false;
        GameManager.Instance.playerMadness = 0;
        GameManager.Instance.playerSanity = 0;
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

    public void ReturnToSelect()
    {
        entry0.SetActive(false);
        entry1.SetActive(false);
        entry2.SetActive(false);
        entry3.SetActive(false);
        entry4.SetActive(false);
        entry5.SetActive(false);
        entry6.SetActive(false);
        entry7.SetActive(false);
        entry8.SetActive(false);
        entry9.SetActive(false);
        entries.SetActive(false);
        selectscreen.SetActive(true);
    }

    public void GetToEntry0()
    {
        entries.SetActive(true);
        entry0.SetActive(true);
        selectscreen.SetActive(false);
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
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerInput>().enabled = false;
            Cinematic.SetActive(true);
            Cinematic.GetComponent<Animator>().SetTrigger("PlayCinematic");
            active = !active;
        }
    }
}

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
    FMOD.Studio.Bus masterBus;
    public string level1Music = "event:/Music/Level 1/Level 1";
    public FMOD.Studio.EventInstance music;
    public string neonAmb = "event:/SFX/Environment Sounds/Neon Ambience";
    public FMOD.Studio.EventInstance neonAmbEvent;

    [HideInInspector]
    public GameObject player;
    public GameObject cursorManger;

    public GameObject MainMenuCamera;


    private GameInputs menusActions;
    private AsyncOperation asyncOp;

    public delegate void OnPressBack();
    private OnPressBack OnPressEscape;

    private GameObject[] allBoxColliders;
    private BoxCollider2D[] allBoxCollier2DDisabled = new BoxCollider2D[100];
    private int allDisBoxColLength = 0;

    bool vincent = false;

    public GameObject[] allColliderInterractable;

    [HideInInspector] public bool inTuto;



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

    [SerializeField] private bool diaryOpened;

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


    public GameObject particule;

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
        /*SaveScript.Instance.LoadData();
        isFullScreen = SaveManager.Instance.FullscreenBool;
        Screen.SetResolution(SaveManager.Instance.XResolution, SaveManager.Instance.YResolution, isFullScreen);
        */
        if (mainMenuAudioSource != null)
        {
            mainMenuAudioSource.volume = SaveManager.Instance.VolumeFloat;
        }
        menusActions = new GameInputs();
        mainMenuAudioSource = GetComponent<AudioSource>();
        transform.gameObject.SetActive(true);

        UnloadAllScenesExcept("MainMenu 20032021");

        masterBus = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        music = FMODUnity.RuntimeManager.CreateInstance(level1Music);
        neonAmbEvent = FMODUnity.RuntimeManager.CreateInstance(neonAmb);
        neonAmbEvent.start();
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
            // menusActions.MainMenuActions.Pause.started += PauseGame;
            music.start();
        }
    }

    public void OnValidateOptions()
    {
        if (inGame == false)
        {
            // midOptionsScreen.SetActive(false);
            optionsScreen.SetActive(true);
            particule.SetActive(false);
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
            particule.SetActive(true);
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
        // Invoke("AddPauseGame", 15f);
        HideLoadingScreen();
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
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Pause", 0);
                return;
            }
            else
            {
                ingamePauseMenu.SetActive(true);
                inGameOptions.SetActive(false);
                Time.timeScale = 0;
                isPaused = true;
                Debug.Log("Pause");
                return;
            }
        }
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (vincent == true)
            {

                if (inGame == true)
                {
                    if (isPaused == true)
                    {
                        Debug.Log("plus Pause");
                        player = GameObject.FindGameObjectWithTag("Player");
                        Time.timeScale = 1;
                        ingamePauseMenu.SetActive(false);
                        inGameOptions.SetActive(false);
                        GuideMenu.SetActive(false);
                        //diary.SetActive(false);
                        player.GetComponent<PlayerInput>().enabled = true;
                        isPaused = false;
                        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Pause", 0);

                        if (diaryOpened)
                        {
                            Time.timeScale = 0;
                        }
                        else
                        {
                            for (int i = 0; i < allBoxColliders.Length; i++)
                            {
                                if (allBoxColliders[i] != null && allBoxColliders[i].GetComponent<BoxCollider2D>() != null)
                                {
                                    allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                                }
                            }

                            for (int i = 0; i < allBoxCollier2DDisabled.Length; i++)
                            {
                                if (allBoxCollier2DDisabled[i] != null)
                                {
                                    allBoxCollier2DDisabled[i].GetComponent<BoxCollider2D>().enabled = false;
                                }
                            }

                            allDisBoxColLength = 0;
                        }
                        return;
                    }
                    else
                    {
                        if (inTuto == false)
                        {
                            player = GameObject.FindGameObjectWithTag("Player");
                            ingamePauseMenu.SetActive(true);
                            inGameOptions.SetActive(false);
                            Time.timeScale = 0;
                            //GameManager.Instance.DeactivateInGameActions();
                            player.GetComponent<PlayerInput>().enabled = false;
                            isPaused = true;
                            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Pause", 1);

                            if (diaryOpened)
                            {
                                Time.timeScale = 0;
                            }
                            else
                            {
                                allBoxColliders = GameObject.FindGameObjectsWithTag("Interractable");
                                for (int i = 0; i < allBoxColliders.Length; i++)
                                {
                                    if (allBoxColliders[i] != null && allBoxColliders[i].GetComponent<BoxCollider2D>() != null)
                                    {
                                        if (allBoxColliders[i].GetComponent<BoxCollider2D>().enabled == false)
                                        {
                                            allBoxCollier2DDisabled[allDisBoxColLength] = allBoxColliders[i].GetComponent<BoxCollider2D>();
                                            allDisBoxColLength += 1;
                                        }

                                        if (allBoxColliders[i].GetComponent<BoxCollider2D>().enabled)
                                        {
                                            allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = false;
                                        }

                                    }
                                }
                            }
                            return;
                        }
                    }
                }
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
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Pause", 0);

            if (diaryOpened)
            {
                Time.timeScale = 0;
            }
            else
            {
                for (int i = 0; i < allBoxColliders.Length; i++)
                {
                    if (allBoxColliders[i] != null && allBoxColliders[i].GetComponent<BoxCollider2D>() != null)
                    {
                        if (allBoxColliders[i].GetComponent<BoxCollider2D>() != null)
                        {
                            allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                        }
                    }
                }

                for (int i = 0; i < allBoxCollier2DDisabled.Length; i++)
                {
                    if (allBoxCollier2DDisabled[i] != null)
                    {
                        allBoxCollier2DDisabled[i].GetComponent<BoxCollider2D>().enabled = false;
                    }
                }

                allDisBoxColLength = 0;
            }
            return;
        }
    }

    public void QuitToMenu()
    {
        masterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
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

    public void HideLoadingScreen()
    {
        asyncOp.allowSceneActivation = true;
        asyncOp = null;
        validateLoadingText.SetActive(false);
        loadingScreen.SetActive(false);
        MainMenuCamera.SetActive(false);
        // menusActions.MainMenuActions.ValidateLoadScene.started -= HideLoadingScreen;
        // Invoke("AddPauseGame", 15f);
        DeactivateMainMenuActions();
        //GameManager.Instance.ActivateInGameActions();
        inGame = true;
        level1loaded = true;
        //Invoke("ActivateInGameUI", 0.4f);
    }
    public void GameOver()
    {
        masterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Time.timeScale = 0;
        ingameGameOverUI.SetActive(true);
        ingameMainUI.SetActive(false);

        allBoxColliders = GameObject.FindGameObjectsWithTag("Interractable");
        for (int i = 0; i < allBoxColliders.Length; i++)
        {
            if (allBoxColliders[i] != null && allBoxColliders[i].GetComponent<BoxCollider2D>() != null)
            {
                if (allBoxColliders[i].GetComponent<BoxCollider2D>().enabled == false)
                {
                    allBoxCollier2DDisabled[allDisBoxColLength] = allBoxColliders[i].GetComponent<BoxCollider2D>();
                    allDisBoxColLength += 1;
                }

                if (allBoxColliders[i].GetComponent<BoxCollider2D>().enabled)
                {
                    allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = false;
                }

            }
        }
    }

    public void Restart()
    {
        music.start();
        Time.timeScale = 1;

        #region LevelLoadOnDeath

        if (SceneManager.sceneCount > 1)
        {
            if (SceneManager.GetSceneByName(SceneManager.GetSceneByBuildIndex(1).name) == SceneManager.GetSceneByBuildIndex(1))
            {
                SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(1).name);
            }
        }

        if (SceneManager.sceneCount < 2)
        {
            if (SceneManager.GetSceneAt(0) == SceneManager.GetSceneByBuildIndex(2))
            {
                SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(2).name);
            }

            if (SceneManager.GetSceneAt(0) == SceneManager.GetSceneByBuildIndex(3))
            {
                SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(3).name);
            }

            if (SceneManager.GetSceneAt(0) == SceneManager.GetSceneByBuildIndex(4))
            {
                SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(4).name);
            }
        }

        #endregion

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

        UIManager.Instance.HelmetIsOff();

        if (SceneManager.sceneCount > 1)
        {
            if (SceneManager.GetSceneAt(1).isLoaded)
            {
                if (SceneManager.GetSceneAt(1) == SceneManager.GetSceneByBuildIndex(1))
                {
                    entry1.SetActive(false);
                }
            }
        }

        if (SceneManager.sceneCount < 2)
        {
            if (SceneManager.GetSceneAt(0) == SceneManager.GetSceneByBuildIndex(2))
            {
                entry2.SetActive(false);
                entry3.SetActive(false);
            }

            if (SceneManager.GetSceneAt(0) == SceneManager.GetSceneByBuildIndex(2))
            {
                entry4.SetActive(false);
                entry5.SetActive(false);
                entry6.SetActive(false);
            }
        }
    }

    #region Journal

    public void Diary()
    {
        diaryOpened = true;
        diary.SetActive(true);
        player.GetComponent<PlayerInput>().enabled = false;
        Time.timeScale = 0;

        allBoxColliders = GameObject.FindGameObjectsWithTag("Interractable");
        for (int i = 0; i < allBoxColliders.Length; i++)
        {
            if (allBoxColliders[i] != null && allBoxColliders[i].GetComponent<BoxCollider2D>() != null)
            {
                if (allBoxColliders[i].GetComponent<BoxCollider2D>().enabled == false)
                {
                    allBoxCollier2DDisabled[allDisBoxColLength] = allBoxColliders[i].GetComponent<BoxCollider2D>();
                    allDisBoxColLength += 1;
                }

                if (allBoxColliders[i].GetComponent<BoxCollider2D>().enabled)
                {
                    allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = false;
                }

            }
        }
    }

    public void HideDiary()
    {
        diaryOpened = false;
        diary.SetActive(false);
        player.GetComponent<PlayerInput>().enabled = true;
        Time.timeScale = 1;

        for (int i = 0; i < allBoxColliders.Length; i++)
        {
            if (allBoxColliders[i] != null && allBoxColliders[i].GetComponent<BoxCollider2D>() != null)
            {
                allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }

        for (int i = 0; i < allBoxCollier2DDisabled.Length; i++)
        {
            if (allBoxCollier2DDisabled[i] != null)
            {
                allBoxCollier2DDisabled[i].GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        allDisBoxColLength = 0;
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
        /*SaveManager.Instance.VolumeFloat = musicVolumeSlider.value;
        SaveScript.Instance.SaveData();*/
    }

    //Called by Music slider
    public void UpdateAudioVolume(float sliderValue)
    {
        mainMenuAudioSource.volume = sliderValue;
        /*SaveManager.Instance.VolumeFloat = musicVolumeSlider.value;
        SaveScript.Instance.SaveData();*/
        // SaveManager.Instance.myGameSettings.musicVolume = mainMenuAudioSource.volume;
        // SaveManager.Instance.SaveMenuSettings();
    }

    public void SetResolution(int dropIdx)
    {
        switch (dropIdx)
        {
            case 0:
                Screen.SetResolution(1920, 1080, isFullScreen);
                /*SaveManager.Instance.XResolution = 1920;
                SaveManager.Instance.YResolution = 1080;
                SaveScript.Instance.SaveData();*/
                break;
            case 1:
                Screen.SetResolution(1600, 900, isFullScreen);
                /*SaveManager.Instance.XResolution = 1600;
                SaveManager.Instance.YResolution = 900;
                SaveScript.Instance.SaveData();*/
                break;
            case 2:
                Screen.SetResolution(1280, 800, isFullScreen);
                /*SaveManager.Instance.XResolution = 1280;
                SaveManager.Instance.YResolution = 800;
                SaveScript.Instance.SaveData();*/
                break;
        }
    }

    public void SetFullScreen(bool fullScreen)
    {
        if (fullScreen == false)
        {


            isFullScreen = false;
            Screen.fullScreen = false;
            /*SaveManager.Instance.FullscreenBool = false;
            SaveScript.Instance.SaveData();*/
        }

        if (fullScreen == true)
        {


            isFullScreen = true;
            Screen.fullScreen = true;
            /*SaveManager.Instance.FullscreenBool = true;
            SaveScript.Instance.SaveData();*/
        }
    }

    public void SetCursorState()
    {
        if (cursorStateToggle.isOn == true)
        {
            CursorManager.Instance.cursorState = true;
            /*SaveManager.Instance.CursorState = true;
            SaveScript.Instance.SaveData();*/
        }
        if (cursorStateToggle.isOn == false)
        {
            CursorManager.Instance.cursorState = false;
            /*SaveManager.Instance.CursorState = false;
            SaveScript.Instance.SaveData();*/
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
            ingameMainUI.SetActive(true);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Level", 0);
            CursorManager.Instance.keepCursor = true;
            CursorManager.Instance.GetComponent<Image>().enabled = false;
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerInput>().enabled = false;
            Cinematic.SetActive(true);
            Cinematic.GetComponent<Animator>().SetTrigger("PlayCinematic");
            allColliderInterractable = GameObject.FindGameObjectsWithTag("Interractable");
            for (int i = 0; i < allColliderInterractable.Length; i++)
            {
                if (allColliderInterractable[i].name == "BarreauBrake" || allColliderInterractable[i].name == "Lever" || allColliderInterractable[i].name == "Door" || allColliderInterractable[i].name == "ButtonInteract" || allColliderInterractable[i].name == "ButtonInteract (1)" || allColliderInterractable[i].name == "ExitInteract")
                {
                    allColliderInterractable[i].GetComponent<BoxCollider2D>().enabled = false;
                }
            }
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

    public void AddPauseGame()
    {
        menusActions.MainMenuActions.Pause.started += PauseGame;
        vincent = true;
    }
}

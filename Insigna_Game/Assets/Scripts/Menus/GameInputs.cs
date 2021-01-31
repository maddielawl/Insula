// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Menus/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""MainMenuActions"",
            ""id"": ""4c7eca97-0903-4c56-814b-36431c8edb1c"",
            ""actions"": [
                {
                    ""name"": ""NavigateMenu"",
                    ""type"": ""Button"",
                    ""id"": ""6599506a-c68c-4628-986b-a97c3a4b31bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ValidateSplashScreen"",
                    ""type"": ""Button"",
                    ""id"": ""3e14e160-7ab8-4029-add0-18c5c59643d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""095a8df3-baf8-4ffd-aafa-2fb92afe7dae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""9fe2345f-86f1-4965-be7f-47d85f5d4d99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ValidateLoadScene"",
                    ""type"": ""Button"",
                    ""id"": ""24f76ea9-ac27-4687-8a16-ad3d50c09704"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""845cf4d7-6d80-486e-a77f-5bc5383c7014"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""Value"",
                    ""id"": ""1c61c0fa-a704-409a-b4c9-f9e610e9311f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""7ccd5659-0adb-47ab-9a50-706930cda781"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MenuDirections"",
                    ""id"": ""eeebad41-aa2e-4212-afaf-5da1e7f0b7f5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateMenu"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a7a172ad-a602-4b30-9aa5-541ed9caeab2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""NavigateMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c81e1cc7-df91-4abb-97b2-48db1997a3b7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""NavigateMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eeb8c68b-fea7-44a3-bc7b-d64288a5080f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""NavigateMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f58ce93d-ebe1-4246-90bd-94d961eb4799"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""NavigateMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""37e1003c-7b34-4706-85be-4a60c5e39568"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ValidateSplashScreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""297368e7-6a2a-4fda-9379-9995ef7b39c0"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ValidateSplashScreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcfcbb10-0b74-4e0e-ba40-2234d86cb37a"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3e132fa-ac7b-402a-94a2-f88773a51aa2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1963dff-f906-402b-8551-437f2b370116"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c831147b-d5cf-49cf-bba3-70488de00f72"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20816574-c5f3-4dde-b669-1b6e22239c7e"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ValidateLoadScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a5f6e26-d6a9-4dbc-9ef7-ecd0496c4234"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ValidateLoadScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b53de4f1-896e-4dd1-ba62-dd56b5a30981"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f667b2fa-36e7-4383-8da4-aef37aff5d29"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""852ff3b6-9881-4083-9395-079d3be45647"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MainMenuActions
        m_MainMenuActions = asset.FindActionMap("MainMenuActions", throwIfNotFound: true);
        m_MainMenuActions_NavigateMenu = m_MainMenuActions.FindAction("NavigateMenu", throwIfNotFound: true);
        m_MainMenuActions_ValidateSplashScreen = m_MainMenuActions.FindAction("ValidateSplashScreen", throwIfNotFound: true);
        m_MainMenuActions_Submit = m_MainMenuActions.FindAction("Submit", throwIfNotFound: true);
        m_MainMenuActions_Cancel = m_MainMenuActions.FindAction("Cancel", throwIfNotFound: true);
        m_MainMenuActions_ValidateLoadScene = m_MainMenuActions.FindAction("ValidateLoadScene", throwIfNotFound: true);
        m_MainMenuActions_MouseClick = m_MainMenuActions.FindAction("MouseClick", throwIfNotFound: true);
        m_MainMenuActions_Point = m_MainMenuActions.FindAction("Point", throwIfNotFound: true);
        m_MainMenuActions_Pause = m_MainMenuActions.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // MainMenuActions
    private readonly InputActionMap m_MainMenuActions;
    private IMainMenuActionsActions m_MainMenuActionsActionsCallbackInterface;
    private readonly InputAction m_MainMenuActions_NavigateMenu;
    private readonly InputAction m_MainMenuActions_ValidateSplashScreen;
    private readonly InputAction m_MainMenuActions_Submit;
    private readonly InputAction m_MainMenuActions_Cancel;
    private readonly InputAction m_MainMenuActions_ValidateLoadScene;
    private readonly InputAction m_MainMenuActions_MouseClick;
    private readonly InputAction m_MainMenuActions_Point;
    private readonly InputAction m_MainMenuActions_Pause;
    public struct MainMenuActionsActions
    {
        private @GameInputs m_Wrapper;
        public MainMenuActionsActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavigateMenu => m_Wrapper.m_MainMenuActions_NavigateMenu;
        public InputAction @ValidateSplashScreen => m_Wrapper.m_MainMenuActions_ValidateSplashScreen;
        public InputAction @Submit => m_Wrapper.m_MainMenuActions_Submit;
        public InputAction @Cancel => m_Wrapper.m_MainMenuActions_Cancel;
        public InputAction @ValidateLoadScene => m_Wrapper.m_MainMenuActions_ValidateLoadScene;
        public InputAction @MouseClick => m_Wrapper.m_MainMenuActions_MouseClick;
        public InputAction @Point => m_Wrapper.m_MainMenuActions_Point;
        public InputAction @Pause => m_Wrapper.m_MainMenuActions_Pause;
        public InputActionMap Get() { return m_Wrapper.m_MainMenuActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActionsActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActionsActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsActionsCallbackInterface != null)
            {
                @NavigateMenu.started -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnNavigateMenu;
                @NavigateMenu.performed -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnNavigateMenu;
                @NavigateMenu.canceled -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnNavigateMenu;
                @ValidateSplashScreen.started -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnValidateSplashScreen;
                @ValidateSplashScreen.performed -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnValidateSplashScreen;
                @ValidateSplashScreen.canceled -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnValidateSplashScreen;
                @Submit.started -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnCancel;
                @ValidateLoadScene.started -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnValidateLoadScene;
                @ValidateLoadScene.performed -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnValidateLoadScene;
                @ValidateLoadScene.canceled -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnValidateLoadScene;
                @MouseClick.started -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnMouseClick;
                @Point.started -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnPoint;
                @Pause.started -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MainMenuActionsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_MainMenuActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NavigateMenu.started += instance.OnNavigateMenu;
                @NavigateMenu.performed += instance.OnNavigateMenu;
                @NavigateMenu.canceled += instance.OnNavigateMenu;
                @ValidateSplashScreen.started += instance.OnValidateSplashScreen;
                @ValidateSplashScreen.performed += instance.OnValidateSplashScreen;
                @ValidateSplashScreen.canceled += instance.OnValidateSplashScreen;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @ValidateLoadScene.started += instance.OnValidateLoadScene;
                @ValidateLoadScene.performed += instance.OnValidateLoadScene;
                @ValidateLoadScene.canceled += instance.OnValidateLoadScene;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public MainMenuActionsActions @MainMenuActions => new MainMenuActionsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IMainMenuActionsActions
    {
        void OnNavigateMenu(InputAction.CallbackContext context);
        void OnValidateSplashScreen(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnValidateLoadScene(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}

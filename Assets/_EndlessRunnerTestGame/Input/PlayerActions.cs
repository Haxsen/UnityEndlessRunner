// GENERATED AUTOMATICALLY FROM 'Assets/_EndlessRunnerTestGame/Input/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""9bc7691d-1fad-4d35-9ace-89b7e11c656d"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a0037cba-db96-44b5-bd27-c291a0b59df6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RollDown"",
                    ""type"": ""Button"",
                    ""id"": ""8abd00d0-b534-443c-bc07-40d08deb76ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SideMovement"",
                    ""type"": ""Button"",
                    ""id"": ""4e7346ac-bafe-4a87-95e2-b01db89aab4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""Button"",
                    ""id"": ""a51976a1-af7e-45b5-b82e-1ca59dc3e960"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dfb57c92-0b6c-4450-9fb7-8b3b488346bf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""aafb6dd3-bed1-45e9-9ca4-57fd67d257ab"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SideMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""17f03510-b0f3-4781-821e-6498cd6b837b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SideMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""45e9284c-3daf-470a-bdc9-25aa54f402a5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SideMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2739030f-7635-4d65-a9de-2c0cd681d6d9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RollDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7df09cdf-11c4-491a-95d6-ede8f6331c46"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd5d2f36-6262-448d-8f72-b8b0edc12dd8"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchInputScheme"",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7224371-121c-4d9d-a9ec-d5ae2db0cdad"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchInputScheme"",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""TouchInputScheme"",
            ""bindingGroup"": ""TouchInputScheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControls_RollDown = m_PlayerControls.FindAction("RollDown", throwIfNotFound: true);
        m_PlayerControls_SideMovement = m_PlayerControls.FindAction("SideMovement", throwIfNotFound: true);
        m_PlayerControls_PrimaryContact = m_PlayerControls.FindAction("PrimaryContact", throwIfNotFound: true);
        m_PlayerControls_PrimaryPosition = m_PlayerControls.FindAction("PrimaryPosition", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Jump;
    private readonly InputAction m_PlayerControls_RollDown;
    private readonly InputAction m_PlayerControls_SideMovement;
    private readonly InputAction m_PlayerControls_PrimaryContact;
    private readonly InputAction m_PlayerControls_PrimaryPosition;
    public struct PlayerControlsActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerControlsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
        public InputAction @RollDown => m_Wrapper.m_PlayerControls_RollDown;
        public InputAction @SideMovement => m_Wrapper.m_PlayerControls_SideMovement;
        public InputAction @PrimaryContact => m_Wrapper.m_PlayerControls_PrimaryContact;
        public InputAction @PrimaryPosition => m_Wrapper.m_PlayerControls_PrimaryPosition;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @RollDown.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRollDown;
                @RollDown.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRollDown;
                @RollDown.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRollDown;
                @SideMovement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSideMovement;
                @SideMovement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSideMovement;
                @SideMovement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSideMovement;
                @PrimaryContact.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPrimaryContact;
                @PrimaryPosition.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPrimaryPosition;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RollDown.started += instance.OnRollDown;
                @RollDown.performed += instance.OnRollDown;
                @RollDown.canceled += instance.OnRollDown;
                @SideMovement.started += instance.OnSideMovement;
                @SideMovement.performed += instance.OnSideMovement;
                @SideMovement.canceled += instance.OnSideMovement;
                @PrimaryContact.started += instance.OnPrimaryContact;
                @PrimaryContact.performed += instance.OnPrimaryContact;
                @PrimaryContact.canceled += instance.OnPrimaryContact;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    private int m_TouchInputSchemeSchemeIndex = -1;
    public InputControlScheme TouchInputSchemeScheme
    {
        get
        {
            if (m_TouchInputSchemeSchemeIndex == -1) m_TouchInputSchemeSchemeIndex = asset.FindControlSchemeIndex("TouchInputScheme");
            return asset.controlSchemes[m_TouchInputSchemeSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerControlsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnRollDown(InputAction.CallbackContext context);
        void OnSideMovement(InputAction.CallbackContext context);
        void OnPrimaryContact(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
    }
}

// GENERATED AUTOMATICALLY FROM 'Assets/_EndlessRunnerTestGame/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""DefaultActionMap"",
            ""id"": ""9bc7691d-1fad-4d35-9ace-89b7e11c656d"",
            ""actions"": [
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""Button"",
                    ""id"": ""33a4c582-7ce0-489a-a73b-89be35f1af1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""38741559-e471-41e3-9508-589aa4592348"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SideMovement"",
                    ""type"": ""Button"",
                    ""id"": ""4e365484-4073-4a37-8669-c4685b88761f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""73cd9ee3-fd19-4cae-b92d-834b01b51a5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RollDown"",
                    ""type"": ""Button"",
                    ""id"": ""e7aec887-d99e-4f05-b841-ec3017f55fc6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2011b7d3-7db1-464f-a2cd-7ef88fde1767"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchInputScheme"",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3551121-c0b5-484c-841d-c03ce03770c0"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchInputScheme"",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""83867d7d-26a1-46ff-b2aa-3b9c09546058"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SideMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""76d388f5-c4dc-4ec5-a9b0-77d4c6b8d670"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchInputScheme"",
                    ""action"": ""SideMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e7f057d5-e5cc-4366-953a-8ca003825ea5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchInputScheme"",
                    ""action"": ""SideMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cebf51b0-baa7-408e-b32e-608dc7d75183"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchInputScheme"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d67133a-8f31-436f-9d9a-6791e6e1de3d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchInputScheme"",
                    ""action"": ""RollDown"",
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
        }
    ]
}");
        // DefaultActionMap
        m_DefaultActionMap = asset.FindActionMap("DefaultActionMap", throwIfNotFound: true);
        m_DefaultActionMap_PrimaryContact = m_DefaultActionMap.FindAction("PrimaryContact", throwIfNotFound: true);
        m_DefaultActionMap_PrimaryPosition = m_DefaultActionMap.FindAction("PrimaryPosition", throwIfNotFound: true);
        m_DefaultActionMap_SideMovement = m_DefaultActionMap.FindAction("SideMovement", throwIfNotFound: true);
        m_DefaultActionMap_Jump = m_DefaultActionMap.FindAction("Jump", throwIfNotFound: true);
        m_DefaultActionMap_RollDown = m_DefaultActionMap.FindAction("RollDown", throwIfNotFound: true);
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

    // DefaultActionMap
    private readonly InputActionMap m_DefaultActionMap;
    private IDefaultActionMapActions m_DefaultActionMapActionsCallbackInterface;
    private readonly InputAction m_DefaultActionMap_PrimaryContact;
    private readonly InputAction m_DefaultActionMap_PrimaryPosition;
    private readonly InputAction m_DefaultActionMap_SideMovement;
    private readonly InputAction m_DefaultActionMap_Jump;
    private readonly InputAction m_DefaultActionMap_RollDown;
    public struct DefaultActionMapActions
    {
        private @PlayerControls m_Wrapper;
        public DefaultActionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryContact => m_Wrapper.m_DefaultActionMap_PrimaryContact;
        public InputAction @PrimaryPosition => m_Wrapper.m_DefaultActionMap_PrimaryPosition;
        public InputAction @SideMovement => m_Wrapper.m_DefaultActionMap_SideMovement;
        public InputAction @Jump => m_Wrapper.m_DefaultActionMap_Jump;
        public InputAction @RollDown => m_Wrapper.m_DefaultActionMap_RollDown;
        public InputActionMap Get() { return m_Wrapper.m_DefaultActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActionMapActions instance)
        {
            if (m_Wrapper.m_DefaultActionMapActionsCallbackInterface != null)
            {
                @PrimaryContact.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnPrimaryContact;
                @PrimaryPosition.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnPrimaryPosition;
                @SideMovement.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSideMovement;
                @SideMovement.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSideMovement;
                @SideMovement.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSideMovement;
                @Jump.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnJump;
                @RollDown.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRollDown;
                @RollDown.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRollDown;
                @RollDown.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRollDown;
            }
            m_Wrapper.m_DefaultActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryContact.started += instance.OnPrimaryContact;
                @PrimaryContact.performed += instance.OnPrimaryContact;
                @PrimaryContact.canceled += instance.OnPrimaryContact;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
                @SideMovement.started += instance.OnSideMovement;
                @SideMovement.performed += instance.OnSideMovement;
                @SideMovement.canceled += instance.OnSideMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RollDown.started += instance.OnRollDown;
                @RollDown.performed += instance.OnRollDown;
                @RollDown.canceled += instance.OnRollDown;
            }
        }
    }
    public DefaultActionMapActions @DefaultActionMap => new DefaultActionMapActions(this);
    private int m_TouchInputSchemeSchemeIndex = -1;
    public InputControlScheme TouchInputSchemeScheme
    {
        get
        {
            if (m_TouchInputSchemeSchemeIndex == -1) m_TouchInputSchemeSchemeIndex = asset.FindControlSchemeIndex("TouchInputScheme");
            return asset.controlSchemes[m_TouchInputSchemeSchemeIndex];
        }
    }
    public interface IDefaultActionMapActions
    {
        void OnPrimaryContact(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
        void OnSideMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRollDown(InputAction.CallbackContext context);
    }
}

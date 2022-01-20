//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/JHModule/InputSystem/Input.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Input : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Keyborads"",
            ""id"": ""a9f1591e-8ade-47e4-856e-66c467ff487f"",
            ""actions"": [
                {
                    ""name"": ""Axis"",
                    ""type"": ""Button"",
                    ""id"": ""73a62d44-6fdb-4399-81f6-f41dd0afbb0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""76eae094-ae25-4183-8f5b-8762d1a16015"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AxisLog"",
                    ""id"": ""c08362cd-9b76-4729-967c-acdfae7bf689"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ad261003-eef4-466e-8146-7c3ef49582c1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Axis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""35a42aa3-9a08-4d51-8a7c-d2ca6574e636"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Axis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""93523015-3399-4992-b595-93286b66aee0"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e7bacdcb-320b-496a-9225-7e59b911eb17"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""49550b6f-81f6-4b3c-babe-e059febce880"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dda94034-4b6f-478d-a587-f3118a728ff3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3d2e71ea-ddf2-421b-8f10-8c2bdb678ff6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                }
            ]
        }
    ]
}");
        // Keyborads
        m_Keyborads = asset.FindActionMap("Keyborads", throwIfNotFound: true);
        m_Keyborads_Axis = m_Keyborads.FindAction("Axis", throwIfNotFound: true);
        m_Keyborads_Move = m_Keyborads.FindAction("Move", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Keyborads
    private readonly InputActionMap m_Keyborads;
    private IKeyboradsActions m_KeyboradsActionsCallbackInterface;
    private readonly InputAction m_Keyborads_Axis;
    private readonly InputAction m_Keyborads_Move;
    public struct KeyboradsActions
    {
        private @Input m_Wrapper;
        public KeyboradsActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Axis => m_Wrapper.m_Keyborads_Axis;
        public InputAction @Move => m_Wrapper.m_Keyborads_Move;
        public InputActionMap Get() { return m_Wrapper.m_Keyborads; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboradsActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboradsActions instance)
        {
            if (m_Wrapper.m_KeyboradsActionsCallbackInterface != null)
            {
                @Axis.started -= m_Wrapper.m_KeyboradsActionsCallbackInterface.OnAxis;
                @Axis.performed -= m_Wrapper.m_KeyboradsActionsCallbackInterface.OnAxis;
                @Axis.canceled -= m_Wrapper.m_KeyboradsActionsCallbackInterface.OnAxis;
                @Move.started -= m_Wrapper.m_KeyboradsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_KeyboradsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_KeyboradsActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_KeyboradsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Axis.started += instance.OnAxis;
                @Axis.performed += instance.OnAxis;
                @Axis.canceled += instance.OnAxis;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public KeyboradsActions @Keyborads => new KeyboradsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IKeyboradsActions
    {
        void OnAxis(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}

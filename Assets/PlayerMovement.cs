//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerMovement.inputactions
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

public partial class @PlayerMovement: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMovement()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMovement"",
    ""maps"": [
        {
            ""name"": ""Movement 1"",
            ""id"": ""a8c6cd14-a6db-4076-a44b-db24b5f8c69f"",
            ""actions"": [
                {
                    ""name"": ""Left/Right"",
                    ""type"": ""Value"",
                    ""id"": ""b00d9f2e-616d-42fa-bbea-b05fd0bb5fb9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump(REAL)"",
                    ""type"": ""Button"",
                    ""id"": ""8e511db7-d87e-4895-a4fa-288e19eb5fe6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d1df31a1-707f-4176-8280-87788217ff6d"",
                    ""path"": ""1DAxis(whichSideWins=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left/Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""320a1dae-1d8c-4af0-874f-ac2658e916b2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left/Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4990a3aa-0e92-4c4b-a239-3fc0b9849f41"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left/Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f00fe896-ac8a-4667-8e8d-cd2c5226b0b0"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump(REAL)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Movement2"",
            ""id"": ""022179a6-85a5-4ce5-9d46-ca6dc74d6cd1"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""d9dbe987-279d-4154-b070-bb6ac624fbaa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5da64362-0ccb-4b0a-b8d8-a8638671e204"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement 1
        m_Movement1 = asset.FindActionMap("Movement 1", throwIfNotFound: true);
        m_Movement1_LeftRight = m_Movement1.FindAction("Left/Right", throwIfNotFound: true);
        m_Movement1_JumpREAL = m_Movement1.FindAction("Jump(REAL)", throwIfNotFound: true);
        // Movement2
        m_Movement2 = asset.FindActionMap("Movement2", throwIfNotFound: true);
        m_Movement2_Newaction = m_Movement2.FindAction("New action", throwIfNotFound: true);
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

    // Movement 1
    private readonly InputActionMap m_Movement1;
    private List<IMovement1Actions> m_Movement1ActionsCallbackInterfaces = new List<IMovement1Actions>();
    private readonly InputAction m_Movement1_LeftRight;
    private readonly InputAction m_Movement1_JumpREAL;
    public struct Movement1Actions
    {
        private @PlayerMovement m_Wrapper;
        public Movement1Actions(@PlayerMovement wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftRight => m_Wrapper.m_Movement1_LeftRight;
        public InputAction @JumpREAL => m_Wrapper.m_Movement1_JumpREAL;
        public InputActionMap Get() { return m_Wrapper.m_Movement1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Movement1Actions set) { return set.Get(); }
        public void AddCallbacks(IMovement1Actions instance)
        {
            if (instance == null || m_Wrapper.m_Movement1ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Movement1ActionsCallbackInterfaces.Add(instance);
            @LeftRight.started += instance.OnLeftRight;
            @LeftRight.performed += instance.OnLeftRight;
            @LeftRight.canceled += instance.OnLeftRight;
            @JumpREAL.started += instance.OnJumpREAL;
            @JumpREAL.performed += instance.OnJumpREAL;
            @JumpREAL.canceled += instance.OnJumpREAL;
        }

        private void UnregisterCallbacks(IMovement1Actions instance)
        {
            @LeftRight.started -= instance.OnLeftRight;
            @LeftRight.performed -= instance.OnLeftRight;
            @LeftRight.canceled -= instance.OnLeftRight;
            @JumpREAL.started -= instance.OnJumpREAL;
            @JumpREAL.performed -= instance.OnJumpREAL;
            @JumpREAL.canceled -= instance.OnJumpREAL;
        }

        public void RemoveCallbacks(IMovement1Actions instance)
        {
            if (m_Wrapper.m_Movement1ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovement1Actions instance)
        {
            foreach (var item in m_Wrapper.m_Movement1ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Movement1ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Movement1Actions @Movement1 => new Movement1Actions(this);

    // Movement2
    private readonly InputActionMap m_Movement2;
    private List<IMovement2Actions> m_Movement2ActionsCallbackInterfaces = new List<IMovement2Actions>();
    private readonly InputAction m_Movement2_Newaction;
    public struct Movement2Actions
    {
        private @PlayerMovement m_Wrapper;
        public Movement2Actions(@PlayerMovement wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Movement2_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Movement2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Movement2Actions set) { return set.Get(); }
        public void AddCallbacks(IMovement2Actions instance)
        {
            if (instance == null || m_Wrapper.m_Movement2ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Movement2ActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IMovement2Actions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IMovement2Actions instance)
        {
            if (m_Wrapper.m_Movement2ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovement2Actions instance)
        {
            foreach (var item in m_Wrapper.m_Movement2ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Movement2ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Movement2Actions @Movement2 => new Movement2Actions(this);
    public interface IMovement1Actions
    {
        void OnLeftRight(InputAction.CallbackContext context);
        void OnJumpREAL(InputAction.CallbackContext context);
    }
    public interface IMovement2Actions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}

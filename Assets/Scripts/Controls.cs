// GENERATED AUTOMATICALLY FROM 'Assets/SO/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace PlayerInput
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Clicks"",
            ""id"": ""5be05f7a-3a5b-4c37-921f-d6649cd42342"",
            ""actions"": [
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""91271b4c-ada5-4c67-8746-20569745ff7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""40619812-08cd-4253-a772-b9f986138200"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CursorPosition"",
                    ""type"": ""Value"",
                    ""id"": ""5c6c0197-4084-48e5-bab4-72913271a08f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2bb20576-c73d-4a60-9e42-90b5aad75658"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Alpha"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3128bf7e-65b6-4bb0-9262-186155896c31"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Alpha"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc198291-8801-4e94-9003-d884416aa3fc"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Alpha"",
                    ""action"": ""CursorPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Alpha"",
            ""bindingGroup"": ""Alpha"",
            ""devices"": []
        }
    ]
}");
            // Clicks
            m_Clicks = asset.FindActionMap("Clicks", throwIfNotFound: true);
            m_Clicks_LeftClick = m_Clicks.FindAction("LeftClick", throwIfNotFound: true);
            m_Clicks_RightClick = m_Clicks.FindAction("RightClick", throwIfNotFound: true);
            m_Clicks_CursorPosition = m_Clicks.FindAction("CursorPosition", throwIfNotFound: true);
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

        // Clicks
        private readonly InputActionMap m_Clicks;
        private IClicksActions m_ClicksActionsCallbackInterface;
        private readonly InputAction m_Clicks_LeftClick;
        private readonly InputAction m_Clicks_RightClick;
        private readonly InputAction m_Clicks_CursorPosition;
        public struct ClicksActions
        {
            private @Controls m_Wrapper;
            public ClicksActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @LeftClick => m_Wrapper.m_Clicks_LeftClick;
            public InputAction @RightClick => m_Wrapper.m_Clicks_RightClick;
            public InputAction @CursorPosition => m_Wrapper.m_Clicks_CursorPosition;
            public InputActionMap Get() { return m_Wrapper.m_Clicks; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ClicksActions set) { return set.Get(); }
            public void SetCallbacks(IClicksActions instance)
            {
                if (m_Wrapper.m_ClicksActionsCallbackInterface != null)
                {
                    @LeftClick.started -= m_Wrapper.m_ClicksActionsCallbackInterface.OnLeftClick;
                    @LeftClick.performed -= m_Wrapper.m_ClicksActionsCallbackInterface.OnLeftClick;
                    @LeftClick.canceled -= m_Wrapper.m_ClicksActionsCallbackInterface.OnLeftClick;
                    @RightClick.started -= m_Wrapper.m_ClicksActionsCallbackInterface.OnRightClick;
                    @RightClick.performed -= m_Wrapper.m_ClicksActionsCallbackInterface.OnRightClick;
                    @RightClick.canceled -= m_Wrapper.m_ClicksActionsCallbackInterface.OnRightClick;
                    @CursorPosition.started -= m_Wrapper.m_ClicksActionsCallbackInterface.OnCursorPosition;
                    @CursorPosition.performed -= m_Wrapper.m_ClicksActionsCallbackInterface.OnCursorPosition;
                    @CursorPosition.canceled -= m_Wrapper.m_ClicksActionsCallbackInterface.OnCursorPosition;
                }
                m_Wrapper.m_ClicksActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @LeftClick.started += instance.OnLeftClick;
                    @LeftClick.performed += instance.OnLeftClick;
                    @LeftClick.canceled += instance.OnLeftClick;
                    @RightClick.started += instance.OnRightClick;
                    @RightClick.performed += instance.OnRightClick;
                    @RightClick.canceled += instance.OnRightClick;
                    @CursorPosition.started += instance.OnCursorPosition;
                    @CursorPosition.performed += instance.OnCursorPosition;
                    @CursorPosition.canceled += instance.OnCursorPosition;
                }
            }
        }
        public ClicksActions @Clicks => new ClicksActions(this);
        private int m_AlphaSchemeIndex = -1;
        public InputControlScheme AlphaScheme
        {
            get
            {
                if (m_AlphaSchemeIndex == -1) m_AlphaSchemeIndex = asset.FindControlSchemeIndex("Alpha");
                return asset.controlSchemes[m_AlphaSchemeIndex];
            }
        }
        public interface IClicksActions
        {
            void OnLeftClick(InputAction.CallbackContext context);
            void OnRightClick(InputAction.CallbackContext context);
            void OnCursorPosition(InputAction.CallbackContext context);
        }
    }
}

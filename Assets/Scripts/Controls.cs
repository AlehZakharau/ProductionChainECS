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
                    ""id"": ""96f2e33b-17e0-4caa-b8f7-a318eeb93d39"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
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
        },
        {
            ""name"": ""Touch"",
            ""id"": ""e150e25e-43c5-4f02-9ff4-c71f8da0f050"",
            ""actions"": [
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fa4b8f17-7ca7-466e-9dbd-3434882e92b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimatyPosition"",
                    ""type"": ""Value"",
                    ""id"": ""3578b25d-2ae1-4b26-ab11-c59f8bf9ade0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tap"",
                    ""type"": ""PassThrough"",
                    ""id"": ""334cb03e-ae24-40b0-b45d-b3d3f5dcc16d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Release"",
                    ""type"": ""PassThrough"",
                    ""id"": ""096874f4-3a44-4805-bbf3-50b113a32581"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""28e99f73-e755-4c00-bdfc-ff671a535fe2"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6863f48d-31bb-4ae0-8ec5-9bd9065ab170"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimatyPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8503526d-6a5a-4e75-9d9b-1e984eddac59"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a30fa21-be34-49f1-821a-0fc45b0372f8"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Release"",
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
            // Touch
            m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
            m_Touch_PrimaryContact = m_Touch.FindAction("PrimaryContact", throwIfNotFound: true);
            m_Touch_PrimatyPosition = m_Touch.FindAction("PrimatyPosition", throwIfNotFound: true);
            m_Touch_Tap = m_Touch.FindAction("Tap", throwIfNotFound: true);
            m_Touch_Release = m_Touch.FindAction("Release", throwIfNotFound: true);
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

        // Touch
        private readonly InputActionMap m_Touch;
        private ITouchActions m_TouchActionsCallbackInterface;
        private readonly InputAction m_Touch_PrimaryContact;
        private readonly InputAction m_Touch_PrimatyPosition;
        private readonly InputAction m_Touch_Tap;
        private readonly InputAction m_Touch_Release;
        public struct TouchActions
        {
            private @Controls m_Wrapper;
            public TouchActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @PrimaryContact => m_Wrapper.m_Touch_PrimaryContact;
            public InputAction @PrimatyPosition => m_Wrapper.m_Touch_PrimatyPosition;
            public InputAction @Tap => m_Wrapper.m_Touch_Tap;
            public InputAction @Release => m_Wrapper.m_Touch_Release;
            public InputActionMap Get() { return m_Wrapper.m_Touch; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
            public void SetCallbacks(ITouchActions instance)
            {
                if (m_Wrapper.m_TouchActionsCallbackInterface != null)
                {
                    @PrimaryContact.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                    @PrimaryContact.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                    @PrimaryContact.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                    @PrimatyPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimatyPosition;
                    @PrimatyPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimatyPosition;
                    @PrimatyPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimatyPosition;
                    @Tap.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTap;
                    @Tap.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTap;
                    @Tap.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTap;
                    @Release.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnRelease;
                    @Release.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnRelease;
                    @Release.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnRelease;
                }
                m_Wrapper.m_TouchActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PrimaryContact.started += instance.OnPrimaryContact;
                    @PrimaryContact.performed += instance.OnPrimaryContact;
                    @PrimaryContact.canceled += instance.OnPrimaryContact;
                    @PrimatyPosition.started += instance.OnPrimatyPosition;
                    @PrimatyPosition.performed += instance.OnPrimatyPosition;
                    @PrimatyPosition.canceled += instance.OnPrimatyPosition;
                    @Tap.started += instance.OnTap;
                    @Tap.performed += instance.OnTap;
                    @Tap.canceled += instance.OnTap;
                    @Release.started += instance.OnRelease;
                    @Release.performed += instance.OnRelease;
                    @Release.canceled += instance.OnRelease;
                }
            }
        }
        public TouchActions @Touch => new TouchActions(this);
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
        public interface ITouchActions
        {
            void OnPrimaryContact(InputAction.CallbackContext context);
            void OnPrimatyPosition(InputAction.CallbackContext context);
            void OnTap(InputAction.CallbackContext context);
            void OnRelease(InputAction.CallbackContext context);
        }
    }
}

// GENERATED AUTOMATICALLY FROM 'Assets/AnimeDiseaseGame/InputSystem/Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace AnimeDiseaseGame.InputSystem
{
    public class @Actions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Actions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Actions"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""0b00dcef-d067-486d-b00d-0d8fd2530ca9"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""14655a44-2b43-4444-af3a-5a20139c2ff0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""186512ae-3e4c-4828-ae79-6334e4669463"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0280e0e9-6203-4808-9d57-1cafeb1af546"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b38083b1-0a67-485c-877d-66629042e9b0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""516b3bdf-a706-4772-960a-630ab35fa750"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""99f94a63-e92c-441a-bed9-87a989dee737"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1e5b5563-066e-44fe-805f-3352d609a7fb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""3506dfe7-ffea-499a-96b8-454f828c7d6b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""276847b2-8daa-40c1-a2b8-3385eb1b727b"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""17021b74-8e90-40cf-814d-b11d727917c3"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b2fa6331-b49d-4766-8a11-46abcacb8830"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""35e3a8cd-b40f-4a46-bab2-f3057fada88a"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5856ffbe-d3a1-411b-ab10-4b83431d1731"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48ab6f6a-6df9-41d8-8076-28f71d49db8a"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Input"",
            ""bindingGroup"": ""Input"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Character
            m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
            m_Character_Movement = m_Character.FindAction("Movement", throwIfNotFound: true);
            m_Character_Fire = m_Character.FindAction("Fire", throwIfNotFound: true);
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

        // Character
        private readonly InputActionMap m_Character;
        private ICharacterActions m_CharacterActionsCallbackInterface;
        private readonly InputAction m_Character_Movement;
        private readonly InputAction m_Character_Fire;
        public struct CharacterActions
        {
            private @Actions m_Wrapper;
            public CharacterActions(@Actions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Character_Movement;
            public InputAction @Fire => m_Wrapper.m_Character_Fire;
            public InputActionMap Get() { return m_Wrapper.m_Character; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterActions instance)
            {
                if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                    @Fire.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnFire;
                }
                m_Wrapper.m_CharacterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                }
            }
        }
        public CharacterActions @Character => new CharacterActions(this);
        private int m_InputSchemeIndex = -1;
        public InputControlScheme InputScheme
        {
            get
            {
                if (m_InputSchemeIndex == -1) m_InputSchemeIndex = asset.FindControlSchemeIndex("Input");
                return asset.controlSchemes[m_InputSchemeIndex];
            }
        }
        public interface ICharacterActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
        }
    }
}

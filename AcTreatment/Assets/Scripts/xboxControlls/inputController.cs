// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/xboxControlls/inputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""inputController"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""5dc775cd-a1f8-4a48-919b-0cdc7ba78693"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""2167916e-58ca-4660-982f-c410c952e0d0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""6800e014-82cd-489a-8f98-729ccea294d3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""ea9072d6-2c5f-4fb9-8ef1-cf0ebd048616"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""anyButton_left"",
                    ""type"": ""Button"",
                    ""id"": ""04c7bd8a-93fa-48a2-805e-b5f67fe6d77f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""4589a5ab-9b23-47de-9936-417139cb7d1f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""bfbaac09-ea81-4fc7-a474-6a9a95e14ad7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""111dd921-de47-4344-884e-c18e253cc0c3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""5b6b56d2-ba0a-4a0f-895c-aba4326d8d6c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""73b12309-316d-40e9-8d7e-422fe2ef0182"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""View"",
                    ""type"": ""Button"",
                    ""id"": ""4ee4d575-8567-4248-87ce-29b3c3caee10"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""left_bumper"",
                    ""type"": ""Button"",
                    ""id"": ""56c99ee4-a29a-4f29-b21f-db7f46736110"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""right_bumper"",
                    ""type"": ""Button"",
                    ""id"": ""8af7bba7-aa98-47e6-a6ea-509e6e17795c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""left trigger"",
                    ""type"": ""Button"",
                    ""id"": ""08f2ff4b-0ba7-4fa1-878c-176b3c0aa9e7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""right trigger"",
                    ""type"": ""Button"",
                    ""id"": ""eba9baba-e831-4b67-94be-b29e23a517f2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ee701ec3-731a-4240-923e-fde8147c7dad"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""777e37aa-fa6a-46c8-8c67-c4266cefd7fc"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d995a04-4992-48ca-bb1b-a426a6a3db73"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc61079e-8d8b-4c78-ac2e-f83f3e32c16d"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""anyButton_left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee159be7-ff1a-4b2f-b86a-0bfc0c4d9ee1"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""275a8bf1-c334-4b1f-aac1-aeb58253a8d6"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5981ea7-f2bd-4294-8ebc-536627c80d6e"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3b30bcb-f8bf-4c0c-9e53-56a8cb53d239"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e59b7b8-c878-4e50-beeb-9ba10d11f7cd"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0c9ba89-e407-4c1e-82ec-07f6ecdcf390"",
                    ""path"": ""<XInputController>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""107d0af0-fba1-491b-89b1-6e869d588fd6"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left_bumper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef628b55-213b-4d87-955f-2666818cf95b"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""right_bumper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b7088e3-da16-4603-876a-a2742a0a4027"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b580e06-b306-4d2c-adf4-6e12514691b5"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""right trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_Move = m_gameplay.FindAction("Move", throwIfNotFound: true);
        m_gameplay_Up = m_gameplay.FindAction("Up", throwIfNotFound: true);
        m_gameplay_Down = m_gameplay.FindAction("Down", throwIfNotFound: true);
        m_gameplay_anyButton_left = m_gameplay.FindAction("anyButton_left", throwIfNotFound: true);
        m_gameplay_Y = m_gameplay.FindAction("Y", throwIfNotFound: true);
        m_gameplay_X = m_gameplay.FindAction("X", throwIfNotFound: true);
        m_gameplay_B = m_gameplay.FindAction("B", throwIfNotFound: true);
        m_gameplay_A = m_gameplay.FindAction("A", throwIfNotFound: true);
        m_gameplay_Menu = m_gameplay.FindAction("Menu", throwIfNotFound: true);
        m_gameplay_View = m_gameplay.FindAction("View", throwIfNotFound: true);
        m_gameplay_left_bumper = m_gameplay.FindAction("left_bumper", throwIfNotFound: true);
        m_gameplay_right_bumper = m_gameplay.FindAction("right_bumper", throwIfNotFound: true);
        m_gameplay_lefttrigger = m_gameplay.FindAction("left trigger", throwIfNotFound: true);
        m_gameplay_righttrigger = m_gameplay.FindAction("right trigger", throwIfNotFound: true);
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

    // gameplay
    private readonly InputActionMap m_gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_gameplay_Move;
    private readonly InputAction m_gameplay_Up;
    private readonly InputAction m_gameplay_Down;
    private readonly InputAction m_gameplay_anyButton_left;
    private readonly InputAction m_gameplay_Y;
    private readonly InputAction m_gameplay_X;
    private readonly InputAction m_gameplay_B;
    private readonly InputAction m_gameplay_A;
    private readonly InputAction m_gameplay_Menu;
    private readonly InputAction m_gameplay_View;
    private readonly InputAction m_gameplay_left_bumper;
    private readonly InputAction m_gameplay_right_bumper;
    private readonly InputAction m_gameplay_lefttrigger;
    private readonly InputAction m_gameplay_righttrigger;
    public struct GameplayActions
    {
        private @InputController m_Wrapper;
        public GameplayActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_gameplay_Move;
        public InputAction @Up => m_Wrapper.m_gameplay_Up;
        public InputAction @Down => m_Wrapper.m_gameplay_Down;
        public InputAction @anyButton_left => m_Wrapper.m_gameplay_anyButton_left;
        public InputAction @Y => m_Wrapper.m_gameplay_Y;
        public InputAction @X => m_Wrapper.m_gameplay_X;
        public InputAction @B => m_Wrapper.m_gameplay_B;
        public InputAction @A => m_Wrapper.m_gameplay_A;
        public InputAction @Menu => m_Wrapper.m_gameplay_Menu;
        public InputAction @View => m_Wrapper.m_gameplay_View;
        public InputAction @left_bumper => m_Wrapper.m_gameplay_left_bumper;
        public InputAction @right_bumper => m_Wrapper.m_gameplay_right_bumper;
        public InputAction @lefttrigger => m_Wrapper.m_gameplay_lefttrigger;
        public InputAction @righttrigger => m_Wrapper.m_gameplay_righttrigger;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Up.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @anyButton_left.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAnyButton_left;
                @anyButton_left.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAnyButton_left;
                @anyButton_left.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAnyButton_left;
                @Y.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnY;
                @Y.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnY;
                @Y.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnY;
                @X.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnX;
                @B.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnB;
                @A.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnA;
                @Menu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                @View.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @left_bumper.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft_bumper;
                @left_bumper.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft_bumper;
                @left_bumper.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft_bumper;
                @right_bumper.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight_bumper;
                @right_bumper.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight_bumper;
                @right_bumper.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight_bumper;
                @lefttrigger.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLefttrigger;
                @lefttrigger.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLefttrigger;
                @lefttrigger.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLefttrigger;
                @righttrigger.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRighttrigger;
                @righttrigger.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRighttrigger;
                @righttrigger.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRighttrigger;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @anyButton_left.started += instance.OnAnyButton_left;
                @anyButton_left.performed += instance.OnAnyButton_left;
                @anyButton_left.canceled += instance.OnAnyButton_left;
                @Y.started += instance.OnY;
                @Y.performed += instance.OnY;
                @Y.canceled += instance.OnY;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
                @left_bumper.started += instance.OnLeft_bumper;
                @left_bumper.performed += instance.OnLeft_bumper;
                @left_bumper.canceled += instance.OnLeft_bumper;
                @right_bumper.started += instance.OnRight_bumper;
                @right_bumper.performed += instance.OnRight_bumper;
                @right_bumper.canceled += instance.OnRight_bumper;
                @lefttrigger.started += instance.OnLefttrigger;
                @lefttrigger.performed += instance.OnLefttrigger;
                @lefttrigger.canceled += instance.OnLefttrigger;
                @righttrigger.started += instance.OnRighttrigger;
                @righttrigger.performed += instance.OnRighttrigger;
                @righttrigger.canceled += instance.OnRighttrigger;
            }
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnAnyButton_left(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnView(InputAction.CallbackContext context);
        void OnLeft_bumper(InputAction.CallbackContext context);
        void OnRight_bumper(InputAction.CallbackContext context);
        void OnLefttrigger(InputAction.CallbackContext context);
        void OnRighttrigger(InputAction.CallbackContext context);
    }
}

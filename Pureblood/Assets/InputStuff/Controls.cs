// GENERATED AUTOMATICALLY FROM 'Assets/InputStuff/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""082dea60-beaa-48d8-b68e-e2e0c5fb015e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""5882e23c-8f0e-4c00-87b8-a5da78e52005"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""9585ef26-f4bc-4c48-83ab-7ca9a38619d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""f64986ae-df51-49ee-bf4e-1b5f950510d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b32dfc3f-7371-4399-8fbb-4725bd63b765"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""b794768c-c901-400d-9b97-d80560165643"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollConsumable"",
                    ""type"": ""Button"",
                    ""id"": ""0540f5cb-7b8e-4944-8857-1c83fa9f7ffb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""QuestLog"",
                    ""type"": ""Button"",
                    ""id"": ""f6752768-cdfc-4f0a-aed2-e7055e722759"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""0237a775-aef9-4543-8b22-b418f2808564"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Levelup"",
                    ""type"": ""Button"",
                    ""id"": ""7f7471e6-845d-4f06-8e87-647496a404fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""ab7ad7e4-daee-433a-a89e-c79dbaa91e0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WeaponOne"",
                    ""type"": ""Button"",
                    ""id"": ""72e7a2e3-82d0-4e62-a0d4-83c5ab36922b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WeaponTwo"",
                    ""type"": ""Button"",
                    ""id"": ""0f6bf133-7f89-451b-b6d6-efa032cc1a01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WeaponThree"",
                    ""type"": ""Button"",
                    ""id"": ""bcde698c-33c4-4944-a863-e70aa422f735"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Parry"",
                    ""type"": ""Button"",
                    ""id"": ""4951d167-d535-46cd-ad7c-7837c4645f6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f977cecb-ca1d-41f2-9130-5f4046abc675"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""81dc006a-9b24-4666-9e8f-299b54b9a29c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c261e01-a14b-441e-bf49-bad5aac692aa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cfc70b2b-ae26-433b-b332-7b53717d8aac"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2196267b-c815-40aa-a90c-4b038d6b6b4e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""47cc906c-56e0-46f0-97a0-aee6928f7d27"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f08c3b12-4aac-4382-b2e4-7ad6bb179c9d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac620442-bb96-46dd-a716-065b7d176ff7"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6283a930-8bd3-4b97-930a-35ad09fd36aa"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bd66b5a-2621-4396-ac10-4d69582b916a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04988983-c546-4e02-bf62-8ab44c6633cc"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc8db1ea-4afd-417b-ada8-7c539e3ca62c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5235c68a-6d74-46cd-afd7-cc8e572f6858"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""ScrollConsumable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd26c6d9-c8b3-447d-bab5-521014ea779a"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuestLog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30204a14-89fb-436c-ab02-ea19fc7631cd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1bf887b-9fd1-466e-bf5c-c792eda9f218"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c453e5a-c5ed-43e1-97b9-41caca0403d1"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Levelup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b44f0bb-8936-44a9-ba64-5258be82d276"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""932c7a84-f7fa-4032-aa88-43127bde042a"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""610c153c-82cf-45ad-b452-46abf6c98bb6"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce90d73d-9442-4bc8-8726-6ea99298029e"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponThree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""332990b2-f3a8-4076-b72c-fca3d867fbc3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Parry"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KB+M"",
            ""bindingGroup"": ""KB+M"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_ScrollConsumable = m_Player.FindAction("ScrollConsumable", throwIfNotFound: true);
        m_Player_QuestLog = m_Player.FindAction("QuestLog", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Levelup = m_Player.FindAction("Levelup", throwIfNotFound: true);
        m_Player_Use = m_Player.FindAction("Use", throwIfNotFound: true);
        m_Player_WeaponOne = m_Player.FindAction("WeaponOne", throwIfNotFound: true);
        m_Player_WeaponTwo = m_Player.FindAction("WeaponTwo", throwIfNotFound: true);
        m_Player_WeaponThree = m_Player.FindAction("WeaponThree", throwIfNotFound: true);
        m_Player_Parry = m_Player.FindAction("Parry", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Inventory;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_ScrollConsumable;
    private readonly InputAction m_Player_QuestLog;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Levelup;
    private readonly InputAction m_Player_Use;
    private readonly InputAction m_Player_WeaponOne;
    private readonly InputAction m_Player_WeaponTwo;
    private readonly InputAction m_Player_WeaponThree;
    private readonly InputAction m_Player_Parry;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Inventory => m_Wrapper.m_Player_Inventory;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @ScrollConsumable => m_Wrapper.m_Player_ScrollConsumable;
        public InputAction @QuestLog => m_Wrapper.m_Player_QuestLog;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Levelup => m_Wrapper.m_Player_Levelup;
        public InputAction @Use => m_Wrapper.m_Player_Use;
        public InputAction @WeaponOne => m_Wrapper.m_Player_WeaponOne;
        public InputAction @WeaponTwo => m_Wrapper.m_Player_WeaponTwo;
        public InputAction @WeaponThree => m_Wrapper.m_Player_WeaponThree;
        public InputAction @Parry => m_Wrapper.m_Player_Parry;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Inventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @ScrollConsumable.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnScrollConsumable;
                @ScrollConsumable.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnScrollConsumable;
                @ScrollConsumable.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnScrollConsumable;
                @QuestLog.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuestLog;
                @QuestLog.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuestLog;
                @QuestLog.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuestLog;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Levelup.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLevelup;
                @Levelup.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLevelup;
                @Levelup.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLevelup;
                @Use.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @WeaponOne.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponOne;
                @WeaponOne.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponOne;
                @WeaponOne.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponOne;
                @WeaponTwo.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponTwo;
                @WeaponTwo.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponTwo;
                @WeaponTwo.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponTwo;
                @WeaponThree.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponThree;
                @WeaponThree.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponThree;
                @WeaponThree.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponThree;
                @Parry.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnParry;
                @Parry.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnParry;
                @Parry.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnParry;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @ScrollConsumable.started += instance.OnScrollConsumable;
                @ScrollConsumable.performed += instance.OnScrollConsumable;
                @ScrollConsumable.canceled += instance.OnScrollConsumable;
                @QuestLog.started += instance.OnQuestLog;
                @QuestLog.performed += instance.OnQuestLog;
                @QuestLog.canceled += instance.OnQuestLog;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Levelup.started += instance.OnLevelup;
                @Levelup.performed += instance.OnLevelup;
                @Levelup.canceled += instance.OnLevelup;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @WeaponOne.started += instance.OnWeaponOne;
                @WeaponOne.performed += instance.OnWeaponOne;
                @WeaponOne.canceled += instance.OnWeaponOne;
                @WeaponTwo.started += instance.OnWeaponTwo;
                @WeaponTwo.performed += instance.OnWeaponTwo;
                @WeaponTwo.canceled += instance.OnWeaponTwo;
                @WeaponThree.started += instance.OnWeaponThree;
                @WeaponThree.performed += instance.OnWeaponThree;
                @WeaponThree.canceled += instance.OnWeaponThree;
                @Parry.started += instance.OnParry;
                @Parry.performed += instance.OnParry;
                @Parry.canceled += instance.OnParry;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KB+M");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnScrollConsumable(InputAction.CallbackContext context);
        void OnQuestLog(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnLevelup(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnWeaponOne(InputAction.CallbackContext context);
        void OnWeaponTwo(InputAction.CallbackContext context);
        void OnWeaponThree(InputAction.CallbackContext context);
        void OnParry(InputAction.CallbackContext context);
    }
}

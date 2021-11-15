using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class UIControls : MonoBehaviour
{

    Controls controls;

    public static UIControls instance;
    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls();
        controls.Player.Inventory.performed += ToggleInventory;
        controls.Player.Inventory.Enable();

        controls.Player.Pause.performed += TogglePauseMenu;
        controls.Player.Pause.Enable();

        controls.Player.ScrollConsumable.performed += ScrollConsumables;
        controls.Player.ScrollConsumable.Enable();

        controls.Player.QuestLog.performed += ToggleQuestLog;
        controls.Player.QuestLog.Enable();

        controls.Player.Levelup.performed += LevelUpToggle;
        controls.Player.Levelup.Enable();

        controls.Player.Use.performed += UseItem;
        controls.Player.Use.Enable();

        controls.Player.WeaponOne.performed += EquipWeaponOne;
        controls.Player.WeaponOne.Enable();

        controls.Player.WeaponTwo.performed += EquipWeaponTwo;
        controls.Player.WeaponTwo.Enable();

        controls.Player.WeaponThree.performed += EquipWeaponThree;
        controls.Player.WeaponThree.Enable();

        
        if (instance != null)
        {
            instance = this;
        } else if (instance != this)
        {
            Debug.Log("Multiple instances of UIControls. Fix this ya dingus!");
            Destroy(this);
        }

    }




    [SerializeField] ItemSlot consumableGUISlot;
    [SerializeField] ItemSlot weaponGUISlot;

    private void ScrollConsumables(InputAction.CallbackContext context)
    { 
        consumableGUISlot.SetItem(Player.instance.GetInventory().GetNextConsumable());
        consumableGUISlot.GetItem().GetID();
    }
    

    private bool inventoryToggled = false;
    [SerializeField] GameObject inventoryObject;
    [SerializeField] GameObject inventoryItemList;
    private void ToggleInventory(InputAction.CallbackContext context)
    {
        if (!pauseMenuToggled)
        {
            if (inventoryToggled)
            {
                inventoryToggled = false;
                inventoryItemList.gameObject.SetActive(false);
                inventoryObject.gameObject.SetActive(false);
            }
            else
            {
                OverrideUI();
                inventoryToggled = true;
                inventoryObject.gameObject.SetActive(true);
            }
        }
    }

    private bool questsToggled = false;
    [SerializeField] GameObject questObject;
    private void ToggleQuestLog(InputAction.CallbackContext context)
    {
        if (!pauseMenuToggled)
        {
            if (questsToggled)
            {
                questsToggled = false;
                questObject.gameObject.SetActive(false);
            }
            else
            {
                OverrideUI();
                questsToggled = true;
                questObject.gameObject.SetActive(true);
                QuestManager.instance.UpdateQuests();
            }
        }
    }

    private bool dialogueWindowToggled = false;
    [SerializeField] GameObject dialogueObject;
    public void ToggleDialogue()
    {
        if (dialogueWindowToggled)
        {
            dialogueWindowToggled = false;
            dialogueObject.gameObject.SetActive(false);
        }
        else
        {
            dialogueWindowToggled = true;
            dialogueObject.gameObject.SetActive(true);
        }
    }

    private bool levelUpWindowToggled = false;
    [SerializeField] GameObject levelUpObject;
    public void LevelUpToggle(InputAction.CallbackContext context)
    {
        if (levelUpWindowToggled)
        {
            levelUpWindowToggled = false;
            levelUpObject.gameObject.SetActive(false);
        }
        else
        {
            OverrideUI();
            levelUpWindowToggled = true;
            levelUpObject.gameObject.SetActive(true);
        }
    }


    private bool pauseMenuToggled = false;
    [SerializeField] GameObject pauseMenuObject;
    private void TogglePauseMenu(InputAction.CallbackContext context)
    {
        TogglePauseMenu();
    }

    public void TogglePauseMenu()
    {
        if (pauseMenuToggled)
        {
            pauseMenuToggled = false;
            pauseMenuObject.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenuToggled = true;
            pauseMenuObject.gameObject.SetActive(true);
            Time.timeScale = 0;
            OverrideUI();
        }
    }

    private void OverrideUI()
    {
        inventoryToggled = false;
        inventoryObject.gameObject.SetActive(false);
        questsToggled = false;
        questObject.gameObject.SetActive(false);
        levelUpWindowToggled = false;
        levelUpObject.gameObject.SetActive(false);

    }

    private void UseItem(InputAction.CallbackContext context)
    {
        if(consumableGUISlot.GetItem().GetID() != 0)
        {
            
        }
        if(consumableGUISlot.GetItem().GetComponent<Consumables>().SubtractQuantity(1))
        {
            consumableGUISlot.GetItem().GetComponent<Consumables>().useItem();
        }
        else
        {
            for(int i = 0; i < Player.instance.GetInventory().GetEquippedConsumables().Length; i++)
            {
                if(consumableGUISlot.GetItem().GetID() == Player.instance.GetInventory().GetEquippedConsumables()[i].GetID())
                {
                    
                }
            }
        }
        //Debug.Log("do shit");
        //Player.instance.GetInventory().GetEquippedConsumables()[0].useItem();

    }
    private void EquipWeaponOne(InputAction.CallbackContext context)
    {
        Player.instance.EquipItemInHand(Player.instance.GetInventory().GetEquippedWeapons()[0]);
        weaponGUISlot.SetItem(Player.instance.GetInventory().GetEquippedWeapons()[0]);
    }

    private void EquipWeaponTwo(InputAction.CallbackContext context)
    {
        Player.instance.EquipItemInHand(Player.instance.GetInventory().GetEquippedWeapons()[1]);
        weaponGUISlot.SetItem(Player.instance.GetInventory().GetEquippedWeapons()[1]);
    }
    private void EquipWeaponThree(InputAction.CallbackContext context)
    {
        Player.instance.EquipItemInHand(Player.instance.GetInventory().GetEquippedWeapons()[2]);
        weaponGUISlot.SetItem(Player.instance.GetInventory().GetEquippedWeapons()[2]);
    }

}

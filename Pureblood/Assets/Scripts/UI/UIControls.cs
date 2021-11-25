using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class UIControls : MonoBehaviour
{
    [SerializeField] AudioClip[] UIAudio;
    [SerializeField] AudioClip[] EquipAudio;

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

        
        if (instance == null)
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
        bool hasConsumablesEquipped = false;
        for(int i = 0; i < Player.instance.theInventory.equippedConsumables.Length; i++)
        {
            if(Player.instance.theInventory.equippedConsumables[i].item != null)
            {
                hasConsumablesEquipped = true;
                break;
            }
        }
        if(hasConsumablesEquipped)
        {
            consumableGUISlot.SetItem(Player.instance.theInventory.GetNextConsumable());
        }
        
    }
    

    private bool inventoryToggled = false;
    [SerializeField] GameObject inventoryObject;
    [SerializeField] GameObject inventoryItemList;
    private void ToggleInventory(InputAction.CallbackContext context)
    {
        SoundMaster.instance.PlayRandomSound(UIAudio);
        if (!pauseMenuToggled)
        {
            if (inventoryToggled)
            {
                inventoryToggled = false;
                inventoryItemList.gameObject.SetActive(false);
                inventoryObject.gameObject.SetActive(false);
            }
            else if (OverrideUI())
            {
                inventoryToggled = true;
                inventoryObject.gameObject.SetActive(true);
            }
        }
    }

    private bool questsToggled = false;
    [SerializeField] GameObject questObject;
    private void ToggleQuestLog(InputAction.CallbackContext context)
    {
        SoundMaster.instance.PlayRandomSound(UIAudio);
        if (!pauseMenuToggled)
        {
            if (questsToggled)
            {
                questsToggled = false;
                questObject.gameObject.SetActive(false);
            }
            else if (OverrideUI())
            {
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
            OverrideUI();
            dialogueWindowToggled = true;
            dialogueObject.gameObject.SetActive(true);
        }
    }

    private bool levelUpWindowToggled = false;
    [SerializeField] GameObject levelUpObject;
    public void LevelUpToggle(InputAction.CallbackContext context)
    {
        SoundMaster.instance.PlayRandomSound(UIAudio);
        if (levelUpWindowToggled)
        {
            levelUpWindowToggled = false;
            levelUpObject.gameObject.SetActive(false);
        }
        else if (OverrideUI())
        {
            levelUpWindowToggled = true;
            levelUpObject.gameObject.SetActive(true);
        }
    }

    private bool shopMenuToggled = false;
    [SerializeField] GameObject shopObject;
    public void ShopMenuToggle()
    {
        if (shopMenuToggled)
        {
            shopMenuToggled = false;
            shopObject.gameObject.SetActive(false);
        }
        else if (OverrideUI())
        {
            shopMenuToggled = true;
            shopObject.gameObject.SetActive(true);
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
        if (shopMenuToggled)
        {
            ShopMenuToggle();
        } else if (pauseMenuToggled)
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

    private bool OverrideUI()
    {
        if (dialogueWindowToggled || shopMenuToggled)
        {
            return false;
        }

        inventoryToggled = false;
        inventoryObject.gameObject.SetActive(false);
        questsToggled = false;
        questObject.gameObject.SetActive(false);
        levelUpWindowToggled = false;
        levelUpObject.gameObject.SetActive(false);

        return true;

    }

    private void UseItem(InputAction.CallbackContext context)
    {

        /*
         * OLD INV CODE
        if(consumableGUISlot.GetItem().GetComponent<Consumables>().SubtractQuantity(1))
        {
            consumableGUISlot.GetItem().GetComponent<Consumables>().useItem();
        }
        if(consumableGUISlot.GetItem().GetComponent<Consumables>().GetStackAmount() == 0)
        {
            for(int i = 0; i < Player.instance.GetInventory().GetEquippedConsumables().Length; i++)
            {
                if (Player.instance.GetInventory().GetEquippedConsumables()[i].GetID() == consumableGUISlot.GetItem().GetID())
                {
                    Player.instance.GetInventory().GetEquippedConsumables()[i] = null;
                    InventoryUI.instance.GetEquipSlots()[i + 5].SetItem(null);
                }
            }
            consumableGUISlot.SetItem(null);
            
        }
        
        //Debug.Log("do shit");
        //Player.instance.GetInventory().GetEquippedConsumables()[0].useItem();
        */

        //TESTING FOR NEW INV SYSTEM
        if(Player.instance.equippedConsumable != null && Player.instance.equippedConsumable.SubtractAmount(1) )
        {
            Player.instance.consumablesFunctions.UseItem(Player.instance.equippedConsumable.item.itemName);
            if(Player.instance.equippedConsumable.amount == 0)
            {
                for(int i = 0; i < Player.instance.theInventory.Container.Count; i++)
                {
                    if(Player.instance.theInventory.Container[i].item == Player.instance.equippedConsumable.item)
                    {
                        //Debug.Log("got here");
                        Player.instance.theInventory.Container.RemoveAt(i);
                        for (int j = 0; j < Player.instance.theInventory.equippedConsumables.Length; j++)
                        {
                            if(Player.instance.theInventory.equippedConsumables[j].item != null && Player.instance.theInventory.equippedConsumables[j].item == Player.instance.equippedConsumable.item)
                            {
                                InventoryUI.instance.inventorySlots[j + 5].SetItem(null);
                                //InventoryUI.instance.inventorySlots[j + 5].item.item = null;
                                //InventoryUI.instance.inventorySlots[j + 5] = null;
                                Player.instance.theInventory.equippedConsumables[j].item = null;
                            }
                        }
                        Player.instance.equippedConsumable = null;
                        consumableGUISlot.SetItem(null);
                        
                        //consumableGUISlot = null;
                        List<InventorySlot> ConsumableList = new List<InventorySlot>();
                        for (int j = 0; j < Player.instance.theInventory.Container.Count; j++)
                        {
                            if (Player.instance.theInventory.Container[j] != null && Player.instance.theInventory.Container[j].item.type == ItemType.Consumable)
                            {
                                ConsumableList.Add(new InventorySlot(Player.instance.theInventory.Container[j].item, Player.instance.theInventory.Container[j].amount));
                            }
                        }
                        InventoryUI.instance.SortItems(ConsumableList.ToArray());
                    }
                }
            }
        }
        
        

    }
    private void EquipWeaponOne(InputAction.CallbackContext context)
    {
        if(Player.instance.currentState != Entity.EntityStates.ATTACKING && Player.instance.theInventory.equippedWeapons[0].item != null)
        {
            SoundMaster.instance.PlayRandomSound(EquipAudio);
            Player.instance.EquipItemInHand(Player.instance.theInventory.equippedWeapons[0]);
            weaponGUISlot.SetItem(Player.instance.theInventory.equippedWeapons[0]);
        }
        
    }

    private void EquipWeaponTwo(InputAction.CallbackContext context)
    {
        if (Player.instance.currentState != Entity.EntityStates.ATTACKING && Player.instance.theInventory.equippedWeapons[1].item != null)
        {
            SoundMaster.instance.PlayRandomSound(EquipAudio);
            Player.instance.EquipItemInHand(Player.instance.theInventory.equippedWeapons[1]);
            weaponGUISlot.SetItem(Player.instance.theInventory.equippedWeapons[1]);
        }
        
    }
    private void EquipWeaponThree(InputAction.CallbackContext context)
    {
        if(Player.instance.currentState != Entity.EntityStates.ATTACKING && Player.instance.theInventory.equippedWeapons[2].item != null )
        {
            SoundMaster.instance.PlayRandomSound(EquipAudio);
            Player.instance.EquipItemInHand(Player.instance.theInventory.equippedWeapons[2]);
            weaponGUISlot.SetItem(Player.instance.theInventory.equippedWeapons[2]);
        }
        
    }

}

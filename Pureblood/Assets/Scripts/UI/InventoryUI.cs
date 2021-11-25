using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    InventoryObject inventory;
    public ItemSlot[] inventorySlots;
    private int selectedSlot = 0;
    public static InventoryUI instance;
    [SerializeField] AudioClip[] UIAudio;
    [SerializeField] AudioClip[] EquipAudio;

    //forSyncing
    // Start is called before the first frame update
    void Start()
    {
        inventory = Player.instance.theInventory;
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Debug.Log("Multiple instances of InventoryUI singleton. look into this.");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectNewWeapon(int x)
    {
        SoundMaster.instance.PlayRandomSound(UIAudio);
        selectedSlot = x;
        ToggleSidePannel(true);
        //if(inventory.GetWeapons()!=null)
        //SortItems(inventory.GetWeapons().ToArray());
        List<InventorySlot> WeaponList = new List<InventorySlot>();
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (inventory.Container[i].item.type == ItemType.Weapon)
            {
                WeaponList.Add(new InventorySlot(inventory.Container[i].item, inventory.Container[i].amount));
            }
        }
        SortItems(WeaponList.ToArray());
    }
    public void SelectNewChest(int x)
    {
        SoundMaster.instance.PlayRandomSound(UIAudio);
        selectedSlot = x + 3;
        ToggleSidePannel(true);
        List<InventorySlot> ArmorList = new List<InventorySlot>();
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (inventory.Container[i].item.type == ItemType.Armor)
            {
                if((inventory.Container[i].item as ArmorObject).equipSlot == ArmorObject.Slot.Chest)
                {
                    ArmorList.Add(new InventorySlot(inventory.Container[i].item, inventory.Container[i].amount));
                }
                
            }
        }
        SortItems(ArmorList.ToArray());
    }

    public void SelectNewBoots(int x)
    {
        SoundMaster.instance.PlayRandomSound(UIAudio);
        selectedSlot = x + 4;
        ToggleSidePannel(true);
        List<InventorySlot> ArmorList = new List<InventorySlot>();
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (inventory.Container[i].item.type == ItemType.Armor)
            {
                if ((inventory.Container[i].item as ArmorObject).equipSlot == ArmorObject.Slot.Feet)
                {
                    ArmorList.Add(new InventorySlot(inventory.Container[i].item, inventory.Container[i].amount));
                }

            }
        }
        SortItems(ArmorList.ToArray());
    }

    public void SelectNewConsumable(int x)
    {
        SoundMaster.instance.PlayRandomSound(UIAudio);
        selectedSlot = x + 5;
        ToggleSidePannel(true);
        /*
         * OLD INV CODE
        if (inventory.GetConsumables() != null)
            SortItems(inventory.GetConsumables().ToArray());
        */
        List<InventorySlot> ConsumableList = new List<InventorySlot>();
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            if(inventory.Container[i].item.type == ItemType.Consumable)
            {
                ConsumableList.Add(new InventorySlot(inventory.Container[i].item, inventory.Container[i].amount));
            }
        }
        SortItems(ConsumableList.ToArray());

    }

    private bool pannelActive = false;
    [SerializeField] GameObject ItemListPannel;
    private void ToggleSidePannel(bool b)
    {

            pannelActive = b;
            ItemListPannel.SetActive(b);
    }

    [SerializeField] ItemSlot[] itemListSlots;
    public void SortItems(InventorySlot[] x)
    {
        for(int i = 0; i < itemListSlots.Length; i++)
        {
            if (i >= x.Length)
            {
                itemListSlots[i].gameObject.SetActive(false);
            }
            else
            {
                itemListSlots[i].gameObject.SetActive(true);
                itemListSlots[i].SetItem(x[i]);
            }
        }
    }

    public void EquipItem(InventorySlot item)
    {
        inventorySlots[selectedSlot].SetItem(item);
        if (selectedSlot < 3)
        {
            inventory.EquipWeapon(selectedSlot, item);
            SoundMaster.instance.PlayRandomSound(EquipAudio);
        } else if (selectedSlot < 5)
        {
            SoundMaster.instance.PlayRandomSound(EquipAudio);
            inventory.EquipArmor(selectedSlot-3, item);
            if(Player.instance.theInventory.equippedArmors[0].item != null)
            {
                Player.instance.SetConstitution(Player.instance.GetConstitution() + (Player.instance.theInventory.equippedArmors[0].item as ArmorObject).constitutionBonus + (Player.instance.theInventory.equippedArmors[1].item as ArmorObject).constitutionBonus);
            }
            if(Player.instance.theInventory.equippedArmors[1].item != null)
            {
                Player.instance.SetEndurance(Player.instance.GetEndurance() + (Player.instance.theInventory.equippedArmors[0].item as ArmorObject).enduranceBonus + (Player.instance.theInventory.equippedArmors[1].item as ArmorObject).enduranceBonus);
            }
        }
        else
        {
            SoundMaster.instance.PlayRandomSound(UIAudio);
            inventory.EquipConsumable(selectedSlot - 5, item);
        }
    }

    public ItemSlot[] GetEquipSlots()
    {
        return inventorySlots;
    }


}

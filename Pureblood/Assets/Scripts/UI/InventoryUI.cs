using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] ItemSlot[] inventorySlots;
    private int selectedSlot = 0;
    public static InventoryUI instance;

    //forSyncing
    // Start is called before the first frame update
    void Start()
    {
        inventory = Player.instance.GetInventory();
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
        selectedSlot = x;
        ToggleSidePannel(true);
        if(inventory.GetWeapons()!=null)
        SortItems(inventory.GetWeapons().ToArray());
    }
    public void SelectNewArmor(int x)
    {
        selectedSlot = x + 3;
        ToggleSidePannel(true);
        if (inventory.GetArmors() != null)
            SortItems(inventory.GetArmors().ToArray());
    }
    public void SelectNewConsumable(int x)
    {
        selectedSlot = x + 5;
        ToggleSidePannel(true);
        if (inventory.GetConsumables() != null)
            SortItems(inventory.GetConsumables().ToArray());
    }

    private bool pannelActive = false;
    [SerializeField] GameObject ItemListPannel;
    private void ToggleSidePannel(bool b)
    {

            pannelActive = b;
            ItemListPannel.SetActive(b);
    }

    [SerializeField] ItemSlot[] itemListSlots;
    private void SortItems(Items[] x)
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

    public void EquipItem(Items item)
    {

        inventorySlots[selectedSlot].SetItem(item);
        if (selectedSlot < 2)
        {
            inventory.EquipWeapon(selectedSlot, item as Weapons);
        } else if (selectedSlot < 5)
        {
            inventory.EquipArmor(selectedSlot-3, item as Armor);
        }
        else
        {
            inventory.EquipConsumable(selectedSlot - 5, item as Consumables);
        }

    }


}

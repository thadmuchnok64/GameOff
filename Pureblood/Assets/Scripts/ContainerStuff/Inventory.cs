using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Container
{

    [Tooltip("You should probably check this for the player, and manually call GenerateInventory() for NPCs when they become hostile. That seems like the best practice.")]
    [SerializeField] bool generateInventoryOnAwake = false;
    //for syncing
    Weapons[] equippedWeapons = new Weapons[3];
    Armor[] equippedArmors = new Armor[2];
    Consumables[] equippedConsumables = new Consumables[5];

    private int equippedConsumable = 0;


    public override void Awake()
    {
        if (generateInventoryOnAwake)
        {
            GenerateInventory();
        }

        base.Awake();
    }

    // Maybe we could make a future class called NPCInventory which overrides this with random equipment. Idk.
    public virtual void GenerateInventory()
    {
        for (int i = 0; i < 5; i++)
        {
            equippedConsumables[i] = new Consumables();
        }
        for (int i = 0; i < 3; i++)
        {
            equippedWeapons[i] = new Weapons();
        }
        for (int i = 0; i < 2; i++)
        {
            equippedArmors[i] = new Armor();
        }
    }

    public Weapons[] GetEquippedWeapons()
    {
        return equippedWeapons;
    }

    public Armor[] GetEquippedArmor()
    {
        return equippedArmors;
    }

    public Consumables[] GetEquippedConsumables()
    {
        return equippedConsumables;
    }

    public void EquipWeapon(int slot, Weapons weapon)
    {
        equippedWeapons[slot] = weapon;
    }

    public void EquipArmor(int slot, Armor armor)
    {
        equippedArmors[slot] = armor;
    }

    public void EquipConsumable(int slot, Consumables con)
    {
        equippedConsumables[slot] = con;
    }



    public Consumables GetNextConsumable()
    {
        bool found = false;
        equippedConsumable ++;
        for (int i = 0; i < 2; i++)
        {
            while (equippedConsumable < equippedConsumables.Length)
            {
                if (equippedConsumables[equippedConsumable].GetID()==0) {
                    equippedConsumable++;
                }
                else
                {
                    return equippedConsumables[equippedConsumable];
                }
            }
            equippedConsumable = 0;
        }
        return GetEquippedConsumables()[equippedConsumable];
    }
}

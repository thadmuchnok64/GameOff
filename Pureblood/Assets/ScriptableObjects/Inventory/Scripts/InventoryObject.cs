using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public InventorySlot[] equippedWeapons = new InventorySlot[3];
    public InventorySlot[] equippedArmors = new InventorySlot[2];
    public InventorySlot[] equippedConsumables = new InventorySlot[5];


    private int equippedConsumable = 0;
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for(int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item == _item)
            {
                hasItem = true;
                if(Container[i].AddAmount(_amount))
                {
                    Container.Add(new InventorySlot(_item, _amount));
                    break;
                }
                else
                {
                    break;
                }
            }
        }
        if(!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }

    public void EquipWeapon(int slot, InventorySlot weapon)
    {
        equippedWeapons[slot] = weapon;
    }

    public void EquipArmor(int slot, InventorySlot armor)
    {
        if((armor.item as ArmorObject).equipSlot == ArmorObject.Slot.Chest)
        {
            equippedArmors[0] = armor;

        }
        else
        {
            equippedArmors[1] = armor;
        }
        
    }

    public void EquipConsumable(int slot, InventorySlot con)
    {
        equippedConsumables[slot] = con;
    }

    public InventorySlot GetNextConsumable()
    {
        bool found = false;
        equippedConsumable++;
        for (int i = 0; i < 2; i++)
        {
            while (equippedConsumable < equippedConsumables.Length)
            {
                if (equippedConsumables[equippedConsumable].amount == 0)
                {
                    equippedConsumable++;
                }
                else
                {
                    Player.instance.equippedConsumable = equippedConsumables[equippedConsumable];
                    return equippedConsumables[equippedConsumable];
                }
            }
            equippedConsumable = 0;
        }
        return equippedConsumables[equippedConsumable];
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public int maxAmount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
        maxAmount = _item.maxStackAmount;
    }
    public bool AddAmount(int value)
    {
        bool fullStack = false;
        if(amount == maxAmount)
        {
            fullStack = true;
            return fullStack;
        }
        else
        {
            if(amount + value  >= maxAmount)
            {
                amount = maxAmount;
                return fullStack;
            }
            else
            {
                amount += value;
                return fullStack;
            }
            
        }
        
    }
    public bool SubtractAmount(int _amount)
    {
        bool canUse = false;
        if(amount > 0)
        {
            canUse = true;
            amount -= _amount;
        }
        return canUse;
    }
    

}

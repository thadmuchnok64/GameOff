using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    List<Items> theInventory;
    List<Armor> armors;
    List<Weapons> weapons;
    List<Consumables> consumables;

    public virtual void Awake()
    {
        theInventory = new List<Items>();
        armors = new List<Armor>();
        weapons = new List<Weapons>();
        consumables = new List<Consumables>();
    }
    //Add items to the overall inventory, and then to each respective inventory
    public void AddItem(Items item)
    {
        
        theInventory.Add(item);

        if (item is Weapons weapon)
        {
            weapons.Add(weapon);
        }

        else if (item.GetType().IsSubclassOf(typeof(Armor)))
        {
            Armor armor = (Armor)item;
            armors.Add(armor);
        }

        else if (item.GetType().IsSubclassOf(typeof(Consumables)))
        {
            Consumables consumable = (Consumables)item;
            if(consumable.GetStackAmount() == 0)
            {
                consumables.Add(consumable);
            }
            
        }
    }

    /*
     * Tests if the inventory is actually holding stuff (it is!)
     * 
    private void Update()
    {
        foreach(Items item in theInventory)
        {
            Debug.Log("Holding: " + item.GetName());
        }
    }
    */

    #region Functions To Get Lists


    public List<Items> GetItems()
    {
        return theInventory;
    }

    public List<Armor> GetArmors()
    {
        return armors;
    }

    public List<Weapons> GetWeapons()
    {
        return weapons;
    }

    public List<Consumables> GetConsumables()
    {
        return consumables;
    }


    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : Entity
{
    
    
    private float maxPiss;
    private float currentPiss;
    private int purity = 1000000;
    private int purityToLevel = 300;
    public static Player instance;
    //private Inventory inventory;
    public WeaponObject equippedWeapon;
    public InventorySlot equippedConsumable;
    public ConsumablesFunctions consumablesFunctions;
    //Sword temp;
    public override void Awake()
    {
        //inventory = gameObject.GetComponent<Inventory>();
        //temp = new Sword();
        //inventory.AddItem(temp);
        //Debug.Log(inventory.GetWeapons().Count);
        //inventory.EquipWeapon(0, inventory.GetWeapons()[0]);
        base.Awake();
        currentPiss = 0;
        InvokeRepeating("test", 10, 10);
        consumablesFunctions = new ConsumablesFunctions();
        //EquipItemInHand(temp);
        #region singleton

        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Debug.Log("More than one player script! Might want to look at this, ya bozo!");
            Destroy(this);
        }

        #endregion
    }


    private void test()
    {
        QuestManager.instance.SetQuestToComplete(0);
    }

    public override void FixValues()
    {
        maxPiss = 100 + (GetLevel() * GetDivinity());
        base.FixValues();
    }

    //handling for equipping an item
    //Checks type before applying bonuses
    public void EquipItemInHand(InventorySlot equippedItem)
    {
        equippedWeapon = equippedItem.item as WeaponObject;
        equippedWeapon.calcDamage(strength, dexterity, divinity);
        damage = equippedWeapon.GetDamage();

        /*
        if(equippedItem.GetType().IsSubclassOf(typeof(Weapons)))
        {
            Weapons weapon = GetInventory().GetEquippedWeapons()[0];
            Debug.Log(weapon.GetDamage());
            if(equippedItem.GetType().IsSubclassOf(typeof(MeleeWeapons)))
            {
                weapon = (MeleeWeapons)equippedItem;
            }
            else
            {
                weapon = equippedItem.GetComponent<Guns>();
            }
            weapon.calcDamage(strength, dexterity, divinity);
            damage = weapon.GetDamage();
            
            equippedWeapon = new Weapons();
            
            equippedWeapon = weapon;
            
        }
        else if(equippedItem.GetType().IsSubclassOf(typeof(Armor)))
        {
            Armor armor = equippedItem.GetComponent<Armor>();
            //If player stats aren't enough to wear the armor then they can't wear it
            if(strength >= armor.GetStrReq() || dexterity >= armor.GetDexReq() )
            {
                constitution += armor.GetConstitutionIncrease();
                endurance += armor.GetEnduranceIncrease();
            }    
        }
        */
    }
   

    public int GetPurity()
    {
        return purity;
    }

    public int GetPurityToLevel()
    {
        return purityToLevel;
    }

    public void AddPurity(int x)
    {
        purity += x;
    }

    public float GetPiss()
    {
        return currentPiss;
    }

    public void SetPiss(float piss)
    {
        currentPiss = piss;
    }

    

    public float GetMaxPiss()
    {
        return maxPiss;
    }

    public int LevelUp()
    {
        if (purity >= purityToLevel)
        {
            level++;
            purity -= purityToLevel;
            purityToLevel = Mathf.RoundToInt(300 + (Mathf.Pow(60, 1 + (.01f*level+(.3f * Mathf.Log(level))))));
        }
        else
        {
            return -1; //levelup fail;
        }
        return level;
    }


    public WeaponObject GetWeapon()
    {
        return equippedWeapon;
    }
    public InventoryObject PlayerInv()
    {
        return theInventory;
    }

    private void OnApplicationQuit()
    {
        theInventory.Container.Clear();
        Array.Clear(theInventory.equippedArmors, 0, theInventory.equippedArmors.Length);
        Array.Clear(theInventory.equippedConsumables, 0, theInventory.equippedConsumables.Length);
        Array.Clear(theInventory.equippedWeapons, 0, theInventory.equippedWeapons.Length);
    }

    public IEnumerator ReCalcDamage(float duration)
    {
        if(equippedWeapon != null)
        {
            equippedWeapon.calcDamage(strength, dexterity, divinity);
            damage = equippedWeapon.GetDamage();
            yield return new WaitForSeconds(duration);
            equippedWeapon.calcDamage(strength, dexterity, divinity);
            damage = equippedWeapon.GetDamage();
        }
        
    }

}

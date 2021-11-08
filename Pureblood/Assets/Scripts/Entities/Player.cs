using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    private float maxPiss;
    private float currentPiss;
    public static Player player;

    public override void Awake()
    {
        base.Awake();
        currentPiss = 0;

        #region singleton

        if (player == null)
        {
            player = this;
        }
        else if(player != this)
        {
            Debug.Log("More than one player script! Might want to look at this, ya bozo!");
            Destroy(this);
        }

        #endregion
    }

    public override void FixValues()
    {
        maxPiss = 100 + (GetLevel() * GetDivinity());
        base.FixValues();
    }

    //handling for equipping an item
    //Checks type before applying bonuses
    public void EquipItem(Items equippedItem)
    {
        if(equippedItem.GetType().IsSubclassOf(typeof(Weapons)))
        {
            Weapons weapon = equippedItem.GetComponent<Weapons>();
            weapon.calcDamage(strength, dexterity, divinity);
            damage = weapon.GetDamage();
        }
        else if(equippedItem.GetType().IsSubclassOf(typeof(Armor)))
        {
            constitution += equippedItem.GetComponent<Armor>().GetConstitutionIncrease();
            endurance += equippedItem.GetComponent<Armor>().GetEnduranceIncrease();
        }
    }
}

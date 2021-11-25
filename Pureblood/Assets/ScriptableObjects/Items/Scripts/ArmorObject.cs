using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Armor Object", menuName = "Inventory System/Items/Armor")]
public class ArmorObject : ItemObject
{
    public int constitutionBonus;
    public int enduranceBonus;
    public enum Slot { Chest, Feet}
    public Slot equipSlot;
    
    public void Awake()
    {
        type = ItemType.Armor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Weapon,
    Consumable,
    Armor,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
    public int maxStackAmount;
    public int buyValue;
    public int sellValue;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapon")]
public class WeaponObject : ItemObject
{
    public float damage;
    public float baseDamage;
    public float scalingMultiplier;
    public string scalingStat;
    public float weaponRange;
    public float pissMeterGain;
    public float staminaDrain;
    public float pissDrain;
    public float cooldown;
    public WeaponType weaponType;
    public enum WeaponType { Melee, Ranged }

    public int projectileAmount;
    public GameObject bulletObject;
    public GameObject gunParticles;

    
    public float recoilAmount;
    public float spread;
    public AudioClip[] attackSounds, drySounds;
    public AudioClip equipSound;
    public AudioClip[] impactSounds;

    public AnimatorOverrideController animatorOverrideController;
    [Tooltip("Affects how much firing this weapon will push the character backwards")]
    public float weight;


    public void Awake()
    {
        type = ItemType.Weapon;
    }

    public void calcDamage(int strength, int dexterity, int divinity)
    {
        //calculate damage scaling per weapon by passing in
        //damage = baseDamage + (strength/dexterity/divinity * 0.5f)
        if (scalingStat == "Strength")
        {
            damage = baseDamage + (strength * scalingMultiplier);
        }
        else if (scalingStat == "Dexterity")
        {
            damage = baseDamage + (dexterity * scalingMultiplier);
        }
        else if (scalingStat == "Divinity")
        {
            damage = baseDamage + (divinity * scalingMultiplier);
        }
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetStaminaDrain()
    {
        return staminaDrain;
    }

    public float GetPissGain()
    {
        return pissMeterGain;
    }
    public float GetAttackRange()
    {
        return weaponRange;
    }
    public float GetPissDrain()
    {
        return pissDrain;
    }
}

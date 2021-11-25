using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : Items
{
    protected float damage;
    protected float baseDamage;
    protected float scaling;
    protected string scalingStat;
    protected float pissMeterGain;
    protected string weaponClass;
   
    
    public virtual void calcDamage(int strength, int dexterity, int divinity)
    {
        //calculate damage scaling per weapon by passing in
        //damage = baseDamage + (strength/dexterity/divinity * 0.5f)
        if(scalingStat == "Strength")
        {
            damage = baseDamage + (strength * scaling);
        }
        else if(scalingStat == "Dexterity")
        {
            damage = baseDamage + (dexterity * scaling);
        }
        else if(scalingStat == "Divinity")
        {
            damage = baseDamage + (divinity * scaling);
        }
    }

    

    public float GetDamage()
    {
        return damage;
    }

    public string GetWeaponClass()
    {
        return weaponClass;
    }

    public float GetPissGain()
    {
        return pissMeterGain;
    }
}
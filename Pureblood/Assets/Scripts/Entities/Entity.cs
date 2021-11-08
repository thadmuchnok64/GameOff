using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    /*
     * 
     * SKILLS
     * STRENGTH : Damage for heavier weapons.
     * DEXTERITY: Damage for lighter, skilled weapons. Oh, and guns.
     * CONSTITUTION: Max health per level.
     * ENDURANCE: Max stamina per level.
     * DIVINITY: Magic stat. Effects magic damage and piss meter.
     * 
     * 
     */

    [SerializeField] protected int strength = 10, dexterity = 10, constitution = 10, endurance = 10, divinity = 10;
    [SerializeField] protected int level = 0;
    [SerializeField] protected float damage;
    private float maxHealth, maxStamina;
    private float health, stamina;
    public virtual void Awake()
    {
        FixValues();
        health = maxHealth;
        stamina = maxStamina;
        //InvokeRepeating("FixValues", 1,1);

    }

    // fixes stuf like max stamina, max health, max
    public virtual void FixValues()
    {
        maxHealth = 100 + (level * constitution);
        maxStamina = 100 + (level * endurance);
    }

    //Entity Takes damage
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
    }
    #region Statstuff
    public int GetStrength()
    {
        return strength;
    }
    public void SetStrength(int x)
    {
        strength = x;
    }

    public int GetDexterity()
    {
        return dexterity;
    }
    public void SetDexterity(int x)
    {
        dexterity = x;
    }

    public int GetConstitution()
    {
        return constitution;
    }
    public void SetConstitution(int x)
    {
        constitution = x;
    }

    public int GetEndurance()
    {
        return endurance;
    }
    public void SetEndurance(int x)
    {
        endurance = x;
    }

    public int GetDivinity()
    {
        return divinity;
    }
    public void SetDivinity(int x)
    {
        divinity = x;
    }

    public int GetLevel()
    {
        return level;
    }
    public void SetLevel(int x)
    {
        level = x;
    }

    #endregion

}

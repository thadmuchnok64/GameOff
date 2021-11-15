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

    [Header("Stats")]
    [SerializeField] protected int strength = 10;
    [SerializeField] protected int dexterity = 10;
    [SerializeField] protected int constitution = 10;
    [SerializeField] protected int endurance = 10;
    [SerializeField] protected int divinity = 10;
    [Header(" ")]
    [SerializeField] protected int level = 0;
    [SerializeField] protected float damage = 20f;
    [SerializeField] protected float poise = 100f;
    private float maxHealth, maxStamina;
    private float health, stamina;
    protected bool canRegenStam = true;
    public virtual void Awake()
    {
        FixValues();
        health = maxHealth;
        stamina = maxStamina;
        inventory = GetComponent<Inventory>();
        //InvokeRepeating("FixValues", 1,1);

    }



    // Fundamental functions
    #region Fundamentals
    // fixes stuf like max stamina, max health, max
    public virtual void FixValues()
    {
        maxHealth = 100 + (level * constitution);
        maxStamina = 100 + (level * endurance);
    }

    //Entity Takes damage
    public virtual void TakeDamage(float damage)
    {
        if (currentState != EntityStates.DASHING)
        {
            health -= damage;
        }

    }

    public virtual void useStamina(float staminaDrain)
    {
        stamina -= staminaDrain;
    }

    public float GetStamina()
    {
        return stamina;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetMaxStamina()
    {
        return maxStamina;
    }

    public void SetCanRegenStamina(bool value)
    {
        canRegenStam = value;
    }

    public bool GetCanRegenStamina()
    {
        return canRegenStam;
    }

    public float GetDamage()
    {
        return damage;
    }

    public virtual void FixedUpdate()
    {
      //  Debug.Log(currentState);
        if (canRegenStam)
        {
            stamina += maxStamina * 0.33f * Time.deltaTime;
        }

        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }

        if(health <= 0)
        {
            currentState = EntityStates.DEAD;
            Debug.Log("I am Dead");
        }
        
    }
    #endregion

    // Stat getter and setter functions below
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

    // Inventory stuff
    #region InventoryManagement

    private Inventory inventory;


    public Inventory GetInventory()
    {
        return inventory;
    }

    #endregion

    //Enum States
    #region States
    public enum EntityStates { IDLE, WALKING, DASHING, ATTACKING, PARRYING, PARRYABLE, STUNNED, DEAD, TALKING };
    public EntityStates currentState = EntityStates.IDLE;

    #endregion

    //Status Effects
    #region Status Effects
    public IEnumerator BuffStregnth(int amount, float duration)
    {
        SetStrength(GetStrength() + amount);
        yield return new WaitForSeconds(duration);
        SetStrength(GetStrength() - amount);
    }

    public IEnumerator BuffDexterity(int amount, float duration)
    {
        SetConstitution(GetConstitution() + amount);
        yield return new WaitForSeconds(duration);
        SetConstitution(GetConstitution() - amount);
    }

    public IEnumerator BuffDivinity(int amount, float duration)
    {
        SetDivinity(GetDivinity() + amount);
        yield return new WaitForSeconds(duration);
        SetDivinity(GetDivinity() - amount);
    }
    #endregion
}

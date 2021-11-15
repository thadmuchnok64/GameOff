using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapons : Weapons
{
    protected float attackRange = 0.5f;
    protected float staminaDrain = 20f;
    

    public float GetAttackRange()
    {
        return attackRange;
    }
    public float GetStaminaDrain()
    {
        return staminaDrain;
    }
}

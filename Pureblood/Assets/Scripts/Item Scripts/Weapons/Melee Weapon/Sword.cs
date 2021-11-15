using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapons
{
    
    // Start is called before the first frame update
    public Sword()
    {
        scalingStat = "Strength";
        pissMeterGain = 10f;
        baseDamage = 20f;
        weaponClass = "Sword";
        attackRange = 0.5f;
        staminaDrain = 20f;
        itemID = 2;
    }
    private void Awake()
    {
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

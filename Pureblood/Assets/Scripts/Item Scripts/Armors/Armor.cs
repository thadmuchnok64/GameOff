using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Items
{
    [SerializeField] protected int strReq;
    [SerializeField] protected int dexReq;
    [SerializeField] protected int constitutionIncrease;
    [SerializeField] protected int enduranceIncrease;
    [SerializeField] protected bool areBoots;
    
    public int GetConstitutionIncrease()
    {
        return constitutionIncrease;
    }
    
    public int GetEnduranceIncrease()
    {
        return enduranceIncrease;
    }

    public int GetStrReq()
    {
        return strReq;
    }

    public int GetDexReq()
    {
        return dexReq;
    }
}

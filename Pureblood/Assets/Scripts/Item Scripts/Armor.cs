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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public int GetConstitutionIncrease()
    {
        return constitutionIncrease;
    }
    
    public int GetEnduranceIncrease()
    {
        return enduranceIncrease;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : Items
{

    [SerializeField] protected int stackAmount;
    [SerializeField] protected int maxStackAmount;
    public virtual void useItem()
    {
        //Overide this function in subclasses
    }

    public void AddQuantity(int x)
    {
        stackAmount += x;
        if (stackAmount > maxStackAmount)
        {
            stackAmount = maxStackAmount;
        }
    }

    public bool SubtractQuantity(int x)
    {
        if (stackAmount - x < 0)
        {
            return false;
        }
        else
        {
            stackAmount -= x;
            return true;
        }

        
    }
    public int GetStackAmount()
    {
        return stackAmount;
    }
    

}

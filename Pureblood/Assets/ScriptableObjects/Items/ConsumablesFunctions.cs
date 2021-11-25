using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablesFunctions : MonoBehaviour
{
    
    public void UseItem(string itemName)
    {
        switch(itemName)
        {
            case "Mutton":
                Player.instance.StartCoroutine(Player.instance.BuffStregnth(5, 40));
                Player.instance.StartCoroutine(Player.instance.ReCalcDamage(40));
                break;
        }
    }

    
}
